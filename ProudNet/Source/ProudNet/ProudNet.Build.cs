// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class ProudNet : ModuleRules
{
	public ProudNet(ReadOnlyTargetRules Target) : base(Target)
	{
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        string proudnet_installed_path = "C:/Program Files (x86)/Nettention/ProudNet";
				
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
                "Core",
                "CoreUObject",
                "Engine",
                "Projects"
			}
			);

		PublicIncludePaths.AddRange(new string[] { Path.Combine(proudnet_installed_path, "include") });
		PublicIncludePaths.AddRange(new string[] { "ProudNet/Public" });
		PrivateIncludePaths.AddRange(new string[] { "ProudNet/Private" });

		if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            PublicDefinitions.Add("UNICODE");
            PublicDefinitions.Add("_UNICODE");

            bool useStaticCrt = false;
            if (useStaticCrt)
            {
                string libPath = Path.Combine(proudnet_installed_path, "lib", "x64", "v140", "Release_static_CRT", "ProudNetClient.lib");
                PublicAdditionalLibraries.Add(libPath);
            }
            else
            {
                string libPath = Path.Combine(proudnet_installed_path, "lib", "x64", "v140", "Release", "ProudNetClient.lib");
                string dllPath = Path.Combine(proudnet_installed_path, "lib", "x64", "dll", "Release", "ProudNetClient.dll");
                PublicAdditionalLibraries.Add(libPath);
                RuntimeDependencies.Add("$(TargetOutputDir)/ProudNetClient.dll", dllPath, StagedFileType.NonUFS);
                PublicDelayLoadDLLs.Add("ProudNetClient.dll");
            }
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnet_installed_path, "lib", "IOS", "LLVM", "arm64only", "Release", "libProudNetClient.a"));
            //IOS�� ��� libiconv.2.tbd ���̺귯���� ��θ� �߰������� ������ �־�� �մϴ�.(������ ���� ������ ���� �� iconv ���� ��ũ ���� �߻�)
            PublicAdditionalLibraries.Add(Path.Combine(proudnet_installed_path, "lib", "IOS", "LLVM", "arm64only", "Release", "libiconv.2.tbd"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnet_installed_path, "lib", "NDK", "r20", "cmake", "clangRelease", "arm64-v8a", "libProudNetClient.a"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            PublicAdditionalLibraries.Add(Path.Combine(proudnet_installed_path, "lib", "x86_x64-linux", "Release" , "libProudNetClient.a"));
        }
    }
}
 