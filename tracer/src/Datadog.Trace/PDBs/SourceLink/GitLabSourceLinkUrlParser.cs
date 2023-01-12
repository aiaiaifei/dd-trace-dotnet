// <copyright file="GitLabSourceLinkUrlParser.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System;

namespace Datadog.Trace.Pdb.SourceLink;

internal class GitLabSourceLinkUrlParser : SourceLinkUrlParser
{
    /// <summary>
    /// Extract the git commit sha and repository url from a GitLab SourceLink mapping string.
    /// For example, for the following SourceLink mapping string:
    ///     https://test-gitlab-domain/test-org/test-repo/raw/dd35903c688a74b62d1c6a9e4f41371c65704db8/*
    /// It will return:
    ///     - commit sha: dd35903c688a74b62d1c6a9e4f41371c65704db8
    ///     - repository URL: https://test-gitlab-domain/test-org/test-repo
    /// </summary>
    internal override bool ParseSourceLinkUrl(Uri uri, out string? commitSha, out string? repositoryUrl)
    {
        var segments = uri.AbsolutePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        if (segments.Length != 5 || segments[2] != "raw" || segments[4] != "*" || !IsValidCommitSha(segments[3]))
        {
            commitSha = null;
            repositoryUrl = null;
            return false;
        }

        repositoryUrl = $"{uri.Scheme}://{uri.Authority}/{segments[0]}/{segments[1]}";
        commitSha = segments[3];
        return true;
    }
}
