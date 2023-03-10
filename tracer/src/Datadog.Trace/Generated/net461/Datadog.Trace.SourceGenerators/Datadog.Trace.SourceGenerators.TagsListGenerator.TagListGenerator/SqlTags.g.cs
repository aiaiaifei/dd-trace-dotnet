﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;

namespace Datadog.Trace.Tagging
{
    partial class SqlTags
    {
        // SpanKindBytes = System.Text.Encoding.UTF8.GetBytes("span.kind");
        private static readonly byte[] SpanKindBytes = new byte[] { 115, 112, 97, 110, 46, 107, 105, 110, 100 };
        // DbTypeBytes = System.Text.Encoding.UTF8.GetBytes("db.type");
        private static readonly byte[] DbTypeBytes = new byte[] { 100, 98, 46, 116, 121, 112, 101 };
        // InstrumentationNameBytes = System.Text.Encoding.UTF8.GetBytes("component");
        private static readonly byte[] InstrumentationNameBytes = new byte[] { 99, 111, 109, 112, 111, 110, 101, 110, 116 };
        // DbNameBytes = System.Text.Encoding.UTF8.GetBytes("db.name");
        private static readonly byte[] DbNameBytes = new byte[] { 100, 98, 46, 110, 97, 109, 101 };
        // DbUserBytes = System.Text.Encoding.UTF8.GetBytes("db.user");
        private static readonly byte[] DbUserBytes = new byte[] { 100, 98, 46, 117, 115, 101, 114 };
        // OutHostBytes = System.Text.Encoding.UTF8.GetBytes("network.destination.ip");
        private static readonly byte[] OutHostBytes = new byte[] { 110, 101, 116, 119, 111, 114, 107, 46, 100, 101, 115, 116, 105, 110, 97, 116, 105, 111, 110, 46, 105, 112 };
        // DbmDataPropagatedBytes = System.Text.Encoding.UTF8.GetBytes("_dd.dbm_trace_injected");
        private static readonly byte[] DbmDataPropagatedBytes = new byte[] { 95, 100, 100, 46, 100, 98, 109, 95, 116, 114, 97, 99, 101, 95, 105, 110, 106, 101, 99, 116, 101, 100 };

        public override string? GetTag(string key)
        {
            return key switch
            {
                "span.kind" => SpanKind,
                "db.type" => DbType,
                "component" => InstrumentationName,
                "db.name" => DbName,
                "db.user" => DbUser,
                "network.destination.ip" => OutHost,
                "_dd.dbm_trace_injected" => DbmDataPropagated,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "db.type": 
                    DbType = value;
                    break;
                case "component": 
                    InstrumentationName = value;
                    break;
                case "db.name": 
                    DbName = value;
                    break;
                case "db.user": 
                    DbUser = value;
                    break;
                case "network.destination.ip": 
                    OutHost = value;
                    break;
                case "_dd.dbm_trace_injected": 
                    DbmDataPropagated = value;
                    break;
                case "span.kind": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(SqlTags));
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

            if (DbType is not null)
            {
                processor.Process(new TagItem<string>("db.type", DbType, DbTypeBytes));
            }

            if (InstrumentationName is not null)
            {
                processor.Process(new TagItem<string>("component", InstrumentationName, InstrumentationNameBytes));
            }

            if (DbName is not null)
            {
                processor.Process(new TagItem<string>("db.name", DbName, DbNameBytes));
            }

            if (DbUser is not null)
            {
                processor.Process(new TagItem<string>("db.user", DbUser, DbUserBytes));
            }

            if (OutHost is not null)
            {
                processor.Process(new TagItem<string>("network.destination.ip", OutHost, OutHostBytes));
            }

            if (DbmDataPropagated is not null)
            {
                processor.Process(new TagItem<string>("_dd.dbm_trace_injected", DbmDataPropagated, DbmDataPropagatedBytes));
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

            if (DbType is not null)
            {
                sb.Append("db.type (tag):")
                  .Append(DbType)
                  .Append(',');
            }

            if (InstrumentationName is not null)
            {
                sb.Append("component (tag):")
                  .Append(InstrumentationName)
                  .Append(',');
            }

            if (DbName is not null)
            {
                sb.Append("db.name (tag):")
                  .Append(DbName)
                  .Append(',');
            }

            if (DbUser is not null)
            {
                sb.Append("db.user (tag):")
                  .Append(DbUser)
                  .Append(',');
            }

            if (OutHost is not null)
            {
                sb.Append("network.destination.ip (tag):")
                  .Append(OutHost)
                  .Append(',');
            }

            if (DbmDataPropagated is not null)
            {
                sb.Append("_dd.dbm_trace_injected (tag):")
                  .Append(DbmDataPropagated)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
