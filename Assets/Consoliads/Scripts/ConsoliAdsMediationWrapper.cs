using UnityEngine;
using System.Runtime.InteropServices;

class ConsoliAdsMediationWrapper
{
	/*
	 * 
	 * Disabling All other because unity coordinate system is bottom Left
	 */

	//const int KCoordinateSystemTopLeft = 0;
	const int KCoordinateSystemBottomLeft = 1;
    //const int KCoordinateSystemBottomRight = 2;
    //const int KCoordinateSystemTopRight = 3;


#if UNITY_EDITOR

    public ConsoliAdsMediationWrapper()
	{
	}

	public void initializeWithProductName(Platform platform, string productName, string bundleIdentifier, string gameObjectName, bool consent)
	{
		
		Debug.Log("Please run on device to test Ads, Now showing scene/ads from prefab");
		ConsoliAds.Instance.didInitialize("");
	}

	public void onPrefebDataFetched(string appJson)
	{

	}

	public void loadRewarded(int index)
	{
		
	}

	public void showBanner(int index , ConsoliAdsBannerView consoliAdsBannerView)
	{
		/*
		switch (consoliAdsBannerView.getBannerType ()) 
		{
			case BannerType.PORTAL:
			{
				break;
			}
			case BannerType.CUSTOM_SIZE:
			{
				break;
			}
			case BannerType.CUSTOM_POSITION:
			{
				break;
			}
			case BannerType.CUSTOM_SIZE_POSITION:
			{
				break;
			}
		}*/
	}

	public void hideBanner(ConsoliAdsBannerView consoliAdsBannerView)
	{
		
	}

	public void showInterstitial(int index)
	{
	}
		
    public void showRewardedVideo(int index)
	{
	}

	public bool isInterstitialAvailable(int index)
	{
		return false;
	}

	public bool isRewardedVideoAvailable(int index)
	{
		return false;
	}

	public void showNativeAd(int index, float x, float y, float baseWidth, float baseHeight)
	{
		
	}

	public void hideNativeAd(int index)
	{

	}

	public void showIconAd(int instanceID,int index, float x, float y, float baseWidth, float baseHeight , int animationType)
	{
	}

	public void destoryIconAd(int instanceID, int index)
	{
		
	}

	public void hideAllAds()
	{
		
	}

	public void addAdmobTestDevice(string deviceID)
	{
		Debug.Log("Test Device can be added in real device : "+deviceID);
	}

    /*
	public bool isInteractiveAvailable(int index)
	{
		return false;
	}
    */

	public void showInteractive(int index)
	{
		
	}

	public void onDataReceivedFromPlatform( string json )
	{
		Debug.Log ("Sending Data : "+ json);
	}

#elif UNITY_ANDROID

    private static AndroidJavaObject activityContext = null;
	private static AndroidJavaObject _plugin = null;

	public ConsoliAdsMediationWrapper()
	{

		//getting current activity context to be passed into the android sdk
		using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
		// find the plugin instance

		using (var pluginClass = new AndroidJavaClass("com.consoliads.mediation.ConsoliAdsMediationUnityPlugin"))
			_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");

	}

	public void initializeWithProductName(Platform platform, string productName, string bundleIdentifier, string gameObjectName, bool consent)
	{
		if (_plugin != null)
		{
	_plugin.Call("initialize", activityContext, (int)platform, productName, bundleIdentifier, gameObjectName, consent , CAConstants.ConsoliAdsVersion ,CAConstants.sdkVersionID ,ConsoliAds.Instance.DevMode);
		}
	}

