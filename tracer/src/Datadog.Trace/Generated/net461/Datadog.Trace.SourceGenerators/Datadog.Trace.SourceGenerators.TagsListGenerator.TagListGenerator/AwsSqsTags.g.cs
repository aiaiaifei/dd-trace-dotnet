﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class AwsSqsTags
    {
        // QueueNameBytes = MessagePack.Serialize("aws.queue.name");
#if NETCOREAPP
        private static ReadOnlySpan<byte> QueueNameBytes => new byte[] { 174, 97, 119, 115, 46, 113, 117, 101, 117, 101, 46, 110, 97, 109, 101 };
#else
        private static readonly byte[] QueueNameBytes = new byte[] { 174, 97, 119, 115, 46, 113, 117, 101, 117, 101, 46, 110, 97, 109, 101 };
#endif
        // QueueUrlBytes = MessagePack.Serialize("aws.queue.url");
#if NETCOREAPP
        private static ReadOnlySpan<byte> QueueUrlBytes => new byte[] { 173, 97, 119, 115, 46, 113, 117, 101, 117, 101, 46, 117, 114, 108 };
#else
        private static readonly byte[] QueueUrlBytes = new byte[] { 173, 97, 119, 115, 46, 113, 117, 101, 117, 101, 46, 117, 114, 108 };
#endif
        // SpanKindBytes = MessagePack.Serialize("span.kind");
#if NETCOREAPP
        private static ReadOnlySpan<byte> SpanKindBytes => new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#else
        private static readonly byte[] SpanKindBytes = new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "aws.queue.name" => QueueName,
                "aws.queue.url" => QueueUrl,
                "span.kind" => SpanKind,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "aws.queue.name": 
                    QueueName = value;
                    break;
                case "aws.queue.url": 
                    QueueUrl = value;
                    break;
                case "span.kind": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(AwsSqsTags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (QueueName is not null)
            {
                processor.Process(new TagItem<string>("aws.queue.name", QueueName, QueueNameBytes));
            }

            if (QueueUrl is not null)
            {
                processor.Process(new TagItem<string>("aws.queue.url", QueueUrl, QueueUrlBytes));
            }

            if (SpanKind is not null)
            {
                processor.Process(new TagItem<string>("span.kind", SpanKind, SpanKindBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (QueueName is not null)
            {
                sb.Append("aws.queue.name (tag):")
                  .Append(QueueName)
                  .Append(',');
            }

            if (QueueUrl is not null)
            {
                sb.Append("aws.queue.url (tag):")
                  .Append(QueueUrl)
                  .Append(',');
            }

            if (SpanKind is not null)
            {
                sb.Append("span.kind (tag):")
                  .Append(SpanKind)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
