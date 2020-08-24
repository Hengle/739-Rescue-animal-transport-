using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAdsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneIndex, BigSceneIndex;
    public GameObject LoadingAd;
    void Start()
    {
        Banner();
        ConsoliAds.Instance.LoadRewarded(SceneIndex);
    }
    public void Banner()
    {
        GaminatorAds.Instance.ShowSmartBanner(SceneIndex);
    }
    public void BigBanner()
    {
        GaminatorAds.Instance.ShowSmartBanner(BigSceneIndex);
    }
    public void HideBanner()
    {
        GaminatorAds.Instance.HideBanner();
    }
    public void ShowInterstitial()
    {
        GaminatorAds.Instance.ShowInterstitial(SceneIndex);
    }
    public void RewardedVideo()
    {
        GaminatorAds.Instance.ShowRewardedVideo(SceneIndex);
    }
    public void Reload()
    {
        LoadingAd.SetActive(true);
        StartCoroutine(WaitForScene());
    }
    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
