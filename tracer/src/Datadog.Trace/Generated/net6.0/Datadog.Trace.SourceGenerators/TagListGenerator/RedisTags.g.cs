﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Redis
{
    partial class RedisTags
    {
        // DatabaseIndexBytes = MessagePack.Serialize("db.redis.database_index");
#if NETCOREAPP
        private static ReadOnlySpan<byte> DatabaseIndexBytes => new byte[] { 183, 100, 98, 46, 114, 101, 100, 105, 115, 46, 100, 97, 116, 97, 98, 97, 115, 101, 95, 105, 110, 100, 101, 120 };
#else
        private static readonly byte[] DatabaseIndexBytes = new byte[] { 183, 100, 98, 46, 114, 101, 100, 105, 115, 46, 100, 97, 116, 97, 98, 97, 115, 101, 95, 105, 110, 100, 101, 120 };
#endif
        // SpanKindBytes = MessagePack.Serialize("span.kind");
#if NETCOREAPP
        private static ReadOnlySpan<byte> SpanKindBytes => new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#else
        private static readonly byte[] SpanKindBytes = new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#endif
        // InstrumentationNameBytes = MessagePack.Serialize("component");
#if NETCOREAPP
        private static ReadOnlySpan<byte> InstrumentationNameBytes => new byte[] { 169, 99, 111, 109, 112, 111, 110, 101, 110, 116 };
#else
        private static readonly byte[] InstrumentationNameBytes = new byte[] { 169, 99, 111, 109, 112, 111, 110, 101, 110, 116 };
#endif
        // RawCommandBytes = MessagePack.Serialize("redis.raw_command");
#if NETCOREAPP
        private static ReadOnlySpan<byte> RawCommandBytes => new byte[] { 177, 114, 101, 100, 105, 115, 46, 114, 97, 119, 95, 99, 111, 109, 109, 97, 110, 100 };
#else
        private static readonly byte[] RawCommandBytes = new byte[] { 177, 114, 101, 100, 105, 115, 46, 114, 97, 119, 95, 99, 111, 109, 109, 97, 110, 100 };
#endif
        // HostBytes = MessagePack.Serialize("out.host");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HostBytes => new byte[] { 168, 111, 117, 116, 46, 104, 111, 115, 116 };
#else
        private static readonly byte[] HostBytes = new byte[] { 168, 111, 117, 116, 46, 104, 111, 115, 116 };
#endif
        // PortBytes = MessagePack.Serialize("out.port");
#if NETCOREAPP
        private static ReadOnlySpan<byte> PortBytes => new byte[] { 168, 111, 117, 116, 46, 112, 111, 114, 116 };
#else
        private static readonly byte[] PortBytes = new byte[] { 168, 111, 117, 116, 46, 112, 111, 114, 116 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "span.kind" => SpanKind,
                "component" => InstrumentationName,
                "redis.raw_command" => RawCommand,
                "out.host" => Host,
                "out.port" => Port,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "component": 
                    InstrumentationName = value;
                    break;
                case "redis.raw_command": 
                    RawCommand = value;
                    break;
                case "out.host": 
                    Host = value;
                    break;
                case "out.port": 
                    Port = value;
                    break;
                case "span.kind": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(RedisTags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (SpanKind is not null)
            {
                processor.Process(new TagItem<string>("span.kind", SpanKind, SpanKindBytes));
            }

            if (InstrumentationName is not null)
            {
                processor.Process(new TagItem<string>("component", InstrumentationName, InstrumentationNameBytes));
            }

            if (RawCommand is not null)
            {
                processor.Process(new TagItem<string>("redis.raw_command", RawCommand, RawCommandBytes));
            }

            if (Host is not null)
            {
                processor.Process(new TagItem<string>("out.host", Host, HostBytes));
            }

            if (Port is not null)
            {
                processor.Process(new TagItem<string>("out.port", Port, PortBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (SpanKind is not null)
            {
                sb.Append("span.kind (tag):")
                  .Append(SpanKind)
                  .Append(',');
            }

            if (InstrumentationName is not null)
            {
                sb.Append("component (tag):")
                  .Append(InstrumentationName)
                  .Append(',');
            }

            if (RawCommand is not null)
            {
                sb.Append("redis.raw_command (tag):")
                  .Append(RawCommand)
                  .Append(',');
            }

            if (Host is not null)
            {
                sb.Append("out.host (tag):")
                  .Append(Host)
                  .Append(',');
            }

            if (Port is not null)
            {
                sb.Append("out.port (tag):")
                  .Append(Port)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
        public override double? GetMetric(string key)
        {
            return key switch
            {
                "db.redis.database_index" => DatabaseIndex,
                _ => base.GetMetric(key),
            };
        }

        public override void SetMetric(string key, double? value)
        {
            switch(key)
            {
                case "db.redis.database_index": 
                    DatabaseIndex = value;
                    break;
                default: 
                    base.SetMetric(key, value);
                    break;
            }
        }

        public override void EnumerateMetrics<TProcessor>(ref TProcessor processor)
        {
            if (DatabaseIndex is not null)
            {
                processor.Process(new TagItem<double>("db.redis.database_index", DatabaseIndex.Value, DatabaseIndexBytes));
            }

            base.EnumerateMetrics(ref processor);
        }

        protected override void WriteAdditionalMetrics(System.Text.StringBuilder sb)
        {
            if (DatabaseIndex is not null)
            {
                sb.Append("db.redis.database_index (metric):")
                  .Append(DatabaseIndex.Value)
                  .Append(',');
            }

            base.WriteAdditionalMetrics(sb);
        }
    }
}
