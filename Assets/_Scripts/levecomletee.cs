using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levecomletee : MonoBehaviour {
	public GameObject _levelcomplete, succes_store, Fail_store;
	// Use this for initialization
	void Start () {
		
	}
    public void timee()
    {
        Time.timeScale = 0;
    }
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "animal") 
		{
			
		
			if (PlayerPrefs.GetInt ("MHorse") == 1) {
                print("HUSSAIN5");
                Invoke("timee", 0f);
                succes_store.SetActive(true);

                //_levelcomplete.SetActive (true);
				int no = PlayerPrefs.GetInt ("UnlockLevels");
				int currentlevel = PlayerPrefs.GetInt ("HLevel");
				if (currentlevel < 6) {
					PlayerPrefs.SetInt ("HUnlockLevels", currentlevel + 1);
                   ////CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("HLevel") + "");

                }
				//
				//
			}

			if (PlayerPrefs.GetInt ("MLion") == 1) {
                // //
                print("HUSSAIN4");
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                //_levelcomplete.SetActive (true);
				int currentlevel = PlayerPrefs.GetInt ("LLevel");
				if (currentlevel < 5) {


					PlayerPrefs.SetInt ("LUnlockLevels", currentlevel + 1);
				}
				//
				//CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("LLevel") +"");
			}

			if (PlayerPrefs.GetInt ("MSheep") == 1) {
                ////
                print("HUSSAIN3");
                Invoke("timee", 0f);
                succes_store.SetActive(true);
               // _levelcomplete.SetActive (true);
				int currentlevel = PlayerPrefs.GetInt ("SLevel");
				if (currentlevel < 5) {
					PlayerPrefs.SetInt ("SUnlockLevels", currentlevel + 1);
				}
				//
				//CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("SLevel") +"");
			}


			if (PlayerPrefs.GetInt ("MCow") == 1) {
                // //
                print("HUSSAIN2");
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                // _levelcomplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("CLevel");
				if (currentlevel < 5) {
					PlayerPrefs.SetInt ("CUnlockLevels", currentlevel + 1);
				}
				//
				//CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("CLevel") +"");
		}

			if (PlayerPrefs.GetInt ("MDeer") == 1) {
                //  //
                print("HUSSAIN1");
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                //  _levelcomplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("DLevel");
				if(currentlevel<5)
				{
				PlayerPrefs.SetInt ("DUnlockLevels", currentlevel+1);

			}
				//
				//CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("DLevel") +"");
						}


			if (PlayerPrefs.GetInt ("MDog") == 1) {
                // //
                //
                print("HUSSAIN");
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                //  _levelcomplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("DogLevel");
				if(currentlevel<5)
				{
					PlayerPrefs.SetInt ("DogUnlockLevels", currentlevel+1);

				}
				//CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("DogLevel") +"");
			}



	}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
