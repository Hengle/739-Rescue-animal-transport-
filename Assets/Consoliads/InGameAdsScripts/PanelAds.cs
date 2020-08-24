using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BannerPostion
{
	TopLeft,
	TopRight
}
public class PanelAds : MonoBehaviour
{
	
    [Header("GaminatorAds  SceneIndex ")]
    public int PanelAdsIndex, SmartBannerIndex;

    private void OnEnable()
    {
        GaminatorAds.Instance.ShowSmartBanner(PanelAdsIndex);
        GaminatorAds.Instance.ShowInterstitial(PanelAdsIndex);
    }

    private void OnDisable()
    {
        GaminatorAds.Instance.ShowSmartBanner(SmartBannerIndex);
    }
	private void OnDestroy()
	{
       
		//Debug.Log ("OnDestroy In PanelAds");
	}

}
