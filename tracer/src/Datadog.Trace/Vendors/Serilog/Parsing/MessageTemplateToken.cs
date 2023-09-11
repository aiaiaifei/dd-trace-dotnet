//------------------------------------------------------------------------------
// <auto-generated />
// This file was automatically generated by the UpdateVendors tool.
//------------------------------------------------------------------------------
#pragma warning disable CS0618, CS0649, CS1574, CS1580, CS1581, CS1584, CS1591, CS1573, CS8018, SYSLIB0011, SYSLIB0032
#nullable enable
using global::System;
using global::System.Collections.Generic;
using global::System.IO;
using global::System.Linq;
#if !NETFRAMEWORK
using global::System.Net.Http;
#endif
using global::System.Threading;
using global::System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Datadog.Trace.Vendors.Serilog.Capturing;
using Datadog.Trace.Vendors.Serilog.Configuration;
using Datadog.Trace.Vendors.Serilog.Context;
using Datadog.Trace.Vendors.Serilog.Core;
using Datadog.Trace.Vendors.Serilog.Core.Enrichers;
using Datadog.Trace.Vendors.Serilog.Core.Filters;
using Datadog.Trace.Vendors.Serilog.Core.Pipeline;
using Datadog.Trace.Vendors.Serilog.Core.Sinks;
using Datadog.Trace.Vendors.Serilog.Data;
using Datadog.Trace.Vendors.Serilog.Debugging;
using Datadog.Trace.Vendors.Serilog.Events;
using Datadog.Trace.Vendors.Serilog.Formatting.Json;
using Datadog.Trace.Vendors.Serilog.Parsing;
using Datadog.Trace.Vendors.Serilog.Policies;
using Datadog.Trace.Vendors.Serilog.Rendering;
using Datadog.Trace.Vendors.Serilog.Settings.KeyValuePairs;
// Copyright 2013-2015 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Datadog.Trace.Vendors.Serilog.Parsing;

/// <summary>
/// An element parsed from a message template string.
/// </summary>
internal abstract class MessageTemplateToken
{
    /// <summary>
    /// The token's length.
    /// </summary>
    public abstract int Length { get; }

    /// <summary>
    /// Render the token to the output.
    /// </summary>
    /// <param name="properties">Properties that may be represented by the token.</param>
    /// <param name="output">Output for the rendered string.</param>
    /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
    // ReSharper disable once UnusedMemberInSuper.Global
    public abstract void Render(IReadOnlyDictionary<string, LogEventPropertyValue> properties, TextWriter output, IFormatProvider? formatProvider = null);
}
