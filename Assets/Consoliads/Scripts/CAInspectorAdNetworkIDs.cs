using UnityEngine;
using System;
using System.Collections;
using SimpleJSON;

[Serializable]
public class CAInspectorAdNetworkIDs
{

	public AdmobIds Admob;
	public ChartboostIds Chartboost;
	public FacebookIds Facebook;
	[HideInInspector] public OguryIds Ogury;
	[HideInInspector] public MyTargetIds MyTarget;
	[HideInInspector] public MintegralIds Mintegral; 
	//public AtmosplayIds Atmosplay;
	[HideInInspector] public string LeadboltAppKey;

	[HideInInspector] public string KidozPubId;
	[HideInInspector] public string KidozSecToken;
	[HideInInspector] public string ConsoliadsAppKey;
	[HideInInspector] public string HeyzapID;
	[HideInInspector] public string RevmobMediaID;
	[HideInInspector] public string UnityadsAppID;
	[HideInInspector] public string AdcolonyAppID;
	[HideInInspector] public string AdcolonyInterstitialZoneID;
	[HideInInspector] public string AdcolonyRewardedZoneID;
	[HideInInspector] public string AdColonyBannerZoneID;
	[HideInInspector] public string IronsourceAppKey;
	[HideInInspector] public string ApplovinID;
	[HideInInspector] public string VungleID;
	[HideInInspector] public string VunglePlacementName;
	[HideInInspector] public string VungleBannerPlacement;
	[HideInInspector] public string TapJoyID;
	[HideInInspector] public string TapJoyPlacement;
	[HideInInspector] public string MobVistaAppID;
	[HideInInspector] public string MobVistaAppKey;
	[HideInInspector] public string MobVistaInterstitialID;
	[HideInInspector] public string MobVistaVideoID;
	[HideInInspector] public string unityAdsBannerPlacement;
	[HideInInspector] public string tapJoyRewardedPlacement;
	[HideInInspector] public string vungleRewardedPlacementID;
	[HideInInspector] public string InmobiAccountID;
	[HideInInspector] public string InmobiInterstitialPlacement;
	[HideInInspector] public string InmobiRewardedVideoPlacement;
	[HideInInspector] public string InmobiBannerAdPlacement;
	[HideInInspector] public string StartappDeveloperId;
	[HideInInspector] public string StartappApplicationId;
	[HideInInspector] public string MobfoxInterstitialAdUnit;
	[HideInInspector] public string MobfoxRewardedVideoAdUnit;
	[HideInInspector] public string MobfoxBannerAdUnit;
	[HideInInspector] public string MopubIntesrstialAdUnit;
	[HideInInspector] public string MopubRewardedAdUnit;
	[HideInInspector] public string mopubBannerAdUnit;
	[HideInInspector] public string mopubNativeAdUnit;

    [Serializable]
    public class OguryIds
    {
        public string OguryInterstitialAdUnit;
        public string OguryRewardedVideoAdUnit;
        public string OguryAPIKey;
    }

    [Serializable]
    public class MyTargetIds
    {
        public string MyTargetInterstitialSlotID;
        public string MyTargetBannerAdSlotID;
        public string myTargetRewardedAdSlotID;
    }

    [Serializable]
    public class ChartboostIds
    {
        public string ChartboostAppID;
        public string ChartboostAppSignature;
    }

    [Serializable]
    public class AdmobIds
    {
        public string AdmobAppID;
        public string AdmobBannerAdUnitID;
        public string AdmobInterstitialAdUnitID;
        public string AdmobRewardedVideoAdUnitID;
        public string AdmobNativeAdUnitID;
    }

    [Serializable]
    public class FacebookIds
    {
        public string FacebookBannerId;
        public string FacebookInterstitialUnitId;
        public string FacebookRewardedUnitId;
        public string FacebookNativeId;
    }

	[Serializable]
	public class MintegralIds
	{
		public string MintegralAppKey;
		public string MintegralAPPID;
		public string MintegralInterstitialID;
		public string MintegralRewardedID;
		public string MintegralVideoID;
		public string MintegralNativeID;
		public string MintegralBannerPlacement;
	}

	/*
	[Serializable]
	private class AtmosplayIds
	{
		public string AtmosplayAPPID;
		public string AtmosplayInterstitialAdUnitID;
		public string AtmosplayRewardedVideoAdUnitID;
		public string AtmosplayNativeAdUnitID;
	}*/

