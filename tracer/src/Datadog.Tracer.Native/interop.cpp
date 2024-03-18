//---------------------------------------------------------------------------------------
// Exports that managed code from Datadog.Trace.dll will
// P/Invoke into
//
// NOTE: Must keep these signatures in sync with the DllImports in
// NativeMethods.cs!
//---------------------------------------------------------------------------------------

#include "cor_profiler.h"
#include "logger.h"
#include "iast/hardcoded_secrets_method_analyzer.h"

#ifndef _WIN32
#include <dlfcn.h>
#undef EXTERN_C
#define EXTERN_C extern "C" __attribute__((visibility("default")))
#endif

EXTERN_C BOOL STDAPICALLTYPE IsProfilerAttached()
{
    return trace::profiler != nullptr && trace::profiler->IsAttached();
}

EXTERN_C VOID STDAPICALLTYPE GetAssemblyAndSymbolsBytes(BYTE** pAssemblyArray, int* assemblySize, BYTE** pSymbolsArray,
                                                        int* symbolsSize)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in GetAssemblyAndSymbolsBytes call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->GetAssemblyAndSymbolsBytes(pAssemblyArray, assemblySize, pSymbolsArray, symbolsSize);
}

EXTERN_C VOID STDAPICALLTYPE InitializeProfiler(WCHAR* id, trace::CallTargetDefinition* items, int size)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in InitializeProfiler call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->InitializeProfiler(id, items, size);
}

EXTERN_C VOID STDAPICALLTYPE RemoveCallTargetDefinitions(WCHAR* id, trace::CallTargetDefinition* items, int size)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in RemoveCallTargetDefinitions call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->RemoveCallTargetDefinitions(id, items, size);
}

EXTERN_C VOID STDAPICALLTYPE EnableByRefInstrumentation()
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in EnableByRefInstrumentation call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->EnableByRefInstrumentation();
}

EXTERN_C VOID STDAPICALLTYPE EnableCallTargetStateByRef()
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in EnableCallTargetStateByRef call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->EnableCallTargetStateByRef();
}

EXTERN_C VOID STDAPICALLTYPE AddDerivedInstrumentations(WCHAR* id, trace::CallTargetDefinition* items, int size)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in AddDerivedInstrumentations call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->AddDerivedInstrumentations(id, items, size);
}

EXTERN_C VOID STDAPICALLTYPE AddInterfaceInstrumentations(WCHAR* id, trace::CallTargetDefinition* items, int size)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in AddInterfaceInstrumentations call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->AddInterfaceInstrumentations(id, items, size);
}

EXTERN_C VOID STDAPICALLTYPE AddTraceAttributeInstrumentation(WCHAR* id, WCHAR* integration_assembly_name_ptr,
                                                              WCHAR* integration_type_name_ptr)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in AddTraceAttributeInstrumentation call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->AddTraceAttributeInstrumentation(id, integration_assembly_name_ptr,
                                                             integration_type_name_ptr);
}

EXTERN_C VOID STDAPICALLTYPE InitializeTraceMethods(WCHAR* id, WCHAR* integration_assembly_name_ptr,
                                                    WCHAR* integration_type_name_ptr, WCHAR* configuration_string_ptr)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in InitializeTraceMethods call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->InitializeTraceMethods(id, integration_assembly_name_ptr, integration_type_name_ptr,
                                            configuration_string_ptr);
}

EXTERN_C VOID STDAPICALLTYPE InstrumentProbes(
    debugger::DebuggerMethodProbeDefinition* methodProbes,
    int methodProbesLength,
    debugger::DebuggerLineProbeDefinition* lineProbes,
    int lineProbesLength,
    debugger::DebuggerMethodSpanProbeDefinition* spanProbes,
    int spanProbesLength,
    debugger::DebuggerRemoveProbesDefinition* revertProbes,
    int revertProbesLength)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in InstrumentProbes call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->InstrumentProbes(methodProbes, methodProbesLength, lineProbes, lineProbesLength, spanProbes, spanProbesLength, revertProbes, revertProbesLength);
}

EXTERN_C int STDAPICALLTYPE GetProbesStatuses(WCHAR** probeIds, int probeIdsLength, debugger::DebuggerProbeStatus* probeStatuses)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in GetProbesStatuses call. Tracer CLR Profiler was not initialized.");
        return 0;
    }

    return trace::profiler->GetProbesStatuses(probeIds, probeIdsLength, probeStatuses);
}

EXTERN_C VOID STDAPICALLTYPE DisableTracerCLRProfiler()
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in DisableTracerCLRProfiler call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->DisableTracerCLRProfiler();
}

EXTERN_C VOID STDAPICALLTYPE RegisterIastAspects(WCHAR** aspects, int aspectsLength)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in RegisterIastAspects call. Tracer CLR Profiler was not initialized.");
        return;
    }

    trace::profiler->RegisterIastAspects(aspects, aspectsLength);
}