	public void loadRewarded(int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("loadRewardedVideo", index);
		}
	}

	public void showBanner(int index , ConsoliAdsBannerView consoliAdsBannerView)
	{
		if (_plugin != null)
		{
			switch (consoliAdsBannerView.getBannerType ()) 
			{
			case BannerType.PORTAL:
				{
					_plugin.Call("showBanner", consoliAdsBannerView.getBannerID() , index);
					break;
				}
			case BannerType.CUSTOM_SIZE:
				{
					_plugin.Call("showBanner", consoliAdsBannerView.getBannerID() , index , consoliAdsBannerView.getAdSize().width , consoliAdsBannerView.getAdSize().height );
					break;
				}
			case BannerType.CUSTOM_POSITION:
				{
					_plugin.Call ("showBanner", consoliAdsBannerView.getBannerID (), index, consoliAdsBannerView.getAdPosition ().x, consoliAdsBannerView.getAdPosition ().y);
					break;
				}
			case BannerType.CUSTOM_SIZE_POSITION:
				{
					_plugin.Call ("showBanner", consoliAdsBannerView.getBannerID (), index, consoliAdsBannerView.getAdSize().width , consoliAdsBannerView.getAdSize().height , consoliAdsBannerView.getAdPosition ().x, consoliAdsBannerView.getAdPosition ().y);
					break;
				}
			}
		}
	}

	public void hideBanner(ConsoliAdsBannerView consoliAdsBannerView)
	{
		if (_plugin != null)
		{
			_plugin.Call("hideBanner" , consoliAdsBannerView.getBannerID() );
		}
	}

	public void showInterstitial(int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("showInterstitial", index);
		}
	}

	public void showRewardedVideo(int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("showRewardedVideo", index);
		}
	}

	public void showNativeAd(int index, float x, float y, float baseWidth, float baseHeight)
	{
		if (_plugin != null)
		{
			_plugin.Call("showNative", index, KCoordinateSystemBottomLeft, baseWidth, baseHeight, x, y);
		}
	}

	public void hideNativeAd(int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("destroyNativeAd", index);
		}
	}

	public void showIconAd(int instanceID, int index, float x, float y, float baseWidth, float baseHeight, int animationType)
	{
		if (_plugin != null)
		{
	_plugin.Call("showIconAd",instanceID, index, KCoordinateSystemBottomLeft, baseWidth, baseHeight, x, y,animationType);
		}
	}

	public void destoryIconAd(int instanceID, int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("destroyIconAd", instanceID, index);
		}	
	}
	
	public bool isInterstitialAvailable(int index)
	{
		if (_plugin != null)
		{
			return _plugin.Call<bool>("isInterstitialAvailable", index);
		}
		return false;
	}

	public bool isRewardedVideoAvailable(int index)
	{
		if (_plugin != null)
		{
			return _plugin.Call<bool>("isRewardedVideoAvailable", index);
		}
		return false;
	}

	public void hideAllAds()
	{
		if (_plugin != null)
		{
			_plugin.Call("hideAllAds");
		}
	}

	public void addAdmobTestDevice(string deviceID)
	{
		if (_plugin != null)
		{
			_plugin.Call("addAdmobTestDevice" , deviceID);
		}
	}

	public void onDataReceivedFromPlatform( string json )
	{
		if (_plugin != null)
		{
			_plugin.Call("onDataReceivedFromPlatform" , json);
		}
	}

    /*
	public bool isInteractiveAvailable(int index)
	{
		if (_plugin != null)
		{
			return _plugin.Call<bool>("isInteractiveAvailable", index);
		}
		return false;
	}

	public void showInteractive(int index)
	{
		if (_plugin != null)
		{
			_plugin.Call("showInteractive", index);
		}
	}
    */

