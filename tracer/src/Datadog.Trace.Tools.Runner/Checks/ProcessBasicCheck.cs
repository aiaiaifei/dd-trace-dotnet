// <copyright file="ProcessBasicCheck.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using Spectre.Console;

using static Datadog.Trace.Tools.Runner.Checks.Resources;

namespace Datadog.Trace.Tools.Runner.Checks
{
    internal class ProcessBasicCheck
    {
        public const string ClsidKey = $@"SOFTWARE\Classes\CLSID\{Utils.Profilerid}\InprocServer32";
        public const string Clsid32Key = $@"SOFTWARE\Classes\Wow6432Node\CLSID\{Utils.Profilerid}\InprocServer32";

        public static readonly string NativeTracerFileName;
        public static readonly string NativeLoaderFileName;

        static ProcessBasicCheck()
        {
            string extension;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                extension = ".dll";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                extension = ".so";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                extension = ".dylib";
            }
            else
            {
                // unsupported platform, should never happen
                extension = string.Empty;
            }

            NativeTracerFileName = "Datadog.Trace.ClrProfiler.Native" + extension;
            NativeLoaderFileName = "Datadog.AutoInstrumentation.NativeLoader" + extension;
        }

        public static bool Run(ProcessInfo process, IRegistryService? registryService = null)
        {
            bool ok = true;
            var runtime = process.DotnetRuntime;

            if (runtime == ProcessInfo.Runtime.NetFx)
            {
                AnsiConsole.WriteLine(NetFrameworkRuntime);
            }
            else if (runtime == ProcessInfo.Runtime.NetCore)
            {
                AnsiConsole.WriteLine(NetCoreRuntime);
            }
            else
            {
                Utils.WriteWarning(runtime == ProcessInfo.Runtime.Mixed ? BothRuntimesDetected : RuntimeDetectionFailed);

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    runtime = ProcessInfo.Runtime.NetFx;
                }
                else
                {
                    runtime = ProcessInfo.Runtime.NetCore;
                }
            }

            var profilerModule = FindProfilerModule(process);

