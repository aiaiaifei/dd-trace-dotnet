﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Datadog.Trace.Telemetry.Metrics;
using Datadog.Trace.Util;

namespace Datadog.Trace.Telemetry;

internal partial class CiVisibilityMetricsTelemetryCollector
{
    private readonly Lazy<AggregatedMetrics> _aggregated = new();
    private MetricBuffer _buffer = new();
    private MetricBuffer _reserveBuffer = new();

    public void Record(PublicApiUsage publicApi)
    {
        // This can technically overflow, but it's _very_ unlikely as we reset every 10s
        // Negative values are normalized during polling
        Interlocked.Increment(ref _buffer.PublicApiCounts[(int)publicApi]);
    }

    internal override void Clear()
    {
        _reserveBuffer.Clear();
        var buffer = Interlocked.Exchange(ref _buffer, _reserveBuffer);
        buffer.Clear();
    }

    public MetricResults GetMetrics()
    {
        List<MetricData>? metricData;
        List<DistributionMetricData>? distributionData;

        var aggregated = _aggregated.Value;
        lock (aggregated)
        {
            metricData = GetMetricData(aggregated.PublicApiCounts, aggregated.CountCIVisibility, aggregated.CountShared);
            distributionData = GetDistributionData(aggregated.DistributionCIVisibility, aggregated.DistributionShared);
        }

        return new(metricData, distributionData);
    }

    /// <summary>
    /// Internal for testing
    /// </summary>
    internal override void AggregateMetrics()
    {
        var buffer = Interlocked.Exchange(ref _buffer, _reserveBuffer);

        var aggregated = _aggregated.Value;
        // _aggregated, containing the aggregated metrics, is not thread-safe
        // and is also used when getting the metrics for serialization.
        lock (aggregated)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            AggregateMetric(buffer.PublicApiCounts, timestamp, aggregated.PublicApiCounts);
            AggregateMetric(buffer.CountCIVisibility, timestamp, aggregated.CountCIVisibility);
            AggregateMetric(buffer.CountShared, timestamp, aggregated.CountShared);
            AggregateDistribution(buffer.DistributionCIVisibility, aggregated.DistributionCIVisibility);
            AggregateDistribution(buffer.DistributionShared, aggregated.DistributionShared);
        }

