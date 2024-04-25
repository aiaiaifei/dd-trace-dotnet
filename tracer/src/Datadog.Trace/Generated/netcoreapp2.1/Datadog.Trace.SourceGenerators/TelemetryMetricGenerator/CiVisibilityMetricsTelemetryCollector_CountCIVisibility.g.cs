﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using System.Threading;

namespace Datadog.Trace.Telemetry;
internal partial class CiVisibilityMetricsTelemetryCollector
{
    private const int CountCIVisibilityLength = 285;

    /// <summary>
    /// Creates the buffer for the <see cref="Datadog.Trace.Telemetry.Metrics.CountCIVisibility" /> values.
    /// </summary>
    private static AggregatedMetric[] GetCountCIVisibilityBuffer()
        => new AggregatedMetric[]
        {
            // event_created, index = 0
            new(new[] { "test_framework:xunit", "event_type:test" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:xunit", "event_type:suite" }),
            new(new[] { "test_framework:xunit", "event_type:module" }),
            new(new[] { "test_framework:xunit", "event_type:session" }),
            new(new[] { "test_framework:xunit", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:xunit", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:xunit", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:nunit", "event_type:test" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:nunit", "event_type:suite" }),
            new(new[] { "test_framework:nunit", "event_type:module" }),
            new(new[] { "test_framework:nunit", "event_type:session" }),
            new(new[] { "test_framework:nunit", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:nunit", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:nunit", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:mstest", "event_type:test" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:mstest", "event_type:suite" }),
            new(new[] { "test_framework:mstest", "event_type:module" }),
            new(new[] { "test_framework:mstest", "event_type:session" }),
            new(new[] { "test_framework:mstest", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:mstest", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:mstest", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:suite" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:module" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:unknown", "event_type:test" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:unknown", "event_type:suite" }),
            new(new[] { "test_framework:unknown", "event_type:module" }),
            new(new[] { "test_framework:unknown", "event_type:session" }),
            new(new[] { "test_framework:unknown", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:unknown", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:unknown", "event_type:session", "has_codeowner" }),
            // event_finished, index = 40
            new(new[] { "test_framework:xunit", "event_type:test" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:xunit", "event_type:suite" }),
            new(new[] { "test_framework:xunit", "event_type:module" }),
            new(new[] { "test_framework:xunit", "event_type:session" }),
            new(new[] { "test_framework:xunit", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:xunit", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:xunit", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow" }),
            new(new[] { "test_framework:xunit", "event_type:test", "browser_driver:selenium" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true", "browser_driver:selenium" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium" }),
            new(new[] { "test_framework:xunit", "event_type:test", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:xunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:nunit", "event_type:test" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:nunit", "event_type:suite" }),
            new(new[] { "test_framework:nunit", "event_type:module" }),
            new(new[] { "test_framework:nunit", "event_type:session" }),
            new(new[] { "test_framework:nunit", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:nunit", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:nunit", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow" }),
            new(new[] { "test_framework:nunit", "event_type:test", "browser_driver:selenium" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true", "browser_driver:selenium" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium" }),
            new(new[] { "test_framework:nunit", "event_type:test", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:nunit", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:mstest", "event_type:test" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:mstest", "event_type:suite" }),
            new(new[] { "test_framework:mstest", "event_type:module" }),
            new(new[] { "test_framework:mstest", "event_type:session" }),
            new(new[] { "test_framework:mstest", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:mstest", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:mstest", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow" }),
            new(new[] { "test_framework:mstest", "event_type:test", "browser_driver:selenium" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true", "browser_driver:selenium" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium" }),
            new(new[] { "test_framework:mstest", "event_type:test", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:mstest", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:suite" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:module" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "browser_driver:selenium" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true", "browser_driver:selenium" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:benchmarkdotnet", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:unknown", "event_type:test" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_benchmark" }),
            new(new[] { "test_framework:unknown", "event_type:suite" }),
            new(new[] { "test_framework:unknown", "event_type:module" }),
            new(new[] { "test_framework:unknown", "event_type:session" }),
            new(new[] { "test_framework:unknown", "event_type:session", "is_unsupported_ci" }),
            new(new[] { "test_framework:unknown", "event_type:session", "has_codeowner", "is_unsupported_ci" }),
            new(new[] { "test_framework:unknown", "event_type:session", "has_codeowner" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow" }),
            new(new[] { "test_framework:unknown", "event_type:test", "browser_driver:selenium" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true", "browser_driver:selenium" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium" }),
            new(new[] { "test_framework:unknown", "event_type:test", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true", "browser_driver:selenium", "is_rum:true" }),
            new(new[] { "test_framework:unknown", "event_type:test", "is_new:true", "early_flake_detection_abort_reason:slow", "browser_driver:selenium", "is_rum:true" }),
            // code_coverage_started, index = 120
            new(new[] { "test_framework:xunit", "library:custom" }),
            new(new[] { "test_framework:xunit", "library:unknown" }),
            new(new[] { "test_framework:nunit", "library:custom" }),
            new(new[] { "test_framework:nunit", "library:unknown" }),
            new(new[] { "test_framework:mstest", "library:custom" }),
            new(new[] { "test_framework:mstest", "library:unknown" }),
            new(new[] { "test_framework:benchmarkdotnet", "library:custom" }),
            new(new[] { "test_framework:benchmarkdotnet", "library:unknown" }),
            new(new[] { "test_framework:unknown", "library:custom" }),
            new(new[] { "test_framework:unknown", "library:unknown" }),
            // code_coverage_finished, index = 130
            new(new[] { "test_framework:xunit", "library:custom" }),
            new(new[] { "test_framework:xunit", "library:unknown" }),
            new(new[] { "test_framework:nunit", "library:custom" }),
            new(new[] { "test_framework:nunit", "library:unknown" }),
            new(new[] { "test_framework:mstest", "library:custom" }),
            new(new[] { "test_framework:mstest", "library:unknown" }),
            new(new[] { "test_framework:benchmarkdotnet", "library:custom" }),
            new(new[] { "test_framework:benchmarkdotnet", "library:unknown" }),
            new(new[] { "test_framework:unknown", "library:custom" }),
            new(new[] { "test_framework:unknown", "library:unknown" }),
            // manual_api_events, index = 140
            new(new[] { "event_type:test" }),
            new(new[] { "event_type:suite" }),
            new(new[] { "event_type:module" }),
            new(new[] { "event_type:session" }),
            // events_enqueued_for_serialization, index = 144
            new(null),
            // endpoint_payload.requests, index = 145
            new(new[] { "endpoint:test_cycle" }),
            new(new[] { "endpoint:code_coverage" }),
            // endpoint_payload.requests_errors, index = 147
            new(new[] { "endpoint:test_cycle", "error_type:timeout" }),
            new(new[] { "endpoint:test_cycle", "error_type:network" }),
            new(new[] { "endpoint:test_cycle", "error_type:status_code" }),
            new(new[] { "endpoint:test_cycle", "error_type:status_code_4xx_response" }),
            new(new[] { "endpoint:test_cycle", "error_type:status_code_5xx_response" }),
            new(new[] { "endpoint:code_coverage", "error_type:timeout" }),
            new(new[] { "endpoint:code_coverage", "error_type:network" }),
            new(new[] { "endpoint:code_coverage", "error_type:status_code" }),
            new(new[] { "endpoint:code_coverage", "error_type:status_code_4xx_response" }),
            new(new[] { "endpoint:code_coverage", "error_type:status_code_5xx_response" }),
            // endpoint_payload.dropped, index = 157
            new(new[] { "endpoint:test_cycle" }),
            new(new[] { "endpoint:code_coverage" }),
            // git.command, index = 159
            new(new[] { "command:get_repository" }),
            new(new[] { "command:get_branch" }),
            new(new[] { "command:get_remote" }),
            new(new[] { "command:get_head" }),
            new(new[] { "command:check_shallow" }),
            new(new[] { "command:unshallow" }),
            new(new[] { "command:get_local_commits" }),
            new(new[] { "command:get_objects" }),
            new(new[] { "command:pack_objects" }),
            // git.command_errors, index = 168
            new(new[] { "command:get_repository", "exit_code:unknown" }),
            new(new[] { "command:get_repository", "exit_code:-1" }),
            new(new[] { "command:get_repository", "exit_code:1" }),
            new(new[] { "command:get_repository", "exit_code:2" }),
            new(new[] { "command:get_repository", "exit_code:127" }),
            new(new[] { "command:get_repository", "exit_code:128" }),
            new(new[] { "command:get_repository", "exit_code:129" }),
            new(new[] { "command:get_branch", "exit_code:unknown" }),
            new(new[] { "command:get_branch", "exit_code:-1" }),
            new(new[] { "command:get_branch", "exit_code:1" }),
            new(new[] { "command:get_branch", "exit_code:2" }),
            new(new[] { "command:get_branch", "exit_code:127" }),
            new(new[] { "command:get_branch", "exit_code:128" }),
            new(new[] { "command:get_branch", "exit_code:129" }),
            new(new[] { "command:get_remote", "exit_code:unknown" }),
            new(new[] { "command:get_remote", "exit_code:-1" }),
            new(new[] { "command:get_remote", "exit_code:1" }),
            new(new[] { "command:get_remote", "exit_code:2" }),
            new(new[] { "command:get_remote", "exit_code:127" }),
            new(new[] { "command:get_remote", "exit_code:128" }),
            new(new[] { "command:get_remote", "exit_code:129" }),
            new(new[] { "command:get_head", "exit_code:unknown" }),
            new(new[] { "command:get_head", "exit_code:-1" }),
            new(new[] { "command:get_head", "exit_code:1" }),
            new(new[] { "command:get_head", "exit_code:2" }),
            new(new[] { "command:get_head", "exit_code:127" }),
            new(new[] { "command:get_head", "exit_code:128" }),
            new(new[] { "command:get_head", "exit_code:129" }),
            new(new[] { "command:check_shallow", "exit_code:unknown" }),
            new(new[] { "command:check_shallow", "exit_code:-1" }),
            new(new[] { "command:check_shallow", "exit_code:1" }),
            new(new[] { "command:check_shallow", "exit_code:2" }),
            new(new[] { "command:check_shallow", "exit_code:127" }),
            new(new[] { "command:check_shallow", "exit_code:128" }),
            new(new[] { "command:check_shallow", "exit_code:129" }),
            new(new[] { "command:unshallow", "exit_code:unknown" }),
            new(new[] { "command:unshallow", "exit_code:-1" }),
            new(new[] { "command:unshallow", "exit_code:1" }),
            new(new[] { "command:unshallow", "exit_code:2" }),
            new(new[] { "command:unshallow", "exit_code:127" }),
            new(new[] { "command:unshallow", "exit_code:128" }),
            new(new[] { "command:unshallow", "exit_code:129" }),
            new(new[] { "command:get_local_commits", "exit_code:unknown" }),
            new(new[] { "command:get_local_commits", "exit_code:-1" }),
            new(new[] { "command:get_local_commits", "exit_code:1" }),
            new(new[] { "command:get_local_commits", "exit_code:2" }),
            new(new[] { "command:get_local_commits", "exit_code:127" }),
            new(new[] { "command:get_local_commits", "exit_code:128" }),
            new(new[] { "command:get_local_commits", "exit_code:129" }),
            new(new[] { "command:get_objects", "exit_code:unknown" }),
            new(new[] { "command:get_objects", "exit_code:-1" }),
            new(new[] { "command:get_objects", "exit_code:1" }),
            new(new[] { "command:get_objects", "exit_code:2" }),
            new(new[] { "command:get_objects", "exit_code:127" }),
            new(new[] { "command:get_objects", "exit_code:128" }),
            new(new[] { "command:get_objects", "exit_code:129" }),
            new(new[] { "command:pack_objects", "exit_code:unknown" }),
            new(new[] { "command:pack_objects", "exit_code:-1" }),
            new(new[] { "command:pack_objects", "exit_code:1" }),
            new(new[] { "command:pack_objects", "exit_code:2" }),
            new(new[] { "command:pack_objects", "exit_code:127" }),
            new(new[] { "command:pack_objects", "exit_code:128" }),
            new(new[] { "command:pack_objects", "exit_code:129" }),
            // git_requests.search_commits, index = 231
            new(null),
            // git_requests.search_commits_errors, index = 232
            new(new[] { "error_type:timeout" }),
            new(new[] { "error_type:network" }),
            new(new[] { "error_type:status_code" }),
            new(new[] { "error_type:status_code_4xx_response" }),
            new(new[] { "error_type:status_code_5xx_response" }),
            // git_requests.objects_pack, index = 237
            new(null),
            // git_requests.objects_pack_errors, index = 238
            new(new[] { "error_type:timeout" }),
            new(new[] { "error_type:network" }),
            new(new[] { "error_type:status_code" }),
            new(new[] { "error_type:status_code_4xx_response" }),
            new(new[] { "error_type:status_code_5xx_response" }),
            // git_requests.settings, index = 243
            new(null),
            // git_requests.settings_errors, index = 244
            new(new[] { "error_type:timeout" }),
            new(new[] { "error_type:network" }),
            new(new[] { "error_type:status_code" }),
            new(new[] { "error_type:status_code_4xx_response" }),
            new(new[] { "error_type:status_code_5xx_response" }),
            // git_requests.settings_response, index = 249
            new(null),
            new(new[] { "coverage_enabled" }),
            new(new[] { "itrskip_enabled" }),
            new(new[] { "coverage_enabled", "itrskip_enabled" }),
            new(new[] { "early_flake_detection_enabled:true" }),
            new(new[] { "coverage_enabled", "early_flake_detection_enabled:true" }),
            new(new[] { "itrskip_enabled", "early_flake_detection_enabled:true" }),
            new(new[] { "coverage_enabled", "itrskip_enabled", "early_flake_detection_enabled:true" }),
            // itr_skippable_tests.request, index = 257
            new(null),
            // itr_skippable_tests.request_errors, index = 258
            new(new[] { "error_type:timeout" }),
            new(new[] { "error_type:network" }),
            new(new[] { "error_type:status_code" }),
            new(new[] { "error_type:status_code_4xx_response" }),
            new(new[] { "error_type:status_code_5xx_response" }),
            // itr_skippable_tests.response_tests, index = 263
            new(null),
            // itr_skippable_tests.response_suites, index = 264
            new(null),
            // itr_skipped, index = 265
            new(new[] { "event_type:test" }),
            new(new[] { "event_type:suite" }),
            new(new[] { "event_type:module" }),
            new(new[] { "event_type:session" }),
            // itr_unskippable, index = 269
            new(new[] { "event_type:test" }),
            new(new[] { "event_type:suite" }),
            new(new[] { "event_type:module" }),
            new(new[] { "event_type:session" }),
            // itr_forced_run, index = 273
            new(new[] { "event_type:test" }),
            new(new[] { "event_type:suite" }),
            new(new[] { "event_type:module" }),
            new(new[] { "event_type:session" }),
            // code_coverage.is_empty, index = 277
            new(null),
            // code_coverage.errors, index = 278
            new(null),
            // early_flake_detection.request, index = 279
            new(null),
            // early_flake_detection.request_errors, index = 280
            new(new[] { "error_type:timeout" }),
            new(new[] { "error_type:network" }),
            new(new[] { "error_type:status_code" }),
            new(new[] { "error_type:status_code_4xx_response" }),
            new(new[] { "error_type:status_code_5xx_response" }),
        };

    /// <summary>
    /// Gets an array of metric counts, indexed by integer value of the <see cref="Datadog.Trace.Telemetry.Metrics.CountCIVisibility" />.
    /// Each value represents the number of unique entries in the buffer returned by <see cref="GetCountCIVisibilityBuffer()" />
    /// It is equal to the cardinality of the tag combinations (or 1 if there are no tags)
    /// </summary>
    private static int[] CountCIVisibilityEntryCounts { get; }
        = new int[]{ 40, 80, 10, 10, 4, 1, 2, 10, 2, 9, 63, 1, 5, 1, 5, 1, 5, 8, 1, 5, 1, 1, 4, 4, 4, 1, 1, 1, 5, };

    public void RecordCountCIVisibilityEventCreated(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventTypeWithCodeOwnerAndSupportedCiAndBenchmark tag2, int increment = 1)
    {
        var index = 0 + ((int)tag1 * 8) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityEventFinished(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventTypeWithCodeOwnerAndSupportedCiAndBenchmarkAndEarlyFlakeDetectionAndRum tag2, int increment = 1)
    {
        var index = 40 + ((int)tag1 * 16) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageStarted(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCoverageLibrary tag2, int increment = 1)
    {
        var index = 120 + ((int)tag1 * 2) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageFinished(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCoverageLibrary tag2, int increment = 1)
    {
        var index = 130 + ((int)tag1 * 2) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityManualApiEvent(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 140 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityEventsEnqueueForSerialization(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[144], increment);
    }

    public void RecordCountCIVisibilityEndpointPayloadRequests(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityEndpoints tag, int increment = 1)
    {
        var index = 145 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityEndpointPayloadRequestsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityEndpoints tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag2, int increment = 1)
    {
        var index = 147 + ((int)tag1 * 5) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityEndpointPayloadDropped(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityEndpoints tag, int increment = 1)
    {
        var index = 157 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitCommand(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCommands tag, int increment = 1)
    {
        var index = 159 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitCommandErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCommands tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityExitCodes tag2, int increment = 1)
    {
        var index = 168 + ((int)tag1 * 7) + (int)tag2;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSearchCommits(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[231], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSearchCommitsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 232 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsObjectsPack(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[237], increment);
    }

    public void RecordCountCIVisibilityGitRequestsObjectsPackErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 238 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettings(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[243], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettingsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 244 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettingsResponse(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityITRSettingsResponse tag, int increment = 1)
    {
        var index = 249 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsRequest(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[257], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsRequestErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 258 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsResponseTests(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[263], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsResponseSuites(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[264], increment);
    }

    public void RecordCountCIVisibilityITRSkipped(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 265 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityITRUnskippable(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 269 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityITRForcedRun(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 273 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageIsEmpty(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[277], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageErrors(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[278], increment);
    }

    public void RecordCountCIVisibilityEarlyFlakeDetectionRequest(int increment = 1)
    {
        Interlocked.Add(ref _buffer.CountCIVisibility[279], increment);
    }

    public void RecordCountCIVisibilityEarlyFlakeDetectionRequestErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 280 + (int)tag;
        Interlocked.Add(ref _buffer.CountCIVisibility[index], increment);
    }
}