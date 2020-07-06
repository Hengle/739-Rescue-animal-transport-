using UnityEngine;
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class CABuildPostprocessor
{
	internal static void CopyAndReplaceDirectory(string srcPath, string dstPath)
	{
		if (Directory.Exists(dstPath))
			Directory.Delete(dstPath);
		if (File.Exists(dstPath))
			File.Delete(dstPath);

		Directory.CreateDirectory(dstPath);

		foreach (var file in Directory.GetFiles(srcPath))
			File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));

		foreach (var dir in Directory.GetDirectories(srcPath))
			CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
	}

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
			proj.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");

			File.WriteAllText(projPath, proj.WriteToString());

		}
	}

	#if UNITY_2019_3_OR_NEWER

	private static void BuildForiOS(string projPath, PBXProject proj)
	{

		string target = proj.GetUnityMainTargetGuid();

		List<string> frameworks = new List<string>();

		frameworks.Add("ConsoliAdsResources.bundle");

		foreach (string framework in frameworks)
		{
			string name = proj.AddFile("Assets/Plugins/iOS/" + framework, "Frameworks/Plugins/iOS/" + framework, PBXSourceTree.Source);
			proj.AddFileToBuild(target, name);
		}

		frameworks.Clear();
		frameworks.Add("MediationNativeAdView.xib");

		foreach (string framework in frameworks)
		{
			string name = proj.AddFile("Assets/Plugins/iOS/" + framework, "Libraries/Plugins/iOS/" + framework, PBXSourceTree.Source);
			proj.AddFileToBuild(target, name);
		}

	}

#endif

	public int callbackOrder { get { return 0; } }
}
