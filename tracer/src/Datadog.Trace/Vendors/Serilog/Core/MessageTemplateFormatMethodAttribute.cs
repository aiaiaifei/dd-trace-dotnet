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
namespace Datadog.Trace.Vendors.Serilog.Core;

/// <summary>
/// Indicates that the marked method logs data using a message template and (optional) arguments.
/// The name of the parameter which contains the message template should be given in the constructor.
/// </summary>
/// <example>
/// <code>
/// [MessageTemplateFormatMethod("messageTemplate")]
/// public void Information(string messageTemplate, params object[] propertyValues)
/// {
///     // Do something
/// }
///
/// public void Foo()
/// {
///     Information("Hello, {Name}!") // Warning: Non-existing argument in message template.
/// }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
internal sealed class MessageTemplateFormatMethodAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageTemplateFormatMethodAttribute"/> class.
    /// </summary>
    /// <param name="messageTemplateParameterName">Name of the message template parameter.</param>
    public MessageTemplateFormatMethodAttribute(string messageTemplateParameterName)
    {
        MessageTemplateParameterName = messageTemplateParameterName;
    }

    /// <summary>
    /// Gets the name of the message template parameter.
    /// </summary>
    /// <value>The name of the message template parameter.</value>
    public string MessageTemplateParameterName { get; private set; }
}
