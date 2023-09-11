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

namespace Datadog.Trace.Vendors.Serilog.Formatting;

/// <summary>
/// Formats log events in a textual representation.
/// </summary>
internal interface ITextFormatter
{
    /// <summary>
    /// Format the log event into the output.
    /// </summary>
    /// <param name="logEvent">The event to format.</param>
    /// <param name="output">The output.</param>
    void Format(LogEvent logEvent, TextWriter output);
}
