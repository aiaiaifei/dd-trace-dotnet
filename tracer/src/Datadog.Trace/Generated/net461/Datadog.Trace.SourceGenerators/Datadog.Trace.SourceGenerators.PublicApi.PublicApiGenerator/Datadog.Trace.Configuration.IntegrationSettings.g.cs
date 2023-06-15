﻿// <auto-generated/>
#nullable enable

namespace Datadog.Trace.Configuration;
partial class IntegrationSettings
{

        /// <summary>
        /// Gets the name of the integration. Used to retrieve integration-specific settings.
        /// </summary>
    [Datadog.Trace.SourceGenerators.PublicApi]
    public string IntegrationName
    {
        get
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)64);
            return IntegrationNameInternal;
        }
    }

#pragma warning disable SA1624 // Documentation summary should begin with "Gets" - the documentation is primarily for public property
        /// <summary>
        /// Gets or sets a value indicating whether
        /// this integration is enabled.
        /// </summary>
    [Datadog.Trace.SourceGenerators.PublicApi]
    public bool? Enabled
    {
        get
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)62);
            return EnabledInternal;
        }
        set
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)63);
            EnabledInternal = value;
        }
    }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// Analytics are enabled for this integration.
        /// </summary>
    [Datadog.Trace.SourceGenerators.PublicApi]
    public bool? AnalyticsEnabled
    {
        get
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)58);
            return AnalyticsEnabledInternal;
        }
        set
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)59);
            AnalyticsEnabledInternal = value;
        }
    }

        /// <summary>
        /// Gets or sets a value between 0 and 1 (inclusive)
        /// that determines the sampling rate for this integration.
        /// </summary>
    [Datadog.Trace.SourceGenerators.PublicApi]
    public double AnalyticsSampleRate
    {
        get
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)60);
            return AnalyticsSampleRateInternal;
        }
        set
        {
            Datadog.Trace.Telemetry.TelemetryFactory.Metrics.Record(
                (Datadog.Trace.Telemetry.Metrics.PublicApiUsage)61);
            AnalyticsSampleRateInternal = value;
        }
    }
}