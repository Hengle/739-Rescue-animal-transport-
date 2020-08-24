using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAd : MonoBehaviour {

    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;
    private void OnEnable()
	{
        GaminatorAds.Instance.ShowSmartBanner(sceneIndex);
       // Debug.Log("LoadingAd");
    }
	private void OnDisable()
	{
        GaminatorAds.Instance.HideBanner();
    }
    private void OnDestroy()
    {  
		GaminatorAds.Instance.HideBanner();
    }
}
