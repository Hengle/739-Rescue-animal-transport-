using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;


public class loadingscreen1 : MonoBehaviour {
	public Image loadingBar;
	//public Text loadingtext;

	float currCountdownValue;

	public bool coolingDown;
	public float waitTime = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	void OnEnable(){
		waitTime = 10.0f;
			StartCoroutine(StartCountdown());
			coolingDown = true;
        loadingBar.fillAmount = 0.0f;


    }
	// Update is called once per frame
	void Update () {
		if (coolingDown == true)
		{
			//Reduce fill amount over 30 seconds
			loadingBar.fillAmount += 2.0f / waitTime * Time.deltaTime;
			//loadingtext.text = ((int)(loadingBar.fillAmount * 100)).ToString ();
		}
	}
	public IEnumerator StartCountdown(float countdownValue = 10)
	{
		//		yield return null;
		currCountdownValue = 10f;
		while (currCountdownValue > 2)
		{
			Debug.Log("Countdown: " + currCountdownValue);
            //yield return new WaitForSeconds(0.5f);
            yield return new WaitForSecondsRealtime(0.5f);
            currCountdownValue--;
		}
		if(currCountdownValue<=2){
            if (gameObject.name!= "MainLoading") {
                gameObject.SetActive (false);
            }

            coolingDown = false;
			yield return null;
		}
	}
	// Update is called once per frame

}
