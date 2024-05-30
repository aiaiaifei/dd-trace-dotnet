#include "SsiManager.h"
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.

#include "SsiManager.h"

#include "IConfiguration.h"
#include "ISsiLifetime.h"
#include "Log.h"
#include "OpSysTools.h"
#include "OsSpecificApi.h"

#include <functional>
#include <future>
#include <mutex>

static void StartProfiling(ISsiLifetime* pSsiLifetime)
{
    static std::once_flag spanCreated;
    std::call_once(spanCreated, [pSsiLifetime]() {
        pSsiLifetime->OnStartDelayedProfiling();
    });
}

SsiManager::SsiManager(IConfiguration* pConfiguration, ISsiLifetime* pSsiLifetime) :
    _pSsiLifetime(pSsiLifetime),
    _hasSpan{false},
    _isLongLived{false},
    _deploymentMode{pConfiguration->GetDeploymentMode()},
    _enablementStatus{pConfiguration->GetEnablementStatus()},
    _longLivedThreshold{pConfiguration->GetSsiLongLivedThreshold()}
{
}

SsiManager::~SsiManager()
{
    _stopTimerPromise.set_value();
}

void SsiManager::OnShortLivedEnds()
{
    _isLongLived = true;
    if (_hasSpan && _deploymentMode == DeploymentMode::SingleStepInstrumentation)
    {
        StartProfiling(_pSsiLifetime);
    }
}

void SsiManager::OnSpanCreated()
{
    _hasSpan = true;
    if (_isLongLived && _deploymentMode == DeploymentMode::SingleStepInstrumentation)
    {
        StartProfiling(_pSsiLifetime);
    }
}

bool SsiManager::IsSpanCreated()
{
    return _hasSpan;
}

bool SsiManager::IsLongLived()
{
    auto lifetime = OsSpecificApi::GetProcessLifetime();
    return lifetime > _longLivedThreshold.count();
}

// the profiler is enabled if either:
//     - the profiler is enabled in the configuration
//  or - the profiler is deployed via SSI and DD_INJECTION_ENABLED contains "profiling"
bool SsiManager::IsProfilerEnabled()
{
    return _enablementStatus == EnablementStatus::ManuallyEnabled ||
           // in the future, users will be able to enable the profiler via SSI at agent installation time
           _enablementStatus == EnablementStatus::SsiEnabled;
}

// the profiler is activated either if:
//     - the profiler is enabled in the configuration
//  or - is enabled via SSI + runs for more than 30 seconds + has at least one span
bool SsiManager::IsProfilerActivated()
{
    return _enablementStatus == EnablementStatus::ManuallyEnabled ||
           (_deploymentMode == DeploymentMode::SingleStepInstrumentation && IsLongLived() && IsSpanCreated());
}

void SsiManager::ProcessStart()
{
    Log::Debug("ProcessStart(", to_string(_deploymentMode), ")");

    // TODO the doc again to know when we need the timer.
    // currently it's disabled in ssi deployed AND not manually enabled nor ssi enabled
    // I guess we still have to start the timer when ssi enabled
    if (_deploymentMode == DeploymentMode::SingleStepInstrumentation && _enablementStatus == EnablementStatus::SsiEnabled)
    {
        // This timer *must* be created only AND only if it's a SSI deployment
        // we have to check if this is what we want. In CorProfilerCallback.cpp l.1239, we start the service
        // if the profiler is enabled (SII or not SSI).
        // For the moment we just enable the timer only in pure SSI
        _longLivedTimerFuture = std::async(
            std::launch::async, [this](std::future<void> stopRequest) {
                auto status = stopRequest.wait_for(_longLivedThreshold);
                if (status == std::future_status::timeout)
                {
                    OnShortLivedEnds();
                }
            },
            _stopTimerPromise.get_future());
    }
}

void SsiManager::ProcessEnd()
{
    Log::Debug("ProcessEnd(", to_string(_deploymentMode), ", ", to_string(GetSkipProfileHeuristic()), ")");
}

SkipProfileHeuristicType SsiManager::GetSkipProfileHeuristic()
{
    auto heuristics = SkipProfileHeuristicType::AllTriggered;

    if (!IsLongLived())
    {
        heuristics = (SkipProfileHeuristicType)(heuristics | SkipProfileHeuristicType::ShortLived);
    }
    if (!IsSpanCreated())
    {
        heuristics = (SkipProfileHeuristicType)(heuristics | SkipProfileHeuristicType::NoSpan);
    }

    return heuristics;
}

DeploymentMode SsiManager::GetDeploymentMode() const
{
    return _deploymentMode;
}
