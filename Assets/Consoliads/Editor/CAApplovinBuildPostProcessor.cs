using UnityEngine;
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class CAApplovinBuildPostProcessor
{

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
	{

		if (buildTarget == BuildTarget.iOS)
		{
			string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject proj = new PBXProject();

			proj.ReadFromString(File.ReadAllText(projPath));

			string target = "";

#if UNITY_2019_3_OR_NEWER

			target = proj.GetUnityFrameworkTargetGuid();

            BuildForiOS(projPath, proj);

#else
			target = proj.TargetGuidByName("Unity-iPhone");

#endif

			proj.AddBuildProperty(target, "CLANG_ENABLE_MODULES", "YES");

			proj.AddBuildProperty(target, "GCC_ENABLE_OBJC_EXCEPTIONS", "YES");

			File.WriteAllText(projPath, proj.WriteToString());

		}
	}


#if UNITY_2019_3_OR_NEWER

	private static void BuildForiOS(string projPath, PBXProject proj)
	{

		string target = proj.GetUnityMainTargetGuid();

		List<string> frameworks = new List<string>();

		frameworks.Add("AppLovinSDKResources.bundle");

		foreach (string framework in frameworks)
		{
			string name = proj.AddFile("Assets/Plugins/iOS/" + framework, "Frameworks/Plugins/iOS/" + framework, PBXSourceTree.Source);
			proj.AddFileToBuild(target, name);
		}

	}

#endif
	public int callbackOrder { get { return 0; } }
}
