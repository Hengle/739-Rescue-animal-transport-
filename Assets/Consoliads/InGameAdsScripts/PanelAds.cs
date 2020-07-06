using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAds : MonoBehaviour
{
	
    [Header("GaminatorAds  SceneIndex ")]
    public int PanelAdsIndex;
    

    private void OnEnable()
    {
        
        GaminatorAds.Instance.ShowInterstitial(PanelAdsIndex);
    }

    private void OnDisable()
    {
        
    }
	
}
