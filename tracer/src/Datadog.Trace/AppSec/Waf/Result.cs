// <copyright file="Result.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;

namespace Datadog.Trace.AppSec.Waf
{
    internal class Result : IResult
    {
        public Result(ReturnCode returnCode, IReadOnlyList<RuleMatch> data)
        {
            ReturnCode = returnCode;
            Data = data;
        }

        public ReturnCode ReturnCode { get; }

        public IReadOnlyList<RuleMatch> Data { get; }
    }
}
