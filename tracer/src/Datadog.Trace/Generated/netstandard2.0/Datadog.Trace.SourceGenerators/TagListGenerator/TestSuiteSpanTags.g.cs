﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Ci.Tagging
{
    partial class TestSuiteSpanTags
    {
        // SuiteBytes = MessagePack.Serialize("test.suite");
        private static ReadOnlySpan<byte> SuiteBytes => new byte[] { 170, 116, 101, 115, 116, 46, 115, 117, 105, 116, 101 };

        public override string? GetTag(string key)
        {
            return key switch
            {
                "test.suite" => Suite,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "test.suite": 
                    Suite = value;
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (Suite is not null)
            {
                processor.Process(new TagItem<string>("test.suite", Suite, SuiteBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (Suite is not null)
            {
                sb.Append("test.suite (tag):")
                  .Append(Suite)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
