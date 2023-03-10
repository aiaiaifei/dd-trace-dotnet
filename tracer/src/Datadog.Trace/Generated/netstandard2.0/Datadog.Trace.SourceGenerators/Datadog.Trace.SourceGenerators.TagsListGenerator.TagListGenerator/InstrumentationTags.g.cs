﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class InstrumentationTags
    {
        // AnalyticsSampleRateBytes = MessagePack.Serialize("_dd1.sr.eausr");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AnalyticsSampleRateBytes => new byte[] { 173, 95, 100, 100, 49, 46, 115, 114, 46, 101, 97, 117, 115, 114 };
#else
        private static readonly byte[] AnalyticsSampleRateBytes = new byte[] { 173, 95, 100, 100, 49, 46, 115, 114, 46, 101, 97, 117, 115, 114 };
#endif

        public override double? GetMetric(string key)
        {
            return key switch
            {
                "_dd1.sr.eausr" => AnalyticsSampleRate,
                _ => base.GetMetric(key),
            };
        }

        public override void SetMetric(string key, double? value)
        {
            switch(key)
            {
                case "_dd1.sr.eausr": 
                    AnalyticsSampleRate = value;
                    break;
                default: 
                    base.SetMetric(key, value);
                    break;
            }
        }

        public override void EnumerateMetrics<TProcessor>(ref TProcessor processor)
        {
            if (AnalyticsSampleRate is not null)
            {
                processor.Process(new TagItem<double>("_dd1.sr.eausr", AnalyticsSampleRate.Value, AnalyticsSampleRateBytes));
            }

            base.EnumerateMetrics(ref processor);
        }

        protected override void WriteAdditionalMetrics(System.Text.StringBuilder sb)
        {
            if (AnalyticsSampleRate is not null)
            {
                sb.Append("_dd1.sr.eausr (metric):")
                  .Append(AnalyticsSampleRate.Value)
                  .Append(',');
            }

            base.WriteAdditionalMetrics(sb);
        }
    }
}
