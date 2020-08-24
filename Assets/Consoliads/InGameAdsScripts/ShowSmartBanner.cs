using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSmartBanner : MonoBehaviour {

    // Use this for initialization
    [Header("GaminatorAds  SceneIndex ")]
    public int sceneIndex = 0;

    private void OnEnable()
	{
        GaminatorAds.Instance.ShowSmartBanner(sceneIndex);
	}

}
