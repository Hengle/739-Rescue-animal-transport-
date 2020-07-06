using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectanimal : MonoBehaviour {
	public GameObject _levelComplete,lioncontrols, succes_store, Fail_store;
	public GameObject[] _horse;
	public Animator _door;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("MLion") == 1) {
			_door.SetBool ("doorOpen",true);
		}
	}
	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "animal") 
		{
			if (PlayerPrefs.GetInt ("MHorse") == 1) {
              //  //
                _horse [0].gameObject.SetActive (true);
				col.gameObject.transform.parent.gameObject.SetActive (false);
                Invoke("timee", 0f);
                succes_store.SetActive(true);
               // _levelComplete.SetActive (true);
				int currentlevel = PlayerPrefs.GetInt ("HLevel");
				PlayerPrefs.SetInt ("HUnlockLevels", currentlevel+1);
                print("HUSSAIN");
               ////CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("HLevel") + "");
                //	//
            }

			if (PlayerPrefs.GetInt ("MLion") == 1) {
				
				col.gameObject.transform.parent.GetComponent<Animation> ().CrossFade ("Idle");
				lioncontrols.gameObject.SetActive (false);
				_door.SetBool ("doorOpen",false);
				StartCoroutine (waitdoor());
			}
			if (PlayerPrefs.GetInt ("MSheep") == 1) {
                //    //
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                // _levelComplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("SLevel");
				PlayerPrefs.SetInt ("SUnlockLevels", currentlevel+1);
                print("HUSSAIN1");
               CustomAnalytics.logLevelCompleted ("Success", PlayerPrefs.GetInt("SLevel") + "");

			}


			if (PlayerPrefs.GetInt ("MCow") == 1) {
                //  //
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                // _levelComplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("CLevel");
				PlayerPrefs.SetInt ("CUnlockLevels", currentlevel+1);
                print("HUSSAIN2");
               CustomAnalytics.logLevelCompleted ("Success", PlayerPrefs.GetInt("CLevel")+ "");

			}


			if (PlayerPrefs.GetInt ("MDeer") == 1) {
                //    //
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                // _levelComplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt("DLevel");
				PlayerPrefs.SetInt ("DUnlockLevels", currentlevel+1);
                print("HUSSAIN3");
              CustomAnalytics.logLevelCompleted ("Success", PlayerPrefs.GetInt("DLevel") + "");

			}


			if (PlayerPrefs.GetInt ("MDog") == 1) {
                //    //
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                // _levelComplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("DogLevel");
				PlayerPrefs.SetInt ("DogUnlockLevels", currentlevel+1);
                print("HUSSAIN4");
              CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("DogLevel") +"");

			}


			
		}

		if (col.gameObject.tag == "animal1") 
		{
			if (PlayerPrefs.GetInt ("MHorse") == 1) {

				_horse [1].gameObject.SetActive (true);
				col.gameObject.transform.parent.gameObject.SetActive (false);
                Invoke("timee", 0f);
                succes_store.SetActive(true);
                //_levelComplete.SetActive (true);
                int currentlevel = PlayerPrefs.GetInt ("HLevel");
				PlayerPrefs.SetInt ("HUnlockLevels", currentlevel+1);
                print("HUSSAIN5");
               ////CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("HLevel") + "");

            }

		}
			
	}

	IEnumerator waitdoor()
	{
		
		yield return new WaitForSeconds (5f);
        //  //
        Invoke("timee", 0f);
        succes_store.SetActive(true);
        //_levelComplete.SetActive (true);
        int currentlevel = PlayerPrefs.GetInt ("LLevel");
		PlayerPrefs.SetInt ("LUnlockLevels", currentlevel+1);
        print("HUSSAIN6");
       ////CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("LLevel") + "");
    }
	// Update is called once per frame
	void Update () {
		
	}

	void _nextpoints()
	{
		
	}
    public void timee()
    {
        Time.timeScale = 0;
    }
}
