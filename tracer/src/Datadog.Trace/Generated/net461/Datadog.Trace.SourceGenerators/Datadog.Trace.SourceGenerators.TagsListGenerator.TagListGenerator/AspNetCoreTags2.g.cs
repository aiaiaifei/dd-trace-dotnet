﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class AspNetCoreTags2
    {
        // AspNetCoreControllerBytes = MessagePack.Serialize("aspnet_core.controller");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCoreControllerBytes => new byte[] { 182, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 99, 111, 110, 116, 114, 111, 108, 108, 101, 114 };
#else
        private static readonly byte[] AspNetCoreControllerBytes = new byte[] { 182, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 99, 111, 110, 116, 114, 111, 108, 108, 101, 114 };
#endif
        // AspNetCoreActionBytes = MessagePack.Serialize("aspnet_core.action");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCoreActionBytes => new byte[] { 178, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 97, 99, 116, 105, 111, 110 };
#else
        private static readonly byte[] AspNetCoreActionBytes = new byte[] { 178, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 97, 99, 116, 105, 111, 110 };
#endif
        // AspNetCoreAreaBytes = MessagePack.Serialize("aspnet_core.area");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCoreAreaBytes => new byte[] { 176, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 97, 114, 101, 97 };
#else
        private static readonly byte[] AspNetCoreAreaBytes = new byte[] { 176, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 97, 114, 101, 97 };
#endif
        // AspNetCorePageBytes = MessagePack.Serialize("aspnet_core.page");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCorePageBytes => new byte[] { 176, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 112, 97, 103, 101 };
#else
        private static readonly byte[] AspNetCorePageBytes = new byte[] { 176, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 112, 97, 103, 101 };
#endif
        // InstrumentationNameBytes = MessagePack.Serialize("component");
#if NETCOREAPP
        private static ReadOnlySpan<byte> InstrumentationNameBytes => new byte[] { 169, 99, 111, 109, 112, 111, 110, 101, 110, 116 };
#else
        private static readonly byte[] InstrumentationNameBytes = new byte[] { 169, 99, 111, 109, 112, 111, 110, 101, 110, 116 };
#endif
        // AspNetCoreRouteBytes = MessagePack.Serialize("aspnet_core.route");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCoreRouteBytes => new byte[] { 177, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 114, 111, 117, 116, 101 };
#else
        private static readonly byte[] AspNetCoreRouteBytes = new byte[] { 177, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 114, 111, 117, 116, 101 };
#endif
        // AspNetCoreEndpointBytes = MessagePack.Serialize("aspnet_core.endpoint");
#if NETCOREAPP
        private static ReadOnlySpan<byte> AspNetCoreEndpointBytes => new byte[] { 180, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 101, 110, 100, 112, 111, 105, 110, 116 };
#else
        private static readonly byte[] AspNetCoreEndpointBytes = new byte[] { 180, 97, 115, 112, 110, 101, 116, 95, 99, 111, 114, 101, 46, 101, 110, 100, 112, 111, 105, 110, 116 };
#endif
        // HttpRouteBytes = MessagePack.Serialize("http.route");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpRouteBytes => new byte[] { 170, 104, 116, 116, 112, 46, 114, 111, 117, 116, 101 };
#else
        private static readonly byte[] HttpRouteBytes = new byte[] { 170, 104, 116, 116, 112, 46, 114, 111, 117, 116, 101 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "aspnet_core.controller" => AspNetCoreController,
                "aspnet_core.action" => AspNetCoreAction,
                "aspnet_core.area" => AspNetCoreArea,
                "aspnet_core.page" => AspNetCorePage,
                "component" => InstrumentationName,
                "aspnet_core.route" => AspNetCoreRoute,
                "aspnet_core.endpoint" => AspNetCoreEndpoint,
                "http.route" => HttpRoute,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "aspnet_core.controller": 
                    AspNetCoreController = value;
                    break;
                case "aspnet_core.action": 
                    AspNetCoreAction = value;
                    break;
                case "aspnet_core.area": 
                    AspNetCoreArea = value;
                    break;
                case "aspnet_core.page": 
                    AspNetCorePage = value;
                    break;
                case "aspnet_core.route": 
                    AspNetCoreRoute = value;
                    break;
                case "aspnet_core.endpoint": 
                    AspNetCoreEndpoint = value;
                    break;
                case "http.route": 
                    HttpRoute = value;
                    break;
                case "component": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(AspNetCoreTags2));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (AspNetCoreController is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.controller", AspNetCoreController, AspNetCoreControllerBytes));
            }

            if (AspNetCoreAction is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.action", AspNetCoreAction, AspNetCoreActionBytes));
            }

            if (AspNetCoreArea is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.area", AspNetCoreArea, AspNetCoreAreaBytes));
            }

            if (AspNetCorePage is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.page", AspNetCorePage, AspNetCorePageBytes));
            }

            if (InstrumentationName is not null)
            {
                processor.Process(new TagItem<string>("component", InstrumentationName, InstrumentationNameBytes));
            }

            if (AspNetCoreRoute is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.route", AspNetCoreRoute, AspNetCoreRouteBytes));
            }

            if (AspNetCoreEndpoint is not null)
            {
                processor.Process(new TagItem<string>("aspnet_core.endpoint", AspNetCoreEndpoint, AspNetCoreEndpointBytes));
            }

            if (HttpRoute is not null)
            {
                processor.Process(new TagItem<string>("http.route", HttpRoute, HttpRouteBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (AspNetCoreController is not null)
            {
                sb.Append("aspnet_core.controller (tag):")
                  .Append(AspNetCoreController)
                  .Append(',');
            }

            if (AspNetCoreAction is not null)
            {
                sb.Append("aspnet_core.action (tag):")
                  .Append(AspNetCoreAction)
                  .Append(',');
            }

            if (AspNetCoreArea is not null)
            {
                sb.Append("aspnet_core.area (tag):")
                  .Append(AspNetCoreArea)
                  .Append(',');
            }

            if (AspNetCorePage is not null)
            {
                sb.Append("aspnet_core.page (tag):")
                  .Append(AspNetCorePage)
                  .Append(',');
            }

            if (InstrumentationName is not null)
            {
                sb.Append("component (tag):")
                  .Append(InstrumentationName)
                  .Append(',');
            }

            if (AspNetCoreRoute is not null)
            {
                sb.Append("aspnet_core.route (tag):")
                  .Append(AspNetCoreRoute)
                  .Append(',');
            }

            if (AspNetCoreEndpoint is not null)
            {
                sb.Append("aspnet_core.endpoint (tag):")
                  .Append(AspNetCoreEndpoint)
                  .Append(',');
            }

            if (HttpRoute is not null)
            {
                sb.Append("http.route (tag):")
                  .Append(HttpRoute)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}