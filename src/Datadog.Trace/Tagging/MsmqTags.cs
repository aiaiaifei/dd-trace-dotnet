using System;
using System.Collections.Generic;
using System.Linq;
using Datadog.Trace.ExtensionMethods;

namespace Datadog.Trace.Tagging
{
    internal class MsmqTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] MsmqTagsProperties =
           InstrumentationTagsProperties.Concat(
               new ReadOnlyProperty<MsmqTags, string>(Trace.Tags.InstrumentationName, t => t.InstrumentationName),
               new Property<MsmqTags, string>(Trace.Tags.MsmqCommand, t => t.Command, (t, v) => t.Command = v),
               new Property<MsmqTags, string>(Trace.Tags.MsmqQueueUniqueName, t => t.UniqueQueueName, (t, v) => t.UniqueQueueName = v),
               new Property<MsmqTags, string>(Trace.Tags.MsmqIsTransactionalQueue, t => t.IsTransactionalQueue, (t, v) => t.IsTransactionalQueue = v),
               new Property<MsmqTags, string>(Trace.Tags.MsmqMessageWithTransaction, t => t.MessageWithTransaction, (t, v) => t.MessageWithTransaction = v));

        public MsmqTags() => SpanKind = SpanKinds.Consumer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsmqTags"/> class.
        /// </summary>
        /// <param name="spanKind">kind of span</param>
        public MsmqTags(string spanKind) => SpanKind = spanKind;

        public string Command { get; set; }

        /// <inheritdoc/>
        public override string SpanKind { get; }

        public string UniqueQueueName { get; set; }

        public string MessageWithTransaction { get; set; }

        public string InstrumentationName => "msmq";

        public string IsTransactionalQueue { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => MsmqTagsProperties;
    }
}
