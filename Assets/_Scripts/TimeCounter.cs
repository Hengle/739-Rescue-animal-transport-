using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour {
	public Text TimerText;
	public float Minutes;
	public float Seconds;
	bool flag=true;
	public GameObject timeup, succes_store, Fail_store;
    private GameObject tempgameobject;
	public bool check=false;
	bool stop;
	void Start()
	{
		check = true;
	//	Gads.RequestInterstitial ();
		stop=false;

	}

	void Update()
	{
		if(Seconds < 10)
		{
			TimerText.text = (Minutes + ":0" + Seconds);
		}
		if(Seconds > 9)
		{
			TimerText.text = (Minutes + ":" + Seconds);
		}


	}
	public void CountDown()
	{
		if (check == true) {
			if (Seconds <= 0) {
				MinusMinute ();
				Seconds = 60;
			}
			if (Minutes >= 0) {
				MinusSeconds ();
			}
			if (Minutes <= 0 && Seconds <= 0) {
                Fail_store.SetActive(true);
                //timeup.SetActive (true);
                //				PlayerPrefs.GetInt("coins");
                //				PlayerPrefs.SetInt ("coins" , PlayerPrefs.GetInt("coins")+PlayerPrefs.GetInt("setcoin") );
                tempgameobject = GameObject.Find ("All Audio Sources");
				if (tempgameobject != null) {
					tempgameobject.SetActive (false);
				}
				StopTimer ();
               // Invoke("timee", 0f);
				Time.timeScale = 0;
				if(stop==false){
                    //AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
  //                CustomAnalytics.logLevelFailed ("Fail","Timeup");
                    stop = true;
			}
			}else {
				StartTime ();
			}
		}
	}
    public void timee()
    {
        Time.timeScale = 0;
    }
    public void MinusMinute()
	{
		Minutes -= 1;
	}
	public void MinusSeconds()
	{
		Seconds -= 1;
	}

	public IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);

		CountDown();
	}
	public void StopTimer()
	{
		Seconds = 0;
		Minutes = 0;
	}
	public void StartTime()
	{
		StartCoroutine(Wait());
	}
}	