            if (profilerModule == null)
            {
                Utils.WriteWarning(ProfilerNotLoaded);
                ok = false;
            }
            else
            {
                // Only check the version of the native binary on Windows
                // .so modules don't have version metadata
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var version = FileVersionInfo.GetVersionInfo(profilerModule);
                    AnsiConsole.WriteLine(NativeLibraryVersion(version.FileVersion ?? "{empty}"));
                }
            }

            var tracerModules = FindTracerModules(process).ToArray();

            if (tracerModules.Length == 0)
            {
                Utils.WriteWarning(TracerNotLoaded);
                ok = false;
            }
            else if (tracerModules.Length == 1)
            {
                var version = FileVersionInfo.GetVersionInfo(tracerModules[0]);
                AnsiConsole.WriteLine(ManagedLibraryVersion(version.FileVersion ?? "{empty}"));
            }
            else if (tracerModules.Length > 1)
            {
                // There are too many tracers in there. Find out if it's bad or very bad
                bool areAllVersion2 = true;
                var versions = new HashSet<string>();

                foreach (var tracer in tracerModules)
                {
                    var version = FileVersionInfo.GetVersionInfo(tracer);

                    versions.Add(version.FileVersion ?? "{empty}");

                    if (version.FileMajorPart < 2)
                    {
                        areAllVersion2 = false;
                    }
                }

                Utils.WriteWarning(MultipleTracers(versions));

                if (!areAllVersion2)
                {
                    Utils.WriteError(VersionConflict);
                    ok = false;
                }
            }

            if (process.EnvironmentVariables.TryGetValue("DD_DOTNET_TRACER_HOME", out var tracerHome))
            {
                if (!Directory.Exists(tracerHome))
                {
                    Utils.WriteError(TracerHomeNotFoundFormat(tracerHome));
                    ok = false;
                }
            }
            else
            {
                Utils.WriteError(EnvironmentVariableNotSet("DD_DOTNET_TRACER_HOME"));
                ok = false;
            }

            string corProfilerKey = runtime == ProcessInfo.Runtime.NetCore ? "CORECLR_PROFILER" : "COR_PROFILER";

            if (!process.EnvironmentVariables.TryGetValue(corProfilerKey, out var corProfiler) || string.IsNullOrEmpty(corProfiler))
            {
                Utils.WriteError(EnvironmentVariableNotSet(corProfilerKey));
                ok = false;
            }
            else if (corProfiler != Utils.Profilerid)
            {
                Utils.WriteError(WrongEnvironmentVariableFormat(corProfilerKey, Utils.Profilerid, corProfiler));
                ok = false;
            }

            string corEnableKey = runtime == ProcessInfo.Runtime.NetCore ? "CORECLR_ENABLE_PROFILING" : "COR_ENABLE_PROFILING";

            if (!process.EnvironmentVariables.TryGetValue(corEnableKey, out var corEnable) || string.IsNullOrEmpty(corEnable))
            {
                Utils.WriteError(EnvironmentVariableNotSet(corEnableKey));
                ok = false;
            }
            else if (corEnable != "1")
            {
                Utils.WriteError(WrongEnvironmentVariableFormat(corEnableKey, "1", corEnable));
                ok = false;
            }

            // on Windows, profiler paths are not required, but we need to validate them if they are present
            bool profilerPathRequired = !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            // validate any profiler paths found in environment variables
            ok &= CheckProfilerPathEnvVars(process, runtime, profilerPathRequired);

            // on Windows, validate keys in the Windows Registry
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!CheckRegistry(process.Architecture, registryService))
                {
                    ok = false;
                }
            }

            return ok;
        }

        internal static bool CheckRegistry(Architecture? processArchitecture, IRegistryService? registry = null)
        {
            registry ??= new Windows.RegistryService();

            try
            {
                bool ok = true;

                // Check that the profiler is properly registered
                ok &= CheckClsid(processArchitecture, registry, ClsidKey);

                if (RuntimeInformation.OSArchitecture == Architecture.X64)
                {
                    // check the Registry keys used for x86 apps in x64 OS
                    ok &= CheckClsid(processArchitecture, registry, Clsid32Key);
                }

                // Look for registry keys that could have been set by other profilers
                var suspiciousNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "COR_ENABLE_PROFILING",
                    "CORECLR_ENABLE_PROFILING",
                    "COR_PROFILER",
                    "CORECLR_PROFILER",
                    "COR_PROFILER_PATH",
                    "CORECLR_PROFILER_PATH",
                    "COR_PROFILER_PATH_64",
                    "CORECLR_PROFILER_PATH_64",
                    "COR_PROFILER_PATH_32",
                    "CORECLR_PROFILER_PATH_32"
                };

                bool foundKey = false;

                var parentKeys = new[] { @"SOFTWARE\Microsoft\.NETFramework", @"SOFTWARE\WOW6432Node\Microsoft\.NETFramework" };

                foreach (var parentKey in parentKeys)
                {
                    foreach (var name in registry.GetLocalMachineValueNames(parentKey))
                    {
                        if (suspiciousNames.Contains(name))
                        {
                            Utils.WriteWarning(SuspiciousRegistryKey(parentKey, name));
                            foundKey = true;
                        }
                    }
                }

                ok &= !foundKey;

                return ok;
            }
            catch (Exception ex)
            {
                Utils.WriteError(ErrorCheckingRegistry(), ex);
                return true;
            }
        }

        private static bool CheckProfilerPathEnvVars(ProcessInfo process, ProcessInfo.Runtime runtime, bool required)
        {
            var keys = (runtime, process.Architecture) switch
                       {
                           (ProcessInfo.Runtime.NetFx, Architecture.X64) => new[] { "COR_PROFILER_PATH_64", "COR_PROFILER_PATH" },
                           (ProcessInfo.Runtime.NetFx, Architecture.X86) => new[] { "COR_PROFILER_PATH_32", "COR_PROFILER_PATH" },
                           (ProcessInfo.Runtime.NetCore, Architecture.X64) => new[] { "CORECLR_PROFILER_PATH_64", "CORECLR_PROFILER_PATH" },
                           (ProcessInfo.Runtime.NetCore, Architecture.X86) => new[] { "CORECLR_PROFILER_PATH_32", "CORECLR_PROFILER_PATH" },
                           (ProcessInfo.Runtime.NetCore, Architecture.Arm64) => new[] { "CORECLR_PROFILER_PATH_ARM64", "CORECLR_PROFILER_PATH" },
                           _ => Array.Empty<string>() // TODO: warn about unsupported runtime/architecture combination?
                       };

            bool ok = true;
            bool envSet = false;

            foreach (var key in keys)
            {
                if (process.EnvironmentVariables.TryGetValue(key, out var profilerPath))
                {
                    envSet = true;

                    if (!IsValidNativeLibraryFile(process.Architecture, profilerPath, ValueSource.EnvironmentVariable, key))
                    {
                        ok = false;
                    }
                }
            }

            if (required && !envSet)
            {
                Utils.WriteError(EnvironmentVariableNotSet(keys));
                ok = false;
            }

            return ok;
        }

        private static bool CheckClsid(Architecture? processArchitecture, IRegistryService registry, string registryKey)
        {
            var profilerPath = registry.GetLocalMachineValue(registryKey);

            if (profilerPath == null)
            {
                Utils.WriteWarning(MissingRegistryKey(registryKey));
                return false;
            }

            if (!IsValidNativeLibraryFile(processArchitecture, profilerPath, ValueSource.WindowsRegistry, registryKey))
            {
                return false;
            }

            return true;
        }

        internal static bool IsValidNativeLibraryFile(Architecture? processArchitecture, string nativeLibraryPath, ValueSource pathSource, string sourceKey)
        {
            bool ok = true;
            var nativeLibraryFileName = Path.GetFileName(nativeLibraryPath);

            // check for expected filename
            if (!IsExpectedNativeLibraryFileName(nativeLibraryFileName))
            {
                Utils.WriteError(WrongNativeLibraryFileName(pathSource, sourceKey, nativeLibraryPath));
                ok = false;
            }

            // check if file exists
            if (!File.Exists(nativeLibraryPath))
            {
                Utils.WriteError(MissingNativeLibrary(pathSource, sourceKey, nativeLibraryPath));
                ok = false;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // if file exists, check that its architecture matches the target process (Windows only)
                var profilerArchitecture = GetNativeLibraryArchitecture(nativeLibraryPath);

                if (profilerArchitecture == null)
                {
                    Utils.WriteWarning(CannotDetermineNativeLibraryArchitecture(nativeLibraryPath));
                    ok = false;
                }
                else if (processArchitecture != null && processArchitecture != profilerArchitecture)
                {
                    Utils.WriteError(MismatchedArchitecture(nativeLibraryPath, profilerArchitecture.Value, processArchitecture.Value));
                    ok = false;
                }
            }

            return ok;
        }

        internal static bool IsExpectedNativeLibraryFileName(string fileName)
        {
            // Paths are only case-insensitive on Windows
            var stringComparison = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return fileName.Equals(NativeTracerFileName, stringComparison) || fileName.Equals(NativeLoaderFileName, stringComparison);
        }

        internal static Architecture? GetNativeLibraryArchitecture(string profilerPath)
        {
            if (Windows.PortableExecutable.TryGetPEHeaders(profilerPath, out var profilerPEHeaders) &&
                profilerPEHeaders is { IsDll: true, IsCoffOnly: false, CorHeader: null })
            {
                return (profilerPEHeaders.CoffHeader?.Machine, profilerPEHeaders.PEHeader?.Magic) switch
                       {
                           (Machine.Amd64, PEMagic.PE32Plus) => Architecture.X64,
                           (Machine.I386, PEMagic.PE32) => Architecture.X86,
                           (Machine.Arm64, PEMagic.PE32Plus) => Architecture.Arm64,
                           _ => null
                       };
            }

            return null;
        }

        private static string? FindProfilerModule(ProcessInfo process)
        {
            foreach (var module in process.Modules)
            {
                var fileName = Path.GetFileName(module);

                if (fileName.Equals(NativeTracerFileName, StringComparison.OrdinalIgnoreCase))
                {
                    return module;
                }
            }

            return null;
        }

        private static IEnumerable<string> FindTracerModules(ProcessInfo process)
        {
            foreach (var module in process.Modules)
            {
                var fileName = Path.GetFileName(module);

                if (fileName.Equals("Datadog.Trace.dll", StringComparison.OrdinalIgnoreCase))
                {
                    yield return module;
                }
            }
        }
    }
}
