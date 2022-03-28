// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.IO;
using UnrealBuildTool;

public class UnrealMC : ModuleRules
{
	public UnrealMC(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });

		CppStandard = CppStandardVersion.Cpp17;

		Definitions.Add("WIN32_LEAN_AND_MEAN");

		SetupMCProto();

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });
		
		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}

	public void SetupMCProto()
	{
		string root = Path.GetFullPath(Path.Combine(ModuleDirectory, "..", ".."));

		string libpath = Path.Combine(
			root,
			"third-party",
			"mc-proto",
			"build",
			"Release"
		);
		string[] libs = new string[]
		{
			Path.Combine(libpath, "mc-proto.lib"),
			Path.Combine(libpath, "glog.lib"),
			Path.Combine(libpath, "sockpp-static.lib")
		};

		string includepath = Path.Combine(
			root,
			"third-party",
			"mc-proto",
			"mc-proto"
		);

		foreach (string lib in libs)
        {
			PublicAdditionalLibraries.Add(lib);
        }

		PublicIncludePaths.Add(includepath);
	}
}
