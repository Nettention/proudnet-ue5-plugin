// Copyright Epic Games, Inc. All Rights Reserved.

using System.Collections.Generic;
using System.IO;
using UnrealBuildTool;

public class ProudNet : ModuleRules
{
	public ProudNet(ReadOnlyTargetRules Target) : base(Target)
	{
        string pluginDir = Path.GetFullPath(Path.Combine(ModuleDirectory, "..", ".."));
        string configPath = Path.Combine(pluginDir, "ProudNet.ini");

        var dict = new Dictionary<string, string>();
        foreach (var raw in File.ReadAllLines(configPath))
        {
            var line = raw.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            var kv = line.Split('=', 2);
            if (kv.Length == 2)
                dict[kv[0].Trim()] = kv[1].Trim();
        }
        string proudnetInstalledPath = dict.GetValueOrDefault("proudnet-sdk-path");


        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
                "Core",
                "CoreUObject",
                "Engine",
                "Projects"
			}
			);

		PublicIncludePaths.AddRange(new string[] { Path.Combine(proudnetInstalledPath, "include") });
		PublicIncludePaths.AddRange(new string[] { "ProudNet/Public" });
		PrivateIncludePaths.AddRange(new string[] { "ProudNet/Private" });

		if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            PublicDefinitions.Add("UNICODE");
            PublicDefinitions.Add("_UNICODE");

            bool useStaticCrt = false;
            if (useStaticCrt)
            {
                string libPath = Path.Combine(proudnetInstalledPath, "lib", "x64", "v140", "Release_static_CRT", "ProudNetClient.lib");
                PublicAdditionalLibraries.Add(libPath);
            }
            else
            {
                string libPath = Path.Combine(proudnetInstalledPath, "lib", "x64", "v140", "Release", "ProudNetClient.lib");
                string dllPath = Path.Combine(proudnetInstalledPath, "lib", "x64", "dll", "Release", "ProudNetClient.dll");
                PublicAdditionalLibraries.Add(libPath);
                RuntimeDependencies.Add("$(TargetOutputDir)/ProudNetClient.dll", dllPath, StagedFileType.NonUFS);
                PublicDelayLoadDLLs.Add("ProudNetClient.dll");
            }
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnetInstalledPath, "lib", "IOS", "LLVM", "arm64only", "Release", "libProudNetClient.a"));
            //IOS�� ��� libiconv.2.tbd ���̺귯���� ��θ� �߰������� ������ �־�� �մϴ�.(������ ���� ������ ���� �� iconv ���� ��ũ ���� �߻�)
            PublicAdditionalLibraries.Add(Path.Combine(proudnetInstalledPath, "lib", "IOS", "LLVM", "arm64only", "Release", "libiconv.2.tbd"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnetInstalledPath, "lib", "NDK", "r20", "cmake", "clangRelease", "arm64-v8a", "libProudNetClient.a"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnetInstalledPath, "lib", "x86_x64-linux", "Release" , "libProudNetClient.a"));
        }
    }
}
 