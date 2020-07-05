using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodManager : MonoBehaviour {
	public GameObject _env,_HorseMode,_LionMode,_SheepMode,_CowMode,_DeerMode,_dogMode;
	public GameObject _pausepannel,levelcomplete,levelfaild,succes_store, Fail_store;
	void Awake()
	{
		Time.timeScale = 1f;
		//Instantiate (_env);
		if(PlayerPrefs.GetInt("MHorse")==1)
		{
			_HorseMode.gameObject.SetActive (true);
		}

		else	if(PlayerPrefs.GetInt("MLion")==1)
		{
			_LionMode.gameObject.SetActive (true);
		}

		else	if(PlayerPrefs.GetInt("MSheep")==1)
		{
			_SheepMode.gameObject.SetActive (true);
		}

		else	if(PlayerPrefs.GetInt("MCow")==1)
		{
			_CowMode.gameObject.SetActive (true);
		}

		else	if(PlayerPrefs.GetInt("MDeer")==1)
		{
			_DeerMode.gameObject.SetActive (true);
		}

		else	if(PlayerPrefs.GetInt("MDog")==1)
		{
			_dogMode.gameObject.SetActive (true);
		}


	}
	// Use this for initialization
	void Start () {
		
	}
    public void timee()
    {
        Time.timeScale = 0;
    }
    public void _pause()
	{
		
        //AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.SELECTION);
       //  //CustomAnalytics.logLevelStarted("Pause", "Gameplay");
        Invoke("timee", 0f);
        _pausepannel.SetActive (true);
	}

	public void _resume()
	{
		
		Time.timeScale = 1f;
		_pausepannel.SetActive (false);
		
		  //CustomAnalytics.logLevelStarted ("PausePanel","resumebtn");
	}

	public void _restart()
	{

		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
		
		  //CustomAnalytics.logLevelStarted ("Gameplay","_restart");
	}
	public void _home()
	{
		
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
		
		  //CustomAnalytics.logLevelStarted ("gameplay","homebtn");
	}

	public void _Next()
	{
		
		Time.timeScale = 1f;

		if(PlayerPrefs.GetInt("MHorse")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("HLevel");
			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("HLevel", currentlevel + 1);
				Application.LoadLevel ("Gameplay");
			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");
		}
		}
		else	if(PlayerPrefs.GetInt("MLion")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("LLevel");

			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("LLevel", currentlevel+1);
				Application.LoadLevel ("Gameplay");

			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");

			}
		}

		else	if(PlayerPrefs.GetInt("MSheep")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("SLevel");

			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("SLevel", currentlevel+1);
				Application.LoadLevel ("Gameplay");
			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");
			}
		}

		else	if(PlayerPrefs.GetInt("MCow")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("CLevel");

			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("CLevel", currentlevel+1);
				Application.LoadLevel ("Gameplay");
			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");
			}
		}

		else	if(PlayerPrefs.GetInt("MDeer")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("DLevel");

			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("DLevel", currentlevel+1);
				Application.LoadLevel ("Gameplay");
			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");
			}
			
		}



		else	if(PlayerPrefs.GetInt("MDog")==1)
		{
			int currentlevel = PlayerPrefs.GetInt ("DogLevel");

			if (currentlevel < 5) {
				PlayerPrefs.SetInt ("DogLevel", currentlevel+1);
				Application.LoadLevel ("Gameplay");
			}
			else if(currentlevel==5){
				Application.LoadLevel ("LevelSelection");
			}

		}
		//AdCallingHelper.AdCallingHelper_ins.HideBigBanner ();
		  //CustomAnalytics.logLevelStarted ("complete","nextbtn");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
