﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;

namespace Datadog.Trace.Tagging
{
    partial class MsmqTags
    {
        // CommandBytes = System.Text.Encoding.UTF8.GetBytes("msmq.command");
        private static readonly byte[] CommandBytes = new byte[] { 109, 115, 109, 113, 46, 99, 111, 109, 109, 97, 110, 100 };
        // SpanKindBytes = System.Text.Encoding.UTF8.GetBytes("span.kind");
        private static readonly byte[] SpanKindBytes = new byte[] { 115, 112, 97, 110, 46, 107, 105, 110, 100 };
        // InstrumentationNameBytes = System.Text.Encoding.UTF8.GetBytes("component");
        private static readonly byte[] InstrumentationNameBytes = new byte[] { 99, 111, 109, 112, 111, 110, 101, 110, 116 };
        // PathBytes = System.Text.Encoding.UTF8.GetBytes("messaging.destination");
        private static readonly byte[] PathBytes = new byte[] { 109, 101, 115, 115, 97, 103, 105, 110, 103, 46, 100, 101, 115, 116, 105, 110, 97, 116, 105, 111, 110 };
        // MessageWithTransactionBytes = System.Text.Encoding.UTF8.GetBytes("msmq.message.transactional");
        private static readonly byte[] MessageWithTransactionBytes = new byte[] { 109, 115, 109, 113, 46, 109, 101, 115, 115, 97, 103, 101, 46, 116, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 97, 108 };
        // IsTransactionalQueueBytes = System.Text.Encoding.UTF8.GetBytes("msmq.queue.transactional");
        private static readonly byte[] IsTransactionalQueueBytes = new byte[] { 109, 115, 109, 113, 46, 113, 117, 101, 117, 101, 46, 116, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 97, 108 };

        public override string? GetTag(string key)
        {
            return key switch
            {
                "msmq.command" => Command,
                "span.kind" => SpanKind,
                "component" => InstrumentationName,
                "messaging.destination" => Path,
                "msmq.message.transactional" => MessageWithTransaction,
                "msmq.queue.transactional" => IsTransactionalQueue,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "msmq.command": 
                    Command = value;
                    break;
                case "messaging.destination": 
                    Path = value;
                    break;
                case "msmq.message.transactional": 
                    MessageWithTransaction = value;
                    break;
                case "msmq.queue.transactional": 
                    IsTransactionalQueue = value;
                    break;
                case "span.kind": 
                case "component": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(MsmqTags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (Command is not null)
            {
                processor.Process(new TagItem<string>("msmq.command", Command, CommandBytes));
            }

            if (SpanKind is not null)
            {
                processor.Process(new TagItem<string>("span.kind", SpanKind, SpanKindBytes));
            }

            if (InstrumentationName is not null)
            {
                processor.Process(new TagItem<string>("component", InstrumentationName, InstrumentationNameBytes));
            }

            if (Path is not null)
            {
                processor.Process(new TagItem<string>("messaging.destination", Path, PathBytes));
            }

            if (MessageWithTransaction is not null)
            {
                processor.Process(new TagItem<string>("msmq.message.transactional", MessageWithTransaction, MessageWithTransactionBytes));
            }

            if (IsTransactionalQueue is not null)
            {
                processor.Process(new TagItem<string>("msmq.queue.transactional", IsTransactionalQueue, IsTransactionalQueueBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (Command is not null)
            {
                sb.Append("msmq.command (tag):")
                  .Append(Command)
                  .Append(',');
            }

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

            if (Path is not null)
            {
                sb.Append("messaging.destination (tag):")
                  .Append(Path)
                  .Append(',');
            }

            if (MessageWithTransaction is not null)
            {
                sb.Append("msmq.message.transactional (tag):")
                  .Append(MessageWithTransaction)
                  .Append(',');
            }

            if (IsTransactionalQueue is not null)
            {
                sb.Append("msmq.queue.transactional (tag):")
                  .Append(IsTransactionalQueue)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
