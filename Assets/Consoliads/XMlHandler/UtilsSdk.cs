 using System;
using UnityEngine;
namespace GamintorAdSdk
{


public class UtilsSdk {
		
	public static bool isDebugOn = false;
	private static string appRateKey = "GSSAppRatedOrNot";
 

	public static void Log(string msg)
	{
		if (isDebugOn) {
						Debug.Log (msg);
				}
	}


	public static bool getBooleanValue(String name)
	{
		int value = PlayerPrefs.GetInt(name);
		if (value == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
		 
	}
	public static void setBooleanValue(String name, bool value)
	{
		PlayerPrefs.SetInt(name, value ? 1 : 0);
	}
	
	public static String getStringValue(String name)
	{
		 return PlayerPrefs.GetString (name, null);
	}
	public static void setStringValue(String name, String value)
	{
		PlayerPrefs.SetString (name, value);
 	}
	
	public static int getIntValue(String name)
	{
		return PlayerPrefs.GetInt (name, 0);
		 
	}
	public static void setIntValue(String name, int value)
	{
		PlayerPrefs.SetInt (name, value);
 	}

	public static void setAdID(String adName, String adID)
	{
		PlayerPrefs.SetString (adName, adID);
		 
	}
	
	public static String getAdID(String adName)
	{
		return PlayerPrefs.GetString(adName,null);
	}


	public static bool isRated()
	{
		 
		int value = PlayerPrefs.GetInt(appRateKey);
		if (value == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public static void setRating()
	{
		PlayerPrefs.SetInt (appRateKey, 1); 
	}
	

	public static bool isInternetConnected()
	{
		return ((Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork ) || (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork));
	}
}

}
