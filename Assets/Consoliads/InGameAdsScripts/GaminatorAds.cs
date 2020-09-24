using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;
using GameAnalyticsSDK;

[Serializable]
public class AdIconsData
{
    public string texLink;
    public string appIdentifier;
    public Texture tex;
    public AdIconsData(string _link)
    {
        texLink = _link;
        appIdentifier = GetPackageNameFromLink(_link);
    }
    private string GetPackageNameFromLink(string _link)
    {
        string[] div1 = _link.Split('/');
        string[] div2 = div1[div1.Length - 1].Split('?');
        string[] div3 = div2[0].Split('.');
        string packageName = "";
        for (int i = 0; i < div3.Length - 1; i++)
        {
            if (i > 0)
                packageName += "." + div3[i];
            else
                packageName += div3[i];
        }
        return packageName;
    }
}


public class GaminatorAds : MonoBehaviour
{

    public static GaminatorAds _instance;
    public bool show_MainMenu_Ad = false;
    public bool SelectionSceneAds = false;
    //public static event Action OnRewardedAdCompletedEvent;
    public bool userConsent;
    //public GameObject nativePanel,adIcon;

    // Start is called before the first frame update

      private static AdIconHandler adIconHandler;
    public static AdIconHandler AdIconHandler
    {
        get
        {
            return adIconHandler;
        }
    }

    private void Awake()
    {
        GameAnalytics.Initialize();
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static GaminatorAds Instance
    {
        
        get
        {
           
           if (_instance == null)
           {
                   
                try
                {
                    _instance = GameObject.FindObjectOfType<GaminatorAds>();
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                    _instance = new GaminatorAds();
                }

           }

            return _instance;

        }
            
    }

    void Start()
    {
        Debug.Log("initialized ConsoliAds");
       
        if(!PlayerPrefManager.Instance.IsAdsRemoved())
        initializeAds();
        adIconHandler = GetComponent<AdIconHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void initializeAds()
    {
        try
        { 
            ConsoliAds.Instance.initialize(userConsent);
            HideBanner();
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void ShowSmartBanner(int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;

        try
        {
           
            ConsoliAds.Instance.HideBanner();
            Debug.Log("ShowSmartBanner");
            ConsoliAds.Instance.ShowBanner(Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void HideBanner()
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
            Debug.Log("HideBanner");
            ConsoliAds.Instance.HideBanner();
        }
        catch(Exception e){
			Debug.LogError(e.Message);
            
        }
    }

    public void ShowInterstitial(int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
            
            Debug.Log("ShowInterstitial");
            ConsoliAds.Instance.ShowInterstitial(Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void ShowNativeAd(GameObject nativePanel,int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;

        try
        {
            
            Debug.Log("ShowNativeAd");
            ConsoliAds.Instance.ShowNativeAd(nativePanel, Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void HideNativeAd(int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
           
            Debug.Log("HideNativeAd");
            ConsoliAds.Instance.HideNative(Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void RateUs()
    {
        try
        {
            Application.OpenURL(ConsoliAds.Instance.RateUsURL());
            Debug.Log("RateUs");
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void MoreApps()
    {
        try
        {
            Debug.Log("MoreApps");
            Application.OpenURL(ConsoliAds.Instance.MoreFunURL());
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }

    }


    public void ShowAdIcon(GameObject adIcon,int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
           
            Debug.Log("ShowAdIcon");
            ConsoliAds.Instance.ShowIconAd(adIcon, Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void HideAdIcon(GameObject adIcon, int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
            Debug.Log("HideAdIcon");
            ConsoliAds.Instance.DestoryIconAd(adIcon, Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void MoreAppsShowAdIcon(GameObject adIcon, int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {

            Debug.Log("MoreAppsShowAdIcon");
            ConsoliAds.Instance.ShowIconAd(adIcon, Scene_Index);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);

        }
    }

    public void MoreAppsHideAdIcon(GameObject adIcon, int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {

            Debug.Log("MoreAppsHideAdIcon");
            ConsoliAds.Instance.DestoryIconAd(adIcon, Scene_Index);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);

        }
    }

    public void ShowRewardedVideo(int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
            Debug.Log("ShowRewardedVideo");
            ConsoliAds.Instance.ShowRewardedVideo(Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public void LoadRewardedVideo(int Scene_Index)
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;
        try
        {
            Debug.Log("ShowRewardedVideo");
            ConsoliAds.Instance.LoadRewarded(Scene_Index);
        }
        catch (Exception e)
        {
			Debug.LogError(e.Message);

        }
    }

    public bool IsRewardedVideoAvailable(int Scene_Index)
    {

       // Debug.Log("IsRewardedVideoAvailable");

        return ConsoliAds.Instance.IsRewardedVideoAvailable(Scene_Index);
    }

    public void onRewardedVideoCompleted()
    {
        //Debug.Log("onRewardedVideoCompleted");
       // RewardedVideoAck.text = "onRewardedVideoCompleted";
    }


    #region Native Callbacks

    void onConsoliAdsInitialization()
    {
       // Debug.Log("Native Callabcks onConsoliAdsInitialization");
    }

    void onInterstitialAdShown()
    {
       // Debug.Log("Native Callabcks onInterstitialAdShown");
    }

    void onInterstitialAdClicked()
    {
       // Debug.Log("Native Callabcks onInterstitialAdClicked");
    }

    void onVideoAdShown()
    {
       // Debug.Log("Native Callabcks onVideoAdShown");
    }

    void onVideoAdClicked()
    {
       // Debug.Log("Native Callabcks onVideoAdClicked");
    }

    void onRewardedVideoAdShown()
    {
       // Debug.Log("Native Callabcks onRewardedVideoAdShown");
    }

    void onRewardedVideoAdCompleted()
    {
        if (PlayerPrefManager.Instance.IsAdsRemoved())
            return;

      //  Debug.Log("Native Callabcks onRewardedVideoAdCompleted");

		//if (FindObjectOfType<RewardedVideo> () != null && ExchangeCoins.IsExchangeCoins) 
		//{
		//	FindObjectOfType<RewardedVideo> ().ExchnageCoinsButton.interactable = true;
		//	Debug.Log("Native Callabcks onRewardedVideoAdCompleted ExchnageCoinsButton Active");
		//}

		//if (FindObjectOfType<RewardedVideo> () != null && GetFreeTurn.IsGetFreeTurn) 
		//{
		//	FindObjectOfType<RewardedVideo> ().FreeTurnButton.interactable = true;
		//	Debug.Log("Native Callabcks onRewardedVideoAdCompleted FreeTurnButton Active");
		//}
        //if(GetBullets.isGetBullets)
        //{
        //    GetBullets.isGetBullets = false;
        //    //Give reward;
        //    GameDialogs_LS6.instance.GetMoreBullets();
        //    //Button Disable
        //    WeaponBehavior.inst.GetMoreBullets.SetActive(false);
        //}
        

    }

    void onRewardedVideoAdClick()
    {
        //Debug.Log("Native Callabcks onRewardedVideoAdClick");
    }

    void onPopupAdShown()
    {
       // Debug.Log("Native Callabcks onPopupAdShown");
    }

    void onNativeAdLoaded()
    {
       // Debug.LogError("Native Callabcks onNativeAdLoaded");
    }

    void onNativeAdFailedToLoad()
    {
       // Debug.LogError("Native Callabcks onNativeAdFailedToLoad");
    }

    #endregion
}
