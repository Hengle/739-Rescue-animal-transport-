using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSceneAds : MonoBehaviour {

    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;

    private void OnEnable()
	{
        if(GaminatorAds._instance.SelectionSceneAds)
        GaminatorAds.Instance.ShowInterstitial (sceneIndex);
        GaminatorAds._instance.SelectionSceneAds = false;

        GaminatorAds.Instance.ShowSmartBanner (sceneIndex);
	}
	private void OnDisable()
	{

	}
}
