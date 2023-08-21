// <copyright file="IastMetricsLogLevel.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
#nullable enable

using System.ComponentModel;

namespace Datadog.Trace.Iast.Telemetry;

/// <summary>
/// The unified log levels to use with direct submission
/// </summary>
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public enum IastMetricsLogLevel
{
    /// <summary>
    /// Debug
    /// </summary>
    Debug = 0,

    /// <summary>
    /// The default log level
    /// </summary>
    Information = 1,

    /// <summary>
    /// Only mandatory metrics
    /// </summary>
    Mandatory = 2,

    /// <summary>
    /// Disabled
    /// </summary>
    Off = 3,
}
