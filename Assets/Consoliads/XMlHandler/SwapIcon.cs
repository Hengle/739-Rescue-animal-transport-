using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapIcon : MonoBehaviour
{
    [Header("GaminatorAds Swap Adicon ")]
    int sceneIndex = 0;

    public void OnEnable()
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            return;
        }

        StartCoroutine(DelayForAdIcon());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DelayForAdIcon()
    {
        yield return new WaitForSeconds(6f);

        if (GaminatorAds.Instance != null)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);

        if (GaminatorAds.Instance != null && !PlayerPrefManager.Instance.IsAdsRemoved())
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        StartCoroutine(DelayForAdIcon());
    }
    private void OnDestroy()
    {
        if (GaminatorAds.Instance != null)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