EXTERN_C long STDAPICALLTYPE RegisterCallTargetDefinitions(WCHAR* id, CallTargetDefinition2* items, int size,
                                                          UINT32 enabledCategories)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in RegisterCallTargetDefinitions call. Tracer CLR Profiler was not initialized.");
        return 0;
    }

    return trace::profiler->RegisterCallTargetDefinitions(id, items, size, enabledCategories);
}

EXTERN_C long STDAPICALLTYPE EnableCallTargetDefinitions(UINT32 enabledCategories)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in EnableCallTargetDefinitions call. Tracer CLR Profiler was not initialized.");
        return 0;
    }

    return trace::profiler->EnableCallTargetDefinitions(enabledCategories);
}

EXTERN_C long STDAPICALLTYPE DisableCallTargetDefinitions(UINT32 disabledCategories)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in DisableCallTargetDefinitions call. Tracer CLR Profiler was not initialized.");
        return 0;
    }

    return trace::profiler->DisableCallTargetDefinitions(disabledCategories);
}


EXTERN_C VOID STDAPICALLTYPE UpdateSettings(WCHAR* keys[], WCHAR* values[], int length)
{
    return trace::profiler->UpdateSettings(keys, values, length);
}

EXTERN_C int STDAPICALLTYPE GetUserStrings(int arrSize, iast::UserStringInterop* arr)
{
    if (iast::HardcodedSecretsMethodAnalyzer::Instance)
    {
        return iast::HardcodedSecretsMethodAnalyzer::Instance->GetUserStrings(arrSize, arr);
    }
    return 0;
}

EXTERN_C VOID STDAPICALLTYPE ReportSuccessfulInstrumentation(ModuleID moduleId, int methodToken, WCHAR* instrumentationId, int products)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in ReportSuccessfulInstrumentation call. Tracer CLR Profiler was not initialized.");
    }

    return trace::profiler->ReportSuccessfulInstrumentation(moduleId, methodToken, instrumentationId, products);
}

EXTERN_C BOOL STDAPICALLTYPE ShouldHeal(ModuleID moduleId, int methodToken, WCHAR* instrumentationId, int products)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in ShouldHeal call. Tracer CLR Profiler was not initialized.");
    }

    return trace::profiler->ShouldHeal(moduleId, methodToken, instrumentationId, products);
}

#ifndef _WIN32
EXTERN_C void *dddlopen (const char *__file, int __mode)
{
    return dlopen(__file, __mode);
}

EXTERN_C char *dddlerror (void)
{
    return dlerror();
}

EXTERN_C void *dddlsym (void *__restrict __handle, const char *__restrict __name)
{
    return dlsym(__handle, __name);
}

EXTERN_C int dddlclose (void *handle)
{
    return dlclose(handle);
}
#endif

EXTERN_C void InitializeTraceExporter(const char* host, std::uint16_t port, const char* tracer_version, const char* language, const char* language_version, const char* language_interpreter)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in InitializeTraceExporter call. Tracer CLR Profiler was not initialized.");
    }

    trace::profiler->InitializeTraceExporter(host, port, tracer_version, language, language_version, language_interpreter);
}

EXTERN_C void SendTrace(std::uint8_t* buffer, std::uintptr_t buffer_size, std::uintptr_t trace_count)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in SendTrace call. Tracer CLR Profiler was not initialized.");
    }

    auto s = trace::profiler->SendTrace(buffer, buffer_size, trace_count);
    Logger::Debug("Trace sent. Result: ", s);
}

EXTERN_C void InitializeStatsExporter(const char* hostname, const char* env, const char* version,
                                      const char* lang, const char* tracerVersion, const char* runtimeId,
                                      const char* service, const char* containerId,
                                      const char* gitCommitSha, const char** tags, std::size_t nbTags,
                                      const char* agentUrl)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in InitializeStatsExporter call. Tracer CLR Profiler was not initialized.");
    }

    std::vector<std::string_view> empty_tags; // TODO for now
    trace::profiler->InitializeStatsExporter(hostname, env, version, lang, tracerVersion, runtimeId, service, containerId, gitCommitSha, empty_tags, agentUrl);
}

EXTERN_C void AddSpanToBucket(const char* resourceName, const char* serviceName,
                              const char* operationName, const char* spanType, std::int32_t httpStatusCode,
                              bool isSyntheticsRequest, bool isTopLevel, bool isError, std::int64_t duration)
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in AddSpanToBucket call. Tracer CLR Profiler was not initialized.");
    }

    trace::profiler->AddSpanToBucket(resourceName, serviceName, operationName, spanType, httpStatusCode, isSyntheticsRequest, isTopLevel, isError, duration);
}

EXTERN_C void FlushStats()
{
    if (trace::profiler == nullptr)
    {
        trace::Logger::Error("Error in FlushStats call. Tracer CLR Profiler was not initialized.");
    }

    trace::profiler->FlushStats();
}