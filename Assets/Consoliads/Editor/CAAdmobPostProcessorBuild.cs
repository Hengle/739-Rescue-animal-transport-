#if UNITY_IPHONE || UNITY_IOS
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor;

public class CAAdmobPostProcessorBuild
{
	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
	{
		string plistPath = Path.Combine(path, "Info.plist");
		PlistDocument plist = new PlistDocument();
		plist.ReadFromFile(plistPath);
		plist.root.SetString("gad_preferred_webview", "wkwebview");
		File.WriteAllText(plistPath, plist.WriteToString());

	}
}

#endif
