using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
	public GameObject _exitpannel;
    public GameObject PurchaseAdd;
    // Use this for initialization
    public void Awake()
    {

        if (PlayerPrefManager.Instance.IsAdsRemoved())
            PurchaseAdd.SetActive(false);
    }
    public void RemoveAdd()
    {
        InApp_Manager.instance.Buy_UnlockAll_Removeads();
    }
    void Start () {
        Time.timeScale = 1f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	public void _play()
	{
		  CustomAnalytics.logLevelStarted ("OnPlay","MainMenu");
		SceneManager.LoadScene("LevelSelection");

	}
	public void yes()
	{
		  CustomAnalytics.logLevelStarted ("OnExit","Yes");
		Application.Quit ();
	}
	public void no()
	{
	  CustomAnalytics.logLevelStarted ("OnExit","No");
	//	AdsMainManagerController.instance.Load_Banner_Ad();
	//	AdCallingHelper.AdCallingHelper_ins.HideBigBanner ();
		_exitpannel.SetActive (false);
	}
	public void _exit()
	{
		  CustomAnalytics.logLevelStarted ("OnExit","MainMenu");
  //      AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.EXIT);
        _exitpannel.SetActive (true);
	}

	public void _rateus()
	{

	  CustomAnalytics.logLevelStarted ("MainMenu","RateUS");
      GaminatorAds.Instance.RateUs();
	
	}

	public void _moregame()
	{
	 CustomAnalytics.logLevelStarted ("MainMenu","More");
        GaminatorAds.Instance.MoreApps();
       
    }

	public void Unlockalllevels()
	{
        InApp_Manager.instance.Buy_UnlockAll_Levels();
	}
    public void Unlockall()
    {
        InApp_Manager.instance.Buy_UnlockAll();
    }
   

}
