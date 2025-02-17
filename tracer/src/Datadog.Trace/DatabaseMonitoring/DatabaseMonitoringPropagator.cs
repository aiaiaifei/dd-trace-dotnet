// <copyright file="DatabaseMonitoringPropagator.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using Datadog.Trace.Configuration;
using Datadog.Trace.Propagators;
using Datadog.Trace.Tagging;
using Datadog.Trace.Util;

#nullable enable

namespace Datadog.Trace.DatabaseMonitoring
{
    internal static class DatabaseMonitoringPropagator
    {
        private const string SqlCommentSpanService = "dddbs";
        private const string SqlCommentRootService = "ddps";
        private const string SqlCommentDbName = "dddb";
        private const string SqlCommentOuthost = "ddh";
        private const string SqlCommentVersion = "ddpv";
        private const string SqlCommentEnv = "dde";
        internal const string DbmPrefix = $"/*{SqlCommentSpanService}='";

        internal static string PropagateSpanData(DbmPropagationLevel propagationStyle, string configuredServiceName, string? dbName, string? outhost, Span span, IntegrationId integrationId, out bool traceParentInjected)
        {
            traceParentInjected = false;

            if (integrationId is IntegrationId.MySql or IntegrationId.Npgsql or IntegrationId.SqlClient or IntegrationId.Oracle &&
                (propagationStyle is DbmPropagationLevel.Service or DbmPropagationLevel.Full))
            {
                var propagatorStringBuilder = StringBuilderCache.Acquire(StringBuilderCache.MaxBuilderSize);
                var dddbs = (span.Tags is SqlV1Tags sqlTags) ? sqlTags.PeerService : span.Context.ServiceNameInternal;
                propagatorStringBuilder.Append(DbmPrefix).Append(Uri.EscapeDataString(dddbs)).Append('\'');

                if (span.Context.TraceContext?.Environment is { } envTag)
                {
                    propagatorStringBuilder.Append(',').Append(SqlCommentEnv).Append("='").Append(Uri.EscapeDataString(envTag)).Append('\'');
                }

                propagatorStringBuilder.Append(',').Append(SqlCommentRootService).Append("='").Append(Uri.EscapeDataString(configuredServiceName)).Append('\'');

                if (!string.IsNullOrEmpty(dbName))
                {
                    propagatorStringBuilder.Append(value: ',').Append(SqlCommentDbName).Append("='").Append(Uri.EscapeDataString(dbName)).Append(value: '\'');
                }

                if (!string.IsNullOrEmpty(outhost))
                {
                    propagatorStringBuilder.Append(value: ',').Append(SqlCommentOuthost).Append("='").Append(Uri.EscapeDataString(outhost)).Append(value: '\'');
                }

                if (span.Context.TraceContext?.ServiceVersion is { } versionTag)
                {
                    propagatorStringBuilder.Append(',').Append(SqlCommentVersion).Append("='").Append(Uri.EscapeDataString(versionTag)).Append('\'');
                }

                // For SqlServer & Oracle we don't inject the traceparent to avoid affecting performance, since those DBs generate a new plan for any query changes
                if (propagationStyle == DbmPropagationLevel.Full
                 && integrationId is not (IntegrationId.SqlClient or IntegrationId.Oracle))
                {
                    traceParentInjected = true;
                    propagatorStringBuilder.Append(',').Append(W3CTraceContextPropagator.TraceParentHeaderName).Append("='").Append(W3CTraceContextPropagator.CreateTraceParentHeader(span.Context)).Append("'*/");
                }
                else
                {
                    propagatorStringBuilder.Append("*/");
                }

                return StringBuilderCache.GetStringAndRelease(propagatorStringBuilder);
            }

            return string.Empty;
        }
    }
}
