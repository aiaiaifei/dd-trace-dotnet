﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Ci.Tagging
{
    partial class TestSessionSpanTags
    {
        // CommandBytes = MessagePack.Serialize("test.command");
        private static ReadOnlySpan<byte> CommandBytes => new byte[] { 172, 116, 101, 115, 116, 46, 99, 111, 109, 109, 97, 110, 100 };
        // WorkingDirectoryBytes = MessagePack.Serialize("test.working_directory");
        private static ReadOnlySpan<byte> WorkingDirectoryBytes => new byte[] { 182, 116, 101, 115, 116, 46, 119, 111, 114, 107, 105, 110, 103, 95, 100, 105, 114, 101, 99, 116, 111, 114, 121 };
        // CommandExitCodeBytes = MessagePack.Serialize("test.exit_code");
        private static ReadOnlySpan<byte> CommandExitCodeBytes => new byte[] { 174, 116, 101, 115, 116, 46, 101, 120, 105, 116, 95, 99, 111, 100, 101 };
        // StatusBytes = MessagePack.Serialize("test.status");
        private static ReadOnlySpan<byte> StatusBytes => new byte[] { 171, 116, 101, 115, 116, 46, 115, 116, 97, 116, 117, 115 };
        // LibraryVersionBytes = MessagePack.Serialize("library_version");
        private static ReadOnlySpan<byte> LibraryVersionBytes => new byte[] { 175, 108, 105, 98, 114, 97, 114, 121, 95, 118, 101, 114, 115, 105, 111, 110 };
        // CIProviderBytes = MessagePack.Serialize("ci.provider.name");
        private static ReadOnlySpan<byte> CIProviderBytes => new byte[] { 176, 99, 105, 46, 112, 114, 111, 118, 105, 100, 101, 114, 46, 110, 97, 109, 101 };
        // CIPipelineIdBytes = MessagePack.Serialize("ci.pipeline.id");
        private static ReadOnlySpan<byte> CIPipelineIdBytes => new byte[] { 174, 99, 105, 46, 112, 105, 112, 101, 108, 105, 110, 101, 46, 105, 100 };
        // CIPipelineNameBytes = MessagePack.Serialize("ci.pipeline.name");
        private static ReadOnlySpan<byte> CIPipelineNameBytes => new byte[] { 176, 99, 105, 46, 112, 105, 112, 101, 108, 105, 110, 101, 46, 110, 97, 109, 101 };
        // CIPipelineNumberBytes = MessagePack.Serialize("ci.pipeline.number");
        private static ReadOnlySpan<byte> CIPipelineNumberBytes => new byte[] { 178, 99, 105, 46, 112, 105, 112, 101, 108, 105, 110, 101, 46, 110, 117, 109, 98, 101, 114 };
        // CIPipelineUrlBytes = MessagePack.Serialize("ci.pipeline.url");
        private static ReadOnlySpan<byte> CIPipelineUrlBytes => new byte[] { 175, 99, 105, 46, 112, 105, 112, 101, 108, 105, 110, 101, 46, 117, 114, 108 };
        // CIJobUrlBytes = MessagePack.Serialize("ci.job.url");
        private static ReadOnlySpan<byte> CIJobUrlBytes => new byte[] { 170, 99, 105, 46, 106, 111, 98, 46, 117, 114, 108 };
        // CIJobNameBytes = MessagePack.Serialize("ci.job.name");
        private static ReadOnlySpan<byte> CIJobNameBytes => new byte[] { 171, 99, 105, 46, 106, 111, 98, 46, 110, 97, 109, 101 };
        // StageNameBytes = MessagePack.Serialize("ci.stage.name");
        private static ReadOnlySpan<byte> StageNameBytes => new byte[] { 173, 99, 105, 46, 115, 116, 97, 103, 101, 46, 110, 97, 109, 101 };
        // CIWorkspacePathBytes = MessagePack.Serialize("ci.workspace_path");
        private static ReadOnlySpan<byte> CIWorkspacePathBytes => new byte[] { 177, 99, 105, 46, 119, 111, 114, 107, 115, 112, 97, 99, 101, 95, 112, 97, 116, 104 };
        // GitRepositoryBytes = MessagePack.Serialize("git.repository_url");
        private static ReadOnlySpan<byte> GitRepositoryBytes => new byte[] { 178, 103, 105, 116, 46, 114, 101, 112, 111, 115, 105, 116, 111, 114, 121, 95, 117, 114, 108 };
        // GitCommitBytes = MessagePack.Serialize("git.commit.sha");
        private static ReadOnlySpan<byte> GitCommitBytes => new byte[] { 174, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 115, 104, 97 };
        // GitBranchBytes = MessagePack.Serialize("git.branch");
        private static ReadOnlySpan<byte> GitBranchBytes => new byte[] { 170, 103, 105, 116, 46, 98, 114, 97, 110, 99, 104 };
        // GitTagBytes = MessagePack.Serialize("git.tag");
        private static ReadOnlySpan<byte> GitTagBytes => new byte[] { 167, 103, 105, 116, 46, 116, 97, 103 };
        // GitCommitAuthorNameBytes = MessagePack.Serialize("git.commit.author.name");
        private static ReadOnlySpan<byte> GitCommitAuthorNameBytes => new byte[] { 182, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 97, 117, 116, 104, 111, 114, 46, 110, 97, 109, 101 };
        // GitCommitAuthorEmailBytes = MessagePack.Serialize("git.commit.author.email");
        private static ReadOnlySpan<byte> GitCommitAuthorEmailBytes => new byte[] { 183, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 97, 117, 116, 104, 111, 114, 46, 101, 109, 97, 105, 108 };
        // GitCommitCommitterNameBytes = MessagePack.Serialize("git.commit.committer.name");
        private static ReadOnlySpan<byte> GitCommitCommitterNameBytes => new byte[] { 185, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 99, 111, 109, 109, 105, 116, 116, 101, 114, 46, 110, 97, 109, 101 };
        // GitCommitCommitterEmailBytes = MessagePack.Serialize("git.commit.committer.email");
        private static ReadOnlySpan<byte> GitCommitCommitterEmailBytes => new byte[] { 186, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 99, 111, 109, 109, 105, 116, 116, 101, 114, 46, 101, 109, 97, 105, 108 };
        // GitCommitMessageBytes = MessagePack.Serialize("git.commit.message");
        private static ReadOnlySpan<byte> GitCommitMessageBytes => new byte[] { 178, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 109, 101, 115, 115, 97, 103, 101 };
        // BuildSourceRootBytes = MessagePack.Serialize("build.source_root");
        private static ReadOnlySpan<byte> BuildSourceRootBytes => new byte[] { 177, 98, 117, 105, 108, 100, 46, 115, 111, 117, 114, 99, 101, 95, 114, 111, 111, 116 };
        // GitCommitAuthorDateBytes = MessagePack.Serialize("git.commit.author.date");
        private static ReadOnlySpan<byte> GitCommitAuthorDateBytes => new byte[] { 182, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 97, 117, 116, 104, 111, 114, 46, 100, 97, 116, 101 };
        // GitCommitCommitterDateBytes = MessagePack.Serialize("git.commit.committer.date");
        private static ReadOnlySpan<byte> GitCommitCommitterDateBytes => new byte[] { 185, 103, 105, 116, 46, 99, 111, 109, 109, 105, 116, 46, 99, 111, 109, 109, 105, 116, 116, 101, 114, 46, 100, 97, 116, 101 };
        // CiEnvVarsBytes = MessagePack.Serialize("_dd.ci.env_vars");
        private static ReadOnlySpan<byte> CiEnvVarsBytes => new byte[] { 175, 95, 100, 100, 46, 99, 105, 46, 101, 110, 118, 95, 118, 97, 114, 115 };
        // TestsSkippedBytes = MessagePack.Serialize("_dd.ci.itr.tests_skipped");
        private static ReadOnlySpan<byte> TestsSkippedBytes => new byte[] { 184, 95, 100, 100, 46, 99, 105, 46, 105, 116, 114, 46, 116, 101, 115, 116, 115, 95, 115, 107, 105, 112, 112, 101, 100 };
        // IntelligentTestRunnerSkippingTypeBytes = MessagePack.Serialize("test.itr.tests_skipping.type");
        private static ReadOnlySpan<byte> IntelligentTestRunnerSkippingTypeBytes => new byte[] { 188, 116, 101, 115, 116, 46, 105, 116, 114, 46, 116, 101, 115, 116, 115, 95, 115, 107, 105, 112, 112, 105, 110, 103, 46, 116, 121, 112, 101 };
        // EarlyFlakeDetectionTestEnabledBytes = MessagePack.Serialize("test.early_flake.enabled");
        private static ReadOnlySpan<byte> EarlyFlakeDetectionTestEnabledBytes => new byte[] { 184, 116, 101, 115, 116, 46, 101, 97, 114, 108, 121, 95, 102, 108, 97, 107, 101, 46, 101, 110, 97, 98, 108, 101, 100 };
        // EarlyFlakeDetectionTestAbortReasonBytes = MessagePack.Serialize("test.early_flake.abort_reason");
        private static ReadOnlySpan<byte> EarlyFlakeDetectionTestAbortReasonBytes => new byte[] { 189, 116, 101, 115, 116, 46, 101, 97, 114, 108, 121, 95, 102, 108, 97, 107, 101, 46, 97, 98, 111, 114, 116, 95, 114, 101, 97, 115, 111, 110 };

        public override string? GetTag(string key)
        {
            return key switch
            {
                "test.command" => Command,
                "test.working_directory" => WorkingDirectory,
                "test.exit_code" => CommandExitCode,
                "test.status" => Status,
                "library_version" => LibraryVersion,
                "ci.provider.name" => CIProvider,
                "ci.pipeline.id" => CIPipelineId,
                "ci.pipeline.name" => CIPipelineName,
                "ci.pipeline.number" => CIPipelineNumber,
                "ci.pipeline.url" => CIPipelineUrl,
                "ci.job.url" => CIJobUrl,
                "ci.job.name" => CIJobName,
                "ci.stage.name" => StageName,
                "ci.workspace_path" => CIWorkspacePath,
                "git.repository_url" => GitRepository,
                "git.commit.sha" => GitCommit,
                "git.branch" => GitBranch,
                "git.tag" => GitTag,
                "git.commit.author.name" => GitCommitAuthorName,
                "git.commit.author.email" => GitCommitAuthorEmail,
                "git.commit.committer.name" => GitCommitCommitterName,
                "git.commit.committer.email" => GitCommitCommitterEmail,
                "git.commit.message" => GitCommitMessage,
                "build.source_root" => BuildSourceRoot,
                "git.commit.author.date" => GitCommitAuthorDate,
                "git.commit.committer.date" => GitCommitCommitterDate,
                "_dd.ci.env_vars" => CiEnvVars,
                "_dd.ci.itr.tests_skipped" => TestsSkipped,
                "test.itr.tests_skipping.type" => IntelligentTestRunnerSkippingType,
                "test.early_flake.enabled" => EarlyFlakeDetectionTestEnabled,
                "test.early_flake.abort_reason" => EarlyFlakeDetectionTestAbortReason,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "test.command": 
                    Command = value;
                    break;
                case "test.working_directory": 
                    WorkingDirectory = value;
                    break;
                case "test.exit_code": 
                    CommandExitCode = value;
                    break;
                case "test.status": 
                    Status = value;
                    break;
                case "ci.provider.name": 
                    CIProvider = value;
                    break;
                case "ci.pipeline.id": 
                    CIPipelineId = value;
                    break;
                case "ci.pipeline.name": 
                    CIPipelineName = value;
                    break;
                case "ci.pipeline.number": 
                    CIPipelineNumber = value;
                    break;
                case "ci.pipeline.url": 
                    CIPipelineUrl = value;
                    break;
                case "ci.job.url": 
                    CIJobUrl = value;
                    break;
                case "ci.job.name": 
                    CIJobName = value;
                    break;
                case "ci.stage.name": 
                    StageName = value;
                    break;
                case "ci.workspace_path": 
                    CIWorkspacePath = value;
                    break;
                case "git.repository_url": 
                    GitRepository = value;
                    break;
                case "git.commit.sha": 
                    GitCommit = value;
                    break;
                case "git.branch": 
                    GitBranch = value;
                    break;
                case "git.tag": 
                    GitTag = value;
                    break;
                case "git.commit.author.name": 
                    GitCommitAuthorName = value;
                    break;
                case "git.commit.author.email": 
                    GitCommitAuthorEmail = value;
                    break;
                case "git.commit.committer.name": 
                    GitCommitCommitterName = value;
                    break;
                case "git.commit.committer.email": 
                    GitCommitCommitterEmail = value;
                    break;
                case "git.commit.message": 
                    GitCommitMessage = value;
                    break;
                case "build.source_root": 
                    BuildSourceRoot = value;
                    break;
                case "git.commit.author.date": 
                    GitCommitAuthorDate = value;
                    break;
                case "git.commit.committer.date": 
                    GitCommitCommitterDate = value;
                    break;
                case "_dd.ci.env_vars": 
                    CiEnvVars = value;
                    break;
                case "_dd.ci.itr.tests_skipped": 
                    TestsSkipped = value;
                    break;
                case "test.itr.tests_skipping.type": 
                    IntelligentTestRunnerSkippingType = value;
                    break;
                case "test.early_flake.enabled": 
                    EarlyFlakeDetectionTestEnabled = value;
                    break;
                case "test.early_flake.abort_reason": 
                    EarlyFlakeDetectionTestAbortReason = value;
                    break;
                case "library_version": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(TestSessionSpanTags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (Command is not null)
            {
                processor.Process(new TagItem<string>("test.command", Command, CommandBytes));
            }

            if (WorkingDirectory is not null)
            {
                processor.Process(new TagItem<string>("test.working_directory", WorkingDirectory, WorkingDirectoryBytes));
            }

            if (CommandExitCode is not null)
            {
                processor.Process(new TagItem<string>("test.exit_code", CommandExitCode, CommandExitCodeBytes));
            }

            if (Status is not null)
            {
                processor.Process(new TagItem<string>("test.status", Status, StatusBytes));
            }

            if (LibraryVersion is not null)
            {
                processor.Process(new TagItem<string>("library_version", LibraryVersion, LibraryVersionBytes));
            }

            if (CIProvider is not null)
            {
                processor.Process(new TagItem<string>("ci.provider.name", CIProvider, CIProviderBytes));
            }

            if (CIPipelineId is not null)
            {
                processor.Process(new TagItem<string>("ci.pipeline.id", CIPipelineId, CIPipelineIdBytes));
            }

            if (CIPipelineName is not null)
            {
                processor.Process(new TagItem<string>("ci.pipeline.name", CIPipelineName, CIPipelineNameBytes));
            }

            if (CIPipelineNumber is not null)
            {
                processor.Process(new TagItem<string>("ci.pipeline.number", CIPipelineNumber, CIPipelineNumberBytes));
            }

            if (CIPipelineUrl is not null)
            {
                processor.Process(new TagItem<string>("ci.pipeline.url", CIPipelineUrl, CIPipelineUrlBytes));
            }

            if (CIJobUrl is not null)
            {
                processor.Process(new TagItem<string>("ci.job.url", CIJobUrl, CIJobUrlBytes));
            }

            if (CIJobName is not null)
            {
                processor.Process(new TagItem<string>("ci.job.name", CIJobName, CIJobNameBytes));
            }

            if (StageName is not null)
            {
                processor.Process(new TagItem<string>("ci.stage.name", StageName, StageNameBytes));
            }

            if (CIWorkspacePath is not null)
            {
                processor.Process(new TagItem<string>("ci.workspace_path", CIWorkspacePath, CIWorkspacePathBytes));
            }

            if (GitRepository is not null)
            {
                processor.Process(new TagItem<string>("git.repository_url", GitRepository, GitRepositoryBytes));
            }

            if (GitCommit is not null)
            {
                processor.Process(new TagItem<string>("git.commit.sha", GitCommit, GitCommitBytes));
            }

            if (GitBranch is not null)
            {
                processor.Process(new TagItem<string>("git.branch", GitBranch, GitBranchBytes));
            }

            if (GitTag is not null)
            {
                processor.Process(new TagItem<string>("git.tag", GitTag, GitTagBytes));
            }

            if (GitCommitAuthorName is not null)
            {
                processor.Process(new TagItem<string>("git.commit.author.name", GitCommitAuthorName, GitCommitAuthorNameBytes));
            }

            if (GitCommitAuthorEmail is not null)
            {
                processor.Process(new TagItem<string>("git.commit.author.email", GitCommitAuthorEmail, GitCommitAuthorEmailBytes));
            }

            if (GitCommitCommitterName is not null)
            {
                processor.Process(new TagItem<string>("git.commit.committer.name", GitCommitCommitterName, GitCommitCommitterNameBytes));
            }

            if (GitCommitCommitterEmail is not null)
            {
                processor.Process(new TagItem<string>("git.commit.committer.email", GitCommitCommitterEmail, GitCommitCommitterEmailBytes));
            }

            if (GitCommitMessage is not null)
            {
                processor.Process(new TagItem<string>("git.commit.message", GitCommitMessage, GitCommitMessageBytes));
            }

            if (BuildSourceRoot is not null)
            {
                processor.Process(new TagItem<string>("build.source_root", BuildSourceRoot, BuildSourceRootBytes));
            }

            if (GitCommitAuthorDate is not null)
            {
                processor.Process(new TagItem<string>("git.commit.author.date", GitCommitAuthorDate, GitCommitAuthorDateBytes));
            }

            if (GitCommitCommitterDate is not null)
            {
                processor.Process(new TagItem<string>("git.commit.committer.date", GitCommitCommitterDate, GitCommitCommitterDateBytes));
            }

            if (CiEnvVars is not null)
            {
                processor.Process(new TagItem<string>("_dd.ci.env_vars", CiEnvVars, CiEnvVarsBytes));
            }

            if (TestsSkipped is not null)
            {
                processor.Process(new TagItem<string>("_dd.ci.itr.tests_skipped", TestsSkipped, TestsSkippedBytes));
            }

            if (IntelligentTestRunnerSkippingType is not null)
            {
                processor.Process(new TagItem<string>("test.itr.tests_skipping.type", IntelligentTestRunnerSkippingType, IntelligentTestRunnerSkippingTypeBytes));
            }

            if (EarlyFlakeDetectionTestEnabled is not null)
            {
                processor.Process(new TagItem<string>("test.early_flake.enabled", EarlyFlakeDetectionTestEnabled, EarlyFlakeDetectionTestEnabledBytes));
            }

            if (EarlyFlakeDetectionTestAbortReason is not null)
            {
                processor.Process(new TagItem<string>("test.early_flake.abort_reason", EarlyFlakeDetectionTestAbortReason, EarlyFlakeDetectionTestAbortReasonBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (Command is not null)
            {
                sb.Append("test.command (tag):")
                  .Append(Command)
                  .Append(',');
            }

            if (WorkingDirectory is not null)
            {
                sb.Append("test.working_directory (tag):")
                  .Append(WorkingDirectory)
                  .Append(',');
            }

            if (CommandExitCode is not null)
            {
                sb.Append("test.exit_code (tag):")
                  .Append(CommandExitCode)
                  .Append(',');
            }

            if (Status is not null)
            {
                sb.Append("test.status (tag):")
                  .Append(Status)
                  .Append(',');
            }

            if (LibraryVersion is not null)
            {
                sb.Append("library_version (tag):")
                  .Append(LibraryVersion)
                  .Append(',');
            }

            if (CIProvider is not null)
            {
                sb.Append("ci.provider.name (tag):")
                  .Append(CIProvider)
                  .Append(',');
            }

            if (CIPipelineId is not null)
            {
                sb.Append("ci.pipeline.id (tag):")
                  .Append(CIPipelineId)
                  .Append(',');
            }

            if (CIPipelineName is not null)
            {
                sb.Append("ci.pipeline.name (tag):")
                  .Append(CIPipelineName)
                  .Append(',');
            }

            if (CIPipelineNumber is not null)
            {
                sb.Append("ci.pipeline.number (tag):")
                  .Append(CIPipelineNumber)
                  .Append(',');
            }

            if (CIPipelineUrl is not null)
            {
                sb.Append("ci.pipeline.url (tag):")
                  .Append(CIPipelineUrl)
                  .Append(',');
            }

            if (CIJobUrl is not null)
            {
                sb.Append("ci.job.url (tag):")
                  .Append(CIJobUrl)
                  .Append(',');
            }

            if (CIJobName is not null)
            {
                sb.Append("ci.job.name (tag):")
                  .Append(CIJobName)
                  .Append(',');
            }

            if (StageName is not null)
            {
                sb.Append("ci.stage.name (tag):")
                  .Append(StageName)
                  .Append(',');
            }

            if (CIWorkspacePath is not null)
            {
                sb.Append("ci.workspace_path (tag):")
                  .Append(CIWorkspacePath)
                  .Append(',');
            }

            if (GitRepository is not null)
            {
                sb.Append("git.repository_url (tag):")
                  .Append(GitRepository)
                  .Append(',');
            }

            if (GitCommit is not null)
            {
                sb.Append("git.commit.sha (tag):")
                  .Append(GitCommit)
                  .Append(',');
            }

            if (GitBranch is not null)
            {
                sb.Append("git.branch (tag):")
                  .Append(GitBranch)
                  .Append(',');
            }

            if (GitTag is not null)
            {
                sb.Append("git.tag (tag):")
                  .Append(GitTag)
                  .Append(',');
            }

            if (GitCommitAuthorName is not null)
            {
                sb.Append("git.commit.author.name (tag):")
                  .Append(GitCommitAuthorName)
                  .Append(',');
            }

            if (GitCommitAuthorEmail is not null)
            {
                sb.Append("git.commit.author.email (tag):")
                  .Append(GitCommitAuthorEmail)
                  .Append(',');
            }

            if (GitCommitCommitterName is not null)
            {
                sb.Append("git.commit.committer.name (tag):")
                  .Append(GitCommitCommitterName)
                  .Append(',');
            }

            if (GitCommitCommitterEmail is not null)
            {
                sb.Append("git.commit.committer.email (tag):")
                  .Append(GitCommitCommitterEmail)
                  .Append(',');
            }

            if (GitCommitMessage is not null)
            {
                sb.Append("git.commit.message (tag):")
                  .Append(GitCommitMessage)
                  .Append(',');
            }

            if (BuildSourceRoot is not null)
            {
                sb.Append("build.source_root (tag):")
                  .Append(BuildSourceRoot)
                  .Append(',');
            }

            if (GitCommitAuthorDate is not null)
            {
                sb.Append("git.commit.author.date (tag):")
                  .Append(GitCommitAuthorDate)
                  .Append(',');
            }

            if (GitCommitCommitterDate is not null)
            {
                sb.Append("git.commit.committer.date (tag):")
                  .Append(GitCommitCommitterDate)
                  .Append(',');
            }

            if (CiEnvVars is not null)
            {
                sb.Append("_dd.ci.env_vars (tag):")
                  .Append(CiEnvVars)
                  .Append(',');
            }

            if (TestsSkipped is not null)
            {
                sb.Append("_dd.ci.itr.tests_skipped (tag):")
                  .Append(TestsSkipped)
                  .Append(',');
            }

            if (IntelligentTestRunnerSkippingType is not null)
            {
                sb.Append("test.itr.tests_skipping.type (tag):")
                  .Append(IntelligentTestRunnerSkippingType)
                  .Append(',');
            }

            if (EarlyFlakeDetectionTestEnabled is not null)
            {
                sb.Append("test.early_flake.enabled (tag):")
                  .Append(EarlyFlakeDetectionTestEnabled)
                  .Append(',');
            }

            if (EarlyFlakeDetectionTestAbortReason is not null)
            {
                sb.Append("test.early_flake.abort_reason (tag):")
                  .Append(EarlyFlakeDetectionTestAbortReason)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
