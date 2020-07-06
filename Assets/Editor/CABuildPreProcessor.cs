using UnityEngine;
using System.Collections;
#if UNITY_5_6_OR_NEWER

using UnityEditor.Build;
using UnityEditor;

class CABuildPreProcessor : IPreprocessBuild
{
    private const string gameObjectName = "ConsoliAds";
    public ConsoliAds _instance;
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildTarget target, string path)
    {
        _instance = GameObject.FindObjectOfType<ConsoliAds>();

		if(_instance != null && _instance.DevMode)
        {
			EditorUtility.DisplayDialog("Warning...!", "Dev Mode is on make sure disable it before live release", "Make Build");
        }
    }
}

#endif