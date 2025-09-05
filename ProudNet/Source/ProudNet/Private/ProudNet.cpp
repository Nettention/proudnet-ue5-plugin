// Copyright Epic Games, Inc. All Rights Reserved.

#include "ProudNet.h"
#include "Misc/MessageDialog.h"
#include "Modules/ModuleManager.h"
#include "Interfaces/IPluginManager.h"
#include "Misc/Paths.h"
#include "HAL/PlatformProcess.h"

#define LOCTEXT_NAMESPACE "FProudNetModule"

void FProudNetModule::StartupModule()
{
}

void FProudNetModule::ShutdownModule()
{
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FProudNetModule, ProudNet)
