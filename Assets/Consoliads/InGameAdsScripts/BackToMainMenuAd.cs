using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenuAd : MonoBehaviour {

	public static bool isBack;
    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;
    public ConsoliAdsBannerView consoliAdsBannerView;
    // Use this for initialization
    void Start () {
		
	}

	private void OnEnable()
	{
        
        if (isBack)
		GaminatorAds.Instance.ShowInterstitial (sceneIndex);
		
		GaminatorAds.Instance.ShowSmartBanner (sceneIndex, consoliAdsBannerView);
		isBack = true;
	}
	private void OnDisable()
	{

	}
}
