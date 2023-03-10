// <copyright file="ConnectionMultiplexerSelectServerIntegration.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System;
using System.ComponentModel;
using Datadog.Trace.ClrProfiler.CallTarget;
using Datadog.Trace.Logging;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Redis.StackExchange;

/// <summary>
/// StackExchange.Redis.ConnectionMultiplexer.ExecuteAsyncImpl calltarget instrumentation
/// </summary>
[InstrumentMethod(
    AssemblyName = "StackExchange.Redis",
    TypeName = "StackExchange.Redis.ConnectionMultiplexer",
    MethodName = "SelectServer",
    ReturnTypeName = "StackExchange.Redis.ServerEndPoint",
    ParameterTypeNames = new[] { "StackExchange.Redis.Message" },
    MinimumVersion = "1.0.0",
    MaximumVersion = "2.*.*",
    IntegrationName = StackExchangeRedisHelper.IntegrationName)]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class ConnectionMultiplexerSelectServerIntegration
{
    private static readonly IDatadogLogger Log = DatadogLogging.GetLoggerFor(typeof(ConnectionMultiplexerSelectServerIntegration));

    internal static CallTargetReturn<TResult> OnMethodEnd<TTarget, TResult>(TTarget instance, TResult result, Exception exception, in CallTargetState state)
    {
        var span = Tracer.Instance.InternalActiveScope?.Span;

        if (result is not null
            && span is { Type: SpanTypes.Redis, Tags: RedisTags { InstrumentationName: StackExchangeRedisHelper.IntegrationName } tags })
        {
            var hostAndPort = result.ToString()!.Split(':');

            tags.Host = hostAndPort[0];

            if (tags.Host.Length > 1)
            {
                if (!int.TryParse(hostAndPort[1], out var port))
                {
                    Log.Debug("Unable to parse the Redis port ({Port}) to an int", hostAndPort[1]);
                }

                tags.Port = port;
            }
        }

        return new CallTargetReturn<TResult>(result);
    }
}