        // prepare the buffer for next time
        buffer.Clear();
        Interlocked.Exchange(ref _reserveBuffer, buffer);
    }

    /// <summary>
    /// Loop through the aggregated data, looking for any metrics that have points
    /// </summary>
    private List<MetricData>? GetMetricData(AggregatedMetric[] publicApis, AggregatedMetric[] countcivisibility, AggregatedMetric[] countshared)
    {
        var apiLength = publicApis.Count(x => x.HasValues);
        var countcivisibilityLength = countcivisibility.Count(x => x.HasValues);
        var countsharedLength = countshared.Count(x => x.HasValues);

        var totalLength = apiLength + countcivisibilityLength + countsharedLength;
        if (totalLength == 0)
        {
            return null;
        }

        var data = new List<MetricData>(totalLength);

        if (apiLength > 0)
        {
            AddPublicApiMetricData(publicApis, data);
        }

        if (countcivisibilityLength > 0)
        {
            AddMetricData("count", countcivisibility, data, CountCIVisibilityEntryCounts, GetCountCIVisibilityDetails);
        }

        if (countsharedLength > 0)
        {
            AddMetricData("count", countshared, data, CountSharedEntryCounts, GetCountSharedDetails);
        }

        return data;
    }

    private List<DistributionMetricData>? GetDistributionData(AggregatedDistribution[] distributioncivisibility, AggregatedDistribution[] distributionshared)
    {
        var distributioncivisibilityLength = distributioncivisibility.Count(x => x.HasValues);
        var distributionsharedLength = distributionshared.Count(x => x.HasValues);

        var totalLength = 0 + distributioncivisibilityLength + distributionsharedLength;
        if (totalLength == 0)
        {
            return null;
        }

        var data = new List<DistributionMetricData>(totalLength);

        if (distributioncivisibilityLength > 0)
        {
            AddDistributionData(distributioncivisibility, data, DistributionCIVisibilityEntryCounts, GetDistributionCIVisibilityDetails);
        }

        if (distributionsharedLength > 0)
        {
            AddDistributionData(distributionshared, data, DistributionSharedEntryCounts, GetDistributionSharedDetails);
        }

        return data;
    }

    private static MetricDetails GetCountCIVisibilityDetails(int i)
    {
        var metric = (CountCIVisibility)i;
        return new MetricDetails(metric.GetName(), metric.GetNamespace(), metric.IsCommon());
    }

    private static MetricDetails GetCountSharedDetails(int i)
    {
        var metric = (CountShared)i;
        return new MetricDetails(metric.GetName(), metric.GetNamespace(), metric.IsCommon());
    }

    private static MetricDetails GetDistributionCIVisibilityDetails(int i)
    {
        var metric = (DistributionCIVisibility)i;
        return new MetricDetails(metric.GetName(), metric.GetNamespace(), metric.IsCommon());
    }

    private static MetricDetails GetDistributionSharedDetails(int i)
    {
        var metric = (DistributionShared)i;
        return new MetricDetails(metric.GetName(), metric.GetNamespace(), metric.IsCommon());
    }

    private class AggregatedMetrics
    {
        public readonly AggregatedMetric[] PublicApiCounts;
        public readonly AggregatedMetric[] CountCIVisibility;
        public readonly AggregatedMetric[] CountShared;
        public readonly AggregatedDistribution[] DistributionCIVisibility;
        public readonly AggregatedDistribution[] DistributionShared;

        public AggregatedMetrics()
        {
            PublicApiCounts = GetPublicApiCountBuffer();
            CountCIVisibility = GetCountCIVisibilityBuffer();
            CountShared = GetCountSharedBuffer();
            DistributionCIVisibility = GetDistributionCIVisibilityBuffer();
            DistributionShared = GetDistributionSharedBuffer();
        }
    }

    protected class MetricBuffer
    {
        public readonly int[] PublicApiCounts;
        public readonly int[] CountCIVisibility;
        public readonly int[] CountShared;
        public readonly BoundedConcurrentQueue<double>[] DistributionCIVisibility;
        public readonly BoundedConcurrentQueue<double>[] DistributionShared;

        public MetricBuffer()
        {
            PublicApiCounts = new int[PublicApiUsageExtensions.Length];
            CountCIVisibility = new int[CountCIVisibilityLength];
            CountShared = new int[CountSharedLength];
            DistributionCIVisibility = new BoundedConcurrentQueue<double>[DistributionCIVisibilityLength];

            for (var i = DistributionCIVisibility.Length - 1; i >= 0; i--)
            {
                DistributionCIVisibility[i] = new BoundedConcurrentQueue<double>(queueLimit: 1000);
            }

            DistributionShared = new BoundedConcurrentQueue<double>[DistributionSharedLength];

            for (var i = DistributionShared.Length - 1; i >= 0; i--)
            {
                DistributionShared[i] = new BoundedConcurrentQueue<double>(queueLimit: 1000);
            }

        }

        public void Clear()
        {
            for (var i = 0; i < PublicApiCounts.Length; i++)
            {
                PublicApiCounts[i] = 0;
            }

            for (var i = 0; i < CountCIVisibility.Length; i++)
            {
                CountCIVisibility[i] = 0;
            }

            for (var i = 0; i < CountShared.Length; i++)
            {
                CountShared[i] = 0;
            }

            for (var i = 0; i < DistributionCIVisibility.Length; i++)
            {
                while (DistributionCIVisibility[i].TryDequeue(out _)) { }
            }

            for (var i = 0; i < DistributionShared.Length; i++)
            {
                while (DistributionShared[i].TryDequeue(out _)) { }
            }
        }
    }
}