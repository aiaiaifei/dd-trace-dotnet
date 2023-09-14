// <copyright file="RegistryService.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

#nullable enable

namespace Datadog.Trace.Tools.Runner.Checks.Windows
{
    internal class RegistryService : IRegistryService
    {
        private readonly RegistryKey? _localMachine;

        public RegistryService(RegistryKey? localMachine = null)
        {
            if (RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                _localMachine = localMachine ?? Registry.LocalMachine;
            }
        }

        public string[] GetLocalMachineValueNames(string key)
        {
            if (!RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                return Array.Empty<string>();
            }

            var registryKey = Registry.LocalMachine.OpenSubKey(key);

            if (registryKey == null)
            {
                return Array.Empty<string>();
            }

            return registryKey.GetValueNames();
        }

        public string? GetLocalMachineValue(string key)
        {
            if (!RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                return null;
            }

            var registryKey = Registry.LocalMachine.OpenSubKey(key);

            return registryKey?.GetValue(null) as string;
        }

        public bool GetLocalMachineSubKeyVersion(string key, string displayName, out string? tracerVersion)
        {
            tracerVersion = null;
            var versionFound = false;

            if (!RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                return versionFound;
            }

            var registryKey = _localMachine?.OpenSubKey(key);

            if (registryKey != null)
            {
                foreach (var subKeyName in registryKey.GetSubKeyNames())
                {
                    var subKey = registryKey.OpenSubKey(subKeyName);
                    var subKeyDisplayName = subKey?.GetValue("DisplayName");

                    if (subKeyDisplayName?.ToString() == displayName)
                    {
                        tracerVersion = subKey?.GetValue("VersionMajor") + "." + subKey?.GetValue("VersionMinor");
                        versionFound = true;
                    }
                }
            }

            return versionFound;
        }
    }
}
