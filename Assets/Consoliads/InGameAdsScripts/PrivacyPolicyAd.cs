using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicyAd : MonoBehaviour
{

    [Header("ShowSmartBanner  SceneIndex ")]
    public int sceneIndex = 0;

    private void OnEnable()
	{

        if(sceneIndex==0)
        {
            Debug.LogError("Add Scene Index in PrivacyPolicyAd");
        }

        GaminatorAds.Instance.HideBanner();
	}
	private void OnDisable()
	{ 
        GaminatorAds.Instance.ShowSmartBanner(sceneIndex);
	}

}