	public void setupAdIds(NetworkAdIDType type, Platform platform, String key ,Platform selectedPlatform )
	{
		if (selectedPlatform == platform) 
		{
            switch (type)
			{
			case NetworkAdIDType.ConsoliadsAppKey:
				this.ConsoliadsAppKey = key;
				break;
			case NetworkAdIDType.ChartboostAppID:
				this.Chartboost.ChartboostAppID = key;
				break;
			case NetworkAdIDType.ChartboostAppSignature:
				this.Chartboost.ChartboostAppSignature = key;
				break;
			case NetworkAdIDType.AdmobAppID:
				this.Admob.AdmobAppID = key;
				break;
			case NetworkAdIDType.AdmobBannerAdUnitID:
				this.Admob.AdmobBannerAdUnitID = key;
				break;
			case NetworkAdIDType.AdmobInterstitialAdUnitID:
				this.Admob.AdmobInterstitialAdUnitID = key;
				break;
			case NetworkAdIDType.AdmobRewardedVideoAdUnitID:
				this.Admob.AdmobRewardedVideoAdUnitID = key;
				break;
			case NetworkAdIDType.AdmobNativeAdID:
				this.Admob.AdmobNativeAdUnitID = key;
				break;
			case NetworkAdIDType.UnityAdsID:
				this.UnityadsAppID = key;
				break;
			case NetworkAdIDType.AdColonyAppID:
				this.AdcolonyAppID = key;
				break;
			case NetworkAdIDType.AdColonyInterstitialZoneID:
				this.AdcolonyInterstitialZoneID = key;
				break;
			case NetworkAdIDType.AdColonyRewardedZoneID:
				this.AdcolonyRewardedZoneID = key;
				break;
			case NetworkAdIDType.AdColonyBannerZoneID:
				this.AdColonyBannerZoneID = key;
				break;
			case NetworkAdIDType.IronsourceAppKey:
				this.IronsourceAppKey = key;
				break;
			case NetworkAdIDType.AppLovinID:
				this.ApplovinID = key;
				break;
			case NetworkAdIDType.VungleAdID:
				this.VungleID = key;
				break;
			case NetworkAdIDType.TapJoyAdID:
				this.TapJoyID = key;
				break;
			case NetworkAdIDType.TapJoyPlacement:
				this.TapJoyPlacement = key;
				break;
			case NetworkAdIDType.FacebookBannerID:
				this.Facebook.FacebookBannerId = key;
				break;
			case NetworkAdIDType.FacebookNativeID:
				this.Facebook.FacebookNativeId = key;
				break;
			case NetworkAdIDType.FacebookInterstitialUnitID:
				this.Facebook.FacebookInterstitialUnitId = key;
				break;
			case NetworkAdIDType.FacebookRewardedUnitID:
				this.Facebook.FacebookRewardedUnitId = key;
				break;
			case NetworkAdIDType.StartAppDeveloperID:
				this.StartappDeveloperId = key;
				break;
			case NetworkAdIDType.StartAppApplicationID:
				this.StartappApplicationId = key;
				break;
			case NetworkAdIDType.KidozPubID:
				this.KidozPubId = key;
				break;
			case NetworkAdIDType.KidozSecToken:
				this.KidozSecToken = key;
				break;
			case NetworkAdIDType.MopubIntesrstialAdUnit:
				this.MopubIntesrstialAdUnit = key;
				break;
			case NetworkAdIDType.MopubRewardedAdUnit:
				this.MopubRewardedAdUnit = key;
				break;
			case NetworkAdIDType.VunglePlacementID:
				this.VunglePlacementName = key;
				break;
			case NetworkAdIDType.InmobiAccountID:
				this.InmobiAccountID = key;
				break;
			case NetworkAdIDType.InmobiInterstitialPlacement:
				this.InmobiInterstitialPlacement = key;
				break;
			case NetworkAdIDType.InmobiRewardedVideoPlacement:
				this.InmobiRewardedVideoPlacement = key;
				break;
			case NetworkAdIDType.InmobiBannerAdPlacement:
				this.InmobiBannerAdPlacement = key;
				break;
			case NetworkAdIDType.MobfoxInterstitialAdUnit:
				this.MobfoxInterstitialAdUnit = key;
				break;
			case NetworkAdIDType.MobfoxRewardedVideoAdUnit:
				this.MobfoxRewardedVideoAdUnit = key;
				break;
			case NetworkAdIDType.MobfoxBannerAdUnit:
				this.MobfoxBannerAdUnit = key;
				break;
            case NetworkAdIDType.UnityAdsBannerPlacement:
                this.unityAdsBannerPlacement = key;
                break;
            case NetworkAdIDType.MopubBannerAdUnit:
                this.mopubBannerAdUnit = key;
                break;
			case NetworkAdIDType.MopubNativeAdUnit:
				this.mopubNativeAdUnit = key;
				break;
            case NetworkAdIDType.TapJoyRewardedPlacement:
                this.tapJoyRewardedPlacement = key;
                break;
            case NetworkAdIDType.VungleRewardedPlacementID:
                this.vungleRewardedPlacementID = key;
                break;
			case NetworkAdIDType.VungleBannerPlacement:
				this.VungleBannerPlacement = key;
				break;
			}
		}
	}
   
	public void clearInspectorAdIds(Platform platform)
	{
		foreach (NetworkAdIDType value in Enum.GetValues(typeof(NetworkAdIDType))) 
		{
			setupAdIds (value,platform,"",platform);
		}
	}

