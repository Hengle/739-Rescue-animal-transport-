using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBanner : MonoBehaviour {

    // Use this for initialization
    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;
    public ConsoliAdsBannerView consoliAdsBannerView =new ConsoliAdsBannerView();

    private void OnEnable()
	{
        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.ShowSmartBanner(sceneIndex, consoliAdsBannerView);
        }
	}

    private void OnDisable()
    {

        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.HideBanner(consoliAdsBannerView);
        }
    }
}
