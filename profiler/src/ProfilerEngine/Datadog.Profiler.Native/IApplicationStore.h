// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.

#pragma once

#include "ApplicationInfo.h"
#include "ServiceBase.h"

#include <string>

class IApplicationStore : public ServiceBase
{
public:
    virtual ApplicationInfo GetApplicationInfo(const std::string& runtimeId) = 0;

    virtual ApplicationInfo* SetApplicationInfo(const std::string& runtimeId, const std::string& serviceName, const std::string& environment, const std::string& version) = 0;
    virtual void SetGitMetadata(std::string runtimeId, std::string repositoryUrl, std::string commitSha) = 0;
};