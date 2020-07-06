using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaminatorNativeAd : MonoBehaviour
{
    
    [Header("GaminatorAds NativeAd SceneIndex ")]
    public int sceneIndex = 0;

    public void OnEnable()
    {

        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.ShowNativeAd(this.gameObject, sceneIndex);
        }
       // Debug.Log("GaminatorNativeAd OnEnable");
    }

    public void OnDisable()
    {
        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.HideNativeAd(sceneIndex);
        }
       // Debug.Log("GaminatorNativeAd OnDisable");
    }


}
