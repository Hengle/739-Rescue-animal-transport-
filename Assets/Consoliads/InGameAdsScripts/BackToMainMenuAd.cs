using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenuAd : MonoBehaviour {

	public static bool isBack;
    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;
    // Use this for initialization
    void Start () {
		
	}

	private void OnEnable()
	{
        
        if (isBack && GaminatorAds._instance.show_MainMenu_Ad)
		GaminatorAds.Instance.ShowInterstitial (sceneIndex);
        GaminatorAds._instance.show_MainMenu_Ad = false;

        GaminatorAds.Instance.ShowSmartBanner (sceneIndex);
		isBack = true;
	}
	private void OnDisable()
	{

	}
}
