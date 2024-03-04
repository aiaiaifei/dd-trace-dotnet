﻿// <copyright file="ITest.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System.Reflection;

namespace Datadog.Trace.Ci;

/// <summary>
/// CI Visibility test
/// </summary>
public interface ITest
{
    /// <summary>
    /// Gets the test name
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// Gets the test start date
    /// </summary>
    DateTimeOffset StartTime { get; }

    /// <summary>
    /// Gets the test suite for this test
    /// </summary>
    ITestSuite Suite { get; }

    /// <summary>
    /// Sets a string tag into the test
    /// </summary>
    /// <param name="key">Key of the tag</param>
    /// <param name="value">Value of the tag</param>
    void SetTag(string key, string? value);

    /// <summary>
    /// Sets a number tag into the test
    /// </summary>
    /// <param name="key">Key of the tag</param>
    /// <param name="value">Value of the tag</param>
    void SetTag(string key, double? value);

    /// <summary>
    /// Set Error Info
    /// </summary>
    /// <param name="type">Error type</param>
    /// <param name="message">Error message</param>
    /// <param name="callStack">Error callstack</param>
    void SetErrorInfo(string type, string message, string? callStack);

    /// <summary>
    /// Set Error Info from Exception
    /// </summary>
    /// <param name="exception">Exception instance</param>
    void SetErrorInfo(Exception exception);

    /// <summary>
    /// Set Test method info
    /// </summary>
    /// <param name="methodInfo">Test MethodInfo instance</param>
    void SetTestMethodInfo(MethodInfo methodInfo);

    /// <summary>
    /// Set Test traits
    /// </summary>
    /// <param name="traits">Traits dictionary</param>
    void SetTraits(Dictionary<string, List<string>> traits);

    /// <summary>
    /// Set Test parameters
    /// </summary>
    /// <param name="parameters">TestParameters instance</param>
    void SetParameters(TestParameters parameters);

    /// <summary>
    /// Set benchmark metadata
    /// </summary>
    /// <param name="hostInfo">Host info</param>
    /// <param name="jobInfo">Job info</param>
    void SetBenchmarkMetadata(BenchmarkHostInfo hostInfo, BenchmarkJobInfo jobInfo);

    /// <summary>
    /// Add benchmark data
    /// </summary>
    /// <param name="measureType">Measure type</param>
    /// <param name="info">Measure info</param>
    /// <param name="statistics">Statistics values</param>
    void AddBenchmarkData(BenchmarkMeasureType measureType, string info, BenchmarkDiscreteStats statistics);

    /// <summary>
    /// Close test
    /// </summary>
    /// <param name="status">Test status</param>
    void Close(TestStatus status);

    /// <summary>
    /// Close test
    /// </summary>
    /// <param name="status">Test status</param>
    /// <param name="duration">Duration of the test suite</param>
    void Close(TestStatus status, TimeSpan? duration);

    /// <summary>
    /// Close test
    /// </summary>
    /// <param name="status">Test status</param>
    /// <param name="duration">Duration of the test suite</param>
    /// <param name="skipReason">In case </param>
    void Close(TestStatus status, TimeSpan? duration, string? skipReason);
}