#elif UNITY_IPHONE

    [DllImport("__Internal")]
	private static extern void _initializeWithProductName(string productName, string bundleIdentifier, string gameObjectName, bool consent, string ConsoliAdsVersion , string sdkVersionID, bool devMode);

	[DllImport("__Internal")]
	private static extern void _onDataReceivedFromPlatform(string json);

	[DllImport("__Internal")]
	private static extern void _showInterstitial(int scene);

	[DllImport("__Internal")]
	private static extern bool _isInterstitialAvailable(int scene);

	[DllImport("__Internal")]
	private static extern bool _isRewardedVideoAvailable(int scene);

	[DllImport("__Internal")]
	private static extern void _loadRewardedVideo(int scene);

	[DllImport("__Internal")]
	private static extern void _showRewardedVideo(int scene);

	[DllImport("__Internal")]
	private static extern void _showBanner(int instanceID , int scene);

    [DllImport("__Internal")]
	private static extern void _showBannerWithCustomPosition(int instanceID , int index, double x, double y);

    [DllImport("__Internal")]
	private static extern void _showBannerWithCustomSize(int instanceID , int index, int width, int height);

    [DllImport("__Internal")]
	private static extern void _showBannerWithCustomSizeNPosition(int instanceID , int index, int width, int height, double x, double y);

    [DllImport("__Internal")]
	private static extern void _hideBanner(int instanceID);

	[DllImport("__Internal")]
	private static extern void _hideAllAds();

	[DllImport("__Internal")]
	private static extern void _showNativeAd(int scene, int coordinateSystemType, float screenWidth, float screenHeight, float x, float y);

	[DllImport("__Internal")]
	private static extern void _hideNativeAd(int scene);

	[DllImport("__Internal")]
	private static extern void _showIconAd(int instanceID, int scene, int coordinateSystemType, float screenWidth, float screenHeight, float x, float y, int animationType);

	[DllImport("__Internal")]
	private static extern void _hideIconAd(int instanceID, int scene);

	[DllImport("__Internal")]
	private static extern void _addAdmobTestDevice(string deviceID);

	public ConsoliAdsMediationWrapper()
	{
	}

	public void initializeWithProductName(Platform platform, string productName, string bundleIdentifier, string gameObjectName, bool consent)
	{
	_initializeWithProductName(productName, bundleIdentifier, gameObjectName, consent,CAConstants.ConsoliAdsVersion , CAConstants.sdkVersionID, ConsoliAds.Instance.DevMode);
	}

	public void loadRewarded(int index)
	{
		_loadRewardedVideo(index);
	}

	public void showBanner(int index , ConsoliAdsBannerView consoliAdsBannerView)
	{
		switch (consoliAdsBannerView.getBannerType ()) 
		{
		case BannerType.PORTAL:
			{
				_showBanner(consoliAdsBannerView.getBannerID(),index);
				break;
			}
		case BannerType.CUSTOM_SIZE:
			{
				_showBannerWithCustomSize(consoliAdsBannerView.getBannerID(),index , consoliAdsBannerView.getAdSize().width , consoliAdsBannerView.getAdSize().height );
				break;
			}
		case BannerType.CUSTOM_POSITION:
			{
				_showBannerWithCustomPosition(consoliAdsBannerView.getBannerID(),index, consoliAdsBannerView.getAdPosition ().x, consoliAdsBannerView.getAdPosition ().y);
				break;
			}
		case BannerType.CUSTOM_SIZE_POSITION:
			{
				_showBannerWithCustomSizeNPosition(consoliAdsBannerView.getBannerID(),index , consoliAdsBannerView.getAdSize().width , consoliAdsBannerView.getAdSize().height , consoliAdsBannerView.getAdPosition ().x, consoliAdsBannerView.getAdPosition ().y );
				break;
			}
		}
	}

	public void hideBanner(ConsoliAdsBannerView consoliAdsBannerView)
	{
		_hideBanner(consoliAdsBannerView.getBannerID());
	}

	public void showInterstitial(int index)
	{
		_showInterstitial(index);
	}

	public void showRewardedVideo(int index)
	{
		_showRewardedVideo(index);
	}

	public bool isInterstitialAvailable(int index)
	{
		return _isInterstitialAvailable(index);
	}

	public bool isRewardedVideoAvailable(int index)
	{
		return _isRewardedVideoAvailable(index);
	}

	public void showNativeAd(int index, float x, float y, float baseWidth, float baseHeight)
    {
        _showNativeAd(index, KCoordinateSystemBottomLeft, baseWidth, baseHeight, x, y);
    }

    public void hideNativeAd(int index)
    {
        _hideNativeAd(index);
    }

	public void showIconAd(int instanceID, int index, float x, float y, float baseWidth, float baseHeight, int animationType)
    {
	_showIconAd(instanceID, index, KCoordinateSystemBottomLeft, baseWidth, baseHeight, x, y,animationType);
    }

	public void destoryIconAd(int instanceID,int index)
	{
        _hideIconAd(instanceID, index);
	}

	public void hideAllAds()
	{
		_hideAllAds();
	}

	public void addAdmobTestDevice(string deviceID)
	{
		_addAdmobTestDevice(deviceID);
	}

	public void onDataReceivedFromPlatform( string json )
	{
		_onDataReceivedFromPlatform(json);
	}

    /*
	public bool isInteractiveAvailable(int index)
	{

	}

	public void showInteractive(int index)
	{

	}
    */

#endif

}