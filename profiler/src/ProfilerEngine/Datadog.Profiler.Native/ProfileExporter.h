// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.

#pragma once

#include "IExporter.h"
#include "IUpscaleProvider.h"
#include "MetricsRegistry.h"
#include "Sample.h"
#include "TagsHelper.h"

#include <forward_list>
#include <memory>
#include <optional>
#include <string_view>
#include <unordered_map>
#include <vector>

// forward declarations
class Sample;
class IMetricsSender;
class IApplicationStore;
class IRuntimeInfo;
class IEnabledProfilers;
class IAllocationsRecorder;
class IProcessSamplesProvider;
class IMetadataProvider;
class IConfiguration;
class ISsiManager;

namespace libdatadog {
class Exporter;
class Profile;
class Tags;
} // namespace libdatadog

class ProfileExporter : public IExporter
{
public:
    ProfileExporter(
        std::vector<SampleValueType> sampleTypeDefinitions,
        IConfiguration* configuration,
        IApplicationStore* applicationStore,
        IRuntimeInfo* runtimeInfo,
        IEnabledProfilers* enabledProfilers,
        MetricsRegistry& metricsRegistry,
        IMetadataProvider* metadataProvider,
        IAllocationsRecorder* allocationsRecorder,
        ISsiManager* ssiManager);
    ~ProfileExporter() override;

    bool Export() override;
    void Add(std::shared_ptr<Sample> const& sample) override;
    void SetEndpoint(const std::string& runtimeId, uint64_t traceId, const std::string& endpoint) override;
    void RegisterUpscaleProvider(IUpscaleProvider* provider) override;
    void RegisterProcessSamplesProvider(ISamplesProvider* provider) override;

private:
    class ProfileInfo
    {
    public:
        ProfileInfo();
        ~ProfileInfo();

    public:
        std::unique_ptr<libdatadog::Profile> profile;
        std::int32_t samplesCount;
        std::int32_t exportsCount;
        std::mutex lock;
    };

    class ProfileInfoScope
    {
    public:
        ProfileInfoScope(ProfileInfo& profileInfo);

        ProfileInfo& profileInfo;

    private:
        std::lock_guard<std::mutex> _lockGuard;
    };

    static libdatadog::Tags CreateTags(IConfiguration* configuration, IRuntimeInfo* runtimeInfo, IEnabledProfilers* enabledProfilers);

    std::unique_ptr<libdatadog::Exporter> CreateExporter(IConfiguration* configuration, libdatadog::Tags tags);
    std::unique_ptr<libdatadog::Profile> CreateProfile(std::string serviceName);

    void AddProcessSamples(libdatadog::Profile* profile, std::list<std::shared_ptr<Sample>> const& samples);
    void Add(libdatadog::Profile* profile, std::shared_ptr<Sample> const& sample);

    std::string BuildAgentEndpoint(IConfiguration* configuration);
    ProfileInfoScope GetOrCreateInfo(std::string_view runtimeId);

    static void AddUpscalingRules(libdatadog::Profile* profile, std::vector<UpscalingInfo> const& upscalingInfos);
    static fs::path CreatePprofOutputPath(IConfiguration* configuration);

    std::string CreateMetricsFileContent() const;
    std::vector<UpscalingInfo> GetUpscalingInfos();
    std::list<std::shared_ptr<Sample>> GetProcessSamples();
    std::optional<ProfileInfoScope> GetInfo(const std::string& runtimeId);
    std::string GetMetadata() const;

private:
    static tags CommonTags;
    static std::string const ProcessId;
    static int const RequestTimeOutMs;
    static std::string const LibraryName;
    static std::string const LibraryVersion;
    static std::string const LanguageFamily;
    static std::string const MetricsFilename;
    static std::string const AllocationsExtension;

    // TODO: this should be passed in the constructor to avoid overwriting
    //       the .pprof generated by the managed side
    static std::string const RequestFileName;
    static std::string const ProfilePeriodType;
    static std::string const ProfilePeriodUnit;

    std::vector<SampleValueType> _sampleTypeDefinitions;
    fs::path _outputPath;

    // for each application, keep track of a profile, a samples count since the last export and an export count
    std::unordered_map<std::string_view, ProfileInfo> _perAppInfo;

    IApplicationStore* const _applicationStore;

    std::mutex _perAppInfoLock;
    MetricsRegistry& _metricsRegistry;
    fs::path _metricsFileFolder;
    IAllocationsRecorder* _allocationsRecorder;
    std::vector<IUpscaleProvider*> _upscaledProviders;
    std::vector<ISamplesProvider*> _processSamplesProviders;
    IMetadataProvider* _metadataProvider;
    std::unique_ptr<libdatadog::Exporter> _exporter;
    IConfiguration* _configuration;
    ISsiManager* _ssiManager;

public: // for tests
    static std::string GetEnabledProfilersTag(IEnabledProfilers* enabledProfilers);
};