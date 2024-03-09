// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.

#pragma once

#include "ISsiManager.h"

#include <memory>
#include <thread>

class IConfiguration;
class IProfilerTelemetry;


// TODO: try to find a way to enable SetLifetimeDuration only for tests (works for Windows but not for Linux)
#define DD_TEST

class SsiManager : public ISsiManager
{
public:
// TODO: We need to pass another interface to notify when the profiler should start profiling
//       Is it enough to pass CorProfilerCallback*?
    SsiManager(IConfiguration* pConfiguration, IProfilerTelemetry* pTelemetry);
    ~SsiManager() = default;

#ifdef DD_TEST
public:
    void SetLifetimeDuration(int duration);
#endif

public:
    // Inherited via ISsiManager
    void OnSpanCreated() override;
    bool IsSpanCreated() override;
    bool IsLongLived() override;
    bool IsProfilerEnabled() override;
    bool IsProfilerActivated() override;

    // send metrics
    void ProcessStart() override;
    void ProcessEnd() override;

private:
    IConfiguration* _pConfiguration;
    IProfilerTelemetry* _pTelemetry;
    bool _hasSpan = false;
    bool _isSsiDeployed = false;

#ifdef DD_TEST
private:
    //  -1 means short lived
    //   0 means normal lifetime computing
    // > 0 means long lived
    int _lifetimeDuration = 0;
#endif
};

