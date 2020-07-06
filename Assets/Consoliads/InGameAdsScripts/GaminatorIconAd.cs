using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaminatorIconAd : MonoBehaviour
{
    [Header("GaminatorAds NativeAd SceneIndex ")]
    public int sceneIndex = 0;
    public IconAnimationType animationType;
    public void OnEnable()
    {
       
        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.ShowAdIcon(this.gameObject, sceneIndex, animationType);
        }

        StartCoroutine(DelayForAdIcon());

        //Debug.Log("GaminatorIconAd OnEnable");
    }

    public void OnDisable()
    {
       
        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.HideAdIcon(this.gameObject, sceneIndex);
        }

        StopAllCoroutines();

       // Debug.Log("GaminatorIconAdOnDisable");
    }
    IEnumerator DelayForAdIcon()
    {
        yield return new WaitForSeconds(8f);

        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.HideAdIcon(this.gameObject,sceneIndex);
        }
        yield return new WaitForSeconds(0.5f);

        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.ShowAdIcon(this.gameObject, sceneIndex, animationType);
        }

        StartCoroutine(DelayForAdIcon());
    }
    private void OnDestroy()
    {
        if (GaminatorAds.Instance != null)
        {
            GaminatorAds.Instance.HideAdIcon(this.gameObject, sceneIndex);
        }

       // Debug.Log("OnDestroy In PanelAds");
    }
}