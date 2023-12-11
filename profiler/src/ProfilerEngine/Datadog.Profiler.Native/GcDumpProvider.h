#pragma once

#include "IGcDumpProvider.h"
#include "GcDump.h"

#include <memory>

class GcDumpProvider : public IGcDumpProvider
{
public:
    GcDumpProvider();

public:
    bool Get(gcdump_t& gcDump) override;
};