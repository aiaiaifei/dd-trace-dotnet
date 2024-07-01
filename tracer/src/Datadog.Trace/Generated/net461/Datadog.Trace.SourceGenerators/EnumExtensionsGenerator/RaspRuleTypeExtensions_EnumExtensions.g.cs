﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

namespace Datadog.Trace.Telemetry.Metrics;

/// <summary>
/// Extension methods for <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" />
/// </summary>
internal static partial class RaspRuleTypeExtensions
{
    /// <summary>
    /// The number of members in the enum.
    /// This is a non-distinct count of defined names.
    /// </summary>
    public const int Length = 3;

    /// <summary>
    /// Returns the string representation of the <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType"/> value.
    /// If the attribute is decorated with a <c>[Description]</c> attribute, then
    /// uses the provided value. Otherwise uses the name of the member, equivalent to
    /// calling <c>ToString()</c> on <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to retrieve the string value for</param>
    /// <returns>The string representation of the value</returns>
    public static string ToStringFast(this Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType value)
        => value switch
        {
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Lfi => "waf_version;rule_type:lfi",
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Ssrf => "waf_version;rule_type:ssrf",
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.SQlI => "waf_version;rule_type:sql_injection",
            _ => value.ToString(),
        };

    /// <summary>
    /// Retrieves an array of the values of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// </summary>
    /// <returns>An array of the values defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" /></returns>
    public static Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType[] GetValues()
        => new []
        {
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Lfi,
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Ssrf,
            Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.SQlI,
        };

    /// <summary>
    /// Retrieves an array of the names of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// Ignores <c>[Description]</c> definitions.
    /// </summary>
    /// <returns>An array of the names of the members defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" /></returns>
    public static string[] GetNames()
        => new []
        {
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Lfi),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.Ssrf),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType.SQlI),
        };

    /// <summary>
    /// Retrieves an array of the names of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// Uses <c>[Description]</c> definition if available, otherwise uses the name of the property
    /// </summary>
    /// <returns>An array of the names of the members defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags.RaspRuleType" /></returns>
    public static string[] GetDescriptions()
        => new []
        {
            "waf_version;rule_type:lfi",
            "waf_version;rule_type:ssrf",
            "waf_version;rule_type:sql_injection",
        };
}