	public void setAdIDs(JSONClass strJson  ,Platform platform)
	{
		int index = 0;
	
		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdmobAppID;
		strJson ["adIDs"] [index] ["adValue"] = this.Admob.AdmobAppID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdmobInterstitialAdUnitID;
		strJson ["adIDs"] [index] ["adValue"] = this.Admob.AdmobInterstitialAdUnitID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdmobRewardedVideoAdUnitID;
		strJson ["adIDs"] [index] ["adValue"] = this.Admob.AdmobRewardedVideoAdUnitID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdmobBannerAdUnitID;
		strJson ["adIDs"] [index] ["adValue"] = this.Admob.AdmobBannerAdUnitID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdmobNativeAdID;
		strJson ["adIDs"] [index] ["adValue"] = this.Admob.AdmobNativeAdUnitID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.ChartboostAppID;
		strJson ["adIDs"] [index] ["adValue"] = this.Chartboost.ChartboostAppID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.ChartboostAppSignature;
		strJson ["adIDs"] [index] ["adValue"] = this.Chartboost.ChartboostAppSignature;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.FacebookInterstitialUnitID;
		strJson ["adIDs"] [index] ["adValue"] = this.Facebook.FacebookInterstitialUnitId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.FacebookRewardedUnitID;
		strJson ["adIDs"] [index] ["adValue"] = this.Facebook.FacebookRewardedUnitId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.FacebookBannerID;
		strJson ["adIDs"] [index] ["adValue"] = this.Facebook.FacebookBannerId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.FacebookNativeID;
		strJson ["adIDs"] [index] ["adValue"] = this.Facebook.FacebookNativeId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralAPPID;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralAPPID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralAppKey;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralAppKey;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralInterstitialID;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralInterstitialID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralRewardedID;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralRewardedID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralVideoID;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralVideoID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;
	
		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralBannerPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralBannerPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MintegralNativeID;
		strJson ["adIDs"] [index] ["adValue"] = this.Mintegral.MintegralNativeID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;
		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.KidozPubID;
		strJson ["adIDs"] [index] ["adValue"] = this.KidozPubId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.KidozSecToken;
		strJson ["adIDs"] [index] ["adValue"] = this.KidozSecToken;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.ConsoliadsAppKey;
		strJson ["adIDs"] [index] ["adValue"] = this.ConsoliadsAppKey;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.UnityAdsID;
		strJson ["adIDs"] [index] ["adValue"] = this.UnityadsAppID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.UnityAdsBannerPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.unityAdsBannerPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdColonyAppID;
		strJson ["adIDs"] [index] ["adValue"] = this.AdcolonyAppID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdColonyInterstitialZoneID;
		strJson ["adIDs"] [index] ["adValue"] = this.AdcolonyInterstitialZoneID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdColonyRewardedZoneID;
		strJson ["adIDs"] [index] ["adValue"] = this.AdcolonyRewardedZoneID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AdColonyBannerZoneID;
		strJson ["adIDs"] [index] ["adValue"] = this.AdColonyBannerZoneID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.IronsourceAppKey;
		strJson ["adIDs"] [index] ["adValue"] = this.IronsourceAppKey;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.AppLovinID;
		strJson ["adIDs"] [index] ["adValue"] = this.ApplovinID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.VungleAdID;
		strJson ["adIDs"] [index] ["adValue"] = this.VungleID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.VunglePlacementID;
		strJson ["adIDs"] [index] ["adValue"] = this.VunglePlacementName;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.VungleRewardedPlacementID;
		strJson ["adIDs"] [index] ["adValue"] = this.vungleRewardedPlacementID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.VungleBannerPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.VungleBannerPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.TapJoyAdID;
		strJson ["adIDs"] [index] ["adValue"] = this.TapJoyID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.TapJoyPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.TapJoyPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.TapJoyRewardedPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.tapJoyRewardedPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.InmobiAccountID;
		strJson ["adIDs"] [index] ["adValue"] = this.InmobiAccountID;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.InmobiInterstitialPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.InmobiInterstitialPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.InmobiRewardedVideoPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.InmobiRewardedVideoPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.InmobiBannerAdPlacement;
		strJson ["adIDs"] [index] ["adValue"] = this.InmobiBannerAdPlacement;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.StartAppDeveloperID;
		strJson ["adIDs"] [index] ["adValue"] = this.StartappDeveloperId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.StartAppApplicationID;
		strJson ["adIDs"] [index] ["adValue"] = this.StartappApplicationId;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MopubIntesrstialAdUnit;
		strJson ["adIDs"] [index] ["adValue"] = this.MopubIntesrstialAdUnit;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MopubRewardedAdUnit;
		strJson ["adIDs"] [index] ["adValue"] = this.MopubRewardedAdUnit;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MopubBannerAdUnit;
		strJson ["adIDs"] [index] ["adValue"] = this.mopubBannerAdUnit;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;

		strJson ["adIDs"] [index] ["OS"].AsInt = (int)platform;
		strJson ["adIDs"] [index] ["adValueType"].AsInt = (int)NetworkAdIDType.MopubNativeAdUnit;
		strJson ["adIDs"] [index] ["adValue"] = this.mopubNativeAdUnit;
		strJson ["adIDs"] [index] ["adID"] = "";
		index++;
	}
		
}
