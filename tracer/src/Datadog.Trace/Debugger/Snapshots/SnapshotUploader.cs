// <copyright file="SnapshotUploader.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Text;
using System.Threading.Tasks;

namespace Datadog.Trace.Debugger.Snapshots
{
    internal class SnapshotUploader
    {
        private readonly ISnapshotApi _api;

        private SnapshotUploader(ISnapshotApi api)
        {
            _api = api;
        }

        public static SnapshotUploader Create(ISnapshotApi api)
        {
            return new SnapshotUploader(api);
        }

        public async Task UploadSnapshot(string snapshot)
        {
            var arraySegment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(snapshot));
            await _api.SendSnapshotsAsync(arraySegment).ConfigureAwait(false);
        }
    }
}
