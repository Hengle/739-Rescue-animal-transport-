using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using GameAnalyticsSDK;

public class CustomAnalytics
{

	private static int ConsentValue = -1;
	/*private static string replacedLevelString;
	private static string replacedLevelNoString;
    private static string replacedWorldString;*/


	private static int getConsentValue()
	{
		if (ConsentValue <= 1)
		{
			ConsentValue = PlayerPrefs.GetInt("ConsentValue", 0);
		}

		return ConsentValue;
	}

	public static void logLevelStarted(string level, string levelNo)
	{
		//level = level.Replace(" ", "_");
        Debug.Log("level  "+ level);

		try
		{
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level" + level + "_" + levelNo);
				//Firebase.Analytics.FirebaseAnalytics.LogEvent("level_started_" + level + "_" + levelNo);
				Debug.Log("Analytics: level_started" + level + "_" + levelNo);
                Debug.Log("Analytics: logLevelStarted:" + level + ":" + levelNo);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}

    public static void logNotificationOpened(string level)//, string levelNo)
    {
        //level = level.Replace(" ", "_");
        Debug.Log("level  " + level);

        try
        {
            //  Firebase.Analytics.FirebaseAnalytics.LogEvent("Open_" + level);
                GameAnalytics.NewDesignEvent("Open_" + level);
                Debug.Log("Analytics: Open_" + level );
             // Debug.Log("Analytics: Open_Notification_:" + level);
        }
        catch (Exception e)
        {
            Debug.Log("Analytics: Error in Analytics: " + e.ToString());

        }

    }

    public static void logLevelStarted(string world, string level, string levelNo)
	{
		level = level.Replace(" ", "_");

		try
		{
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level" + level + "_" + levelNo);
            //	Firebase.Analytics.FirebaseAnalytics.LogEvent("level_started_" + level + "_" + levelNo);
            Debug.Log("Analytics: level_started" + level + "_" + levelNo);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public static void logLevelFailed(string level, string levelNo)
	{
		level = level.Replace(" ", "_");
		try
		{
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level" + level + "_" + levelNo);
            //	Firebase.Analytics.FirebaseAnalytics.LogEvent("level_failed_" + level + "_" + levelNo);
            Debug.Log("Analytics: level_failed_" + level + "_" + levelNo);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}

	public static void logLevelFailed(string world, string level, string levelNo)
	{
		level = level.Replace(" ", "_");
		try
		{
            //	Firebase.Analytics.FirebaseAnalytics.LogEvent("level_failed_" + level + "_" + levelNo);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level" + level + "_" + levelNo);
            Debug.Log("Analytics: level_failed_" + level + "_" + levelNo);
			Debug.Log("Analytics: logLevelFailed:" + world + ":" + level + ":" + levelNo);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public static void logLevelCompleted(string level, string levelNo)
	{
		level = level.Replace(" ", "_");
		try
		{
            //	Firebase.Analytics.FirebaseAnalytics.LogEvent("level_completed_" + level + "_" + levelNo);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level" + level + "_" + levelNo);
            Debug.Log("Analytics: level_completed_" + level + "_" + levelNo);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public static void logLevelCompleted(string world, string level, string levelNo)
	{
		level = level.Replace(" ", "_");
		try
		{
            //	Firebase.Analytics.FirebaseAnalytics.LogEvent("level_completed_" + level + "_" + levelNo);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level" + level + "_" + levelNo);
            Debug.Log("Analytics: level_completed_" + level + "_" + levelNo);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public static void logDesignEvent(string eventName)
	{
		eventName = eventName.Replace(" ", "_");
		try
		{
            //Firebase.Analytics.FirebaseAnalytics.LogEvent(eventName);
            GameAnalytics.NewDesignEvent(eventName);
            Debug.Log("Analytics: " + eventName);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}
    /*public static void app_launch_event(string content,string time)
    {
		//tempFunc();
        if (getConsentValue() == 2)
        {
            try
            {
				Firebase.Analytics.FirebaseAnalytics.LogEvent("AppLaunchTime", content,time);
            }
            catch (Exception e)
            {
                Debug.Log("Analytics: Error in Analytics: " + e.ToString());

            }
        }
        else
        {
            Debug.Log("Analytics: Cant LogEvent: Consent is Not Given...");
        }
    }

	public static void spent_virtual_currency(string currency, int amount)
	{


		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("spend_virtual_currency", currency, amount);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}

	public static void earn_virtual_currency(string currency, int amount)
	{

		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("earn_virtual_currency", currency, amount);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}

	public static void upgrade_item(string name, string details)
	{

		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("item_updrade", name, details);
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());
		}
	}
    */


}
