using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSceneAds : MonoBehaviour {

    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;
    
    private void OnEnable()
	{
        GaminatorAds.Instance.ShowInterstitial (sceneIndex);
		
	}
	private void OnDisable()
	{

	}
}
