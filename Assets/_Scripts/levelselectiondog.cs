using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class levelselectiondog : MonoBehaviour
{
	public Slider loadingSlider;
	public Text loadingText;

	private int lastno;
	//public Transform levels1;
	public GameObject Levels;
	//private int levelnumber;
	public GameObject Loading;




	// Use this for initialization
	void Start ()
	{
		

		lastno = 0;
		int no = PlayerPrefs.GetInt ("DogUnlockLevels");
		int UnlockedLevel = PlayerPrefs.GetInt ("DogUnlockLevels");
		if (no == 0) { 
			//  no= 1;

			PlayerPrefs.SetInt ("DogUnlockLevels", 1);
		
		}
		for (int i = 1; i < no; i++) {
			Levels.transform.GetChild (i).GetChild (1).gameObject.SetActive (false);
		}
	

	

	}


    public void unlock_All()
    {
        InApp_Manager.instance.Buy_UnlockAll_Levels();
        // PlayerPrefs.SetInt("DogUnlockLevels", 5);
    }



    public void OnLevelSelect (int no)
	{

		if (!Levels.transform.GetChild (no - 1).GetChild (1).gameObject.activeInHierarchy) {

			if (lastno != 0) {
				lastno--;
			}
			// For Color Tilt
//			Levels.transform.GetChild (lastno).gameObject.GetComponent<Image> ().color = Color.white;
//			Levels.transform.GetChild (no - 1).gameObject.GetComponent<Image> ().color = Color.gray;

			//For Image Replacement
			//Levels.transform.GetChild(lastno).gameObject.GetComponent<Image>().sprite = NormelImg;
			//NormelImg=Levels.transform.GetChild(no-1).gameObject.GetComponent<Image>().sprite;
			//Levels.transform.GetChild(no - 1).gameObject.GetComponent<Image>().sprite = HoverImgs[no-1];
            

			lastno = no;
			print ("level No" +lastno);
			print ("hussain");
			CustomAnalytics.logLevelStarted ("LevelSelection",lastno+"");
			OnPlay ();

		}
	}
    public void level_1()
    {
       CustomAnalytics.logLevelStarted("LevelSelection", "1");
    }
    public void level_2()
    {
        CustomAnalytics.logLevelStarted("LevelSelection", "2");
    }
    public void level_3()
    {
       CustomAnalytics.logLevelStarted("LevelSelection", "3");
    }
    public void level_4()
    {
        CustomAnalytics.logLevelStarted("LevelSelection", "4");
    }
    public void level_5()
    {
        CustomAnalytics.logLevelStarted("LevelSelection", "5");
    }
    public void level_6()
    {
        CustomAnalytics.logLevelStarted("LevelSelection", "6");
    }
    public void OnPlay ()
	{
//		if (lastno != 0) {


//			SoundManager.Instance.ButtonSound ();

			Loading.SetActive (true);
			print ("levels");
			PlayerPrefs.SetInt ("DogLevel", lastno);
		StartCoroutine (LoadScene ());
//		Invoke ("wait",5f);
	}

	void wait ()
	{
		
		Application.LoadLevel ("Gameplay");

	}



	public void OnBack ()
	{
//		SoundManager.Instance.ButtonSound ();
	
		Loading.SetActive (true);

	

		StartCoroutine (loadingwait ());
	}

	IEnumerator loadingwait ()
	{
		yield return new WaitForSeconds (2f);

		Loading.SetActive (false);
		StartCoroutine (loadingwait1 ());
	}

	IEnumerator loadingwait1 ()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("Gameplay");
	}

	public void OnMoreApps ()
	{
//		SoundManager.Instance.ButtonSound ();
		Application.OpenURL ("");
	}


	IEnumerator LoadScene()
	{
		yield return null;

		//Begin to load the Scene you specify
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gameplay");
		//Don't let the Scene activate until you allow it to
		asyncOperation.allowSceneActivation = false;
		Debug.Log("Pro :" + asyncOperation.progress);
		//When the load is still in progress, output the Text and progress bar
		while (!asyncOperation.isDone)
		{
			//Output the current progress
			loadingSlider.value = loadingSlider.value + 0.1f * Time.deltaTime * 1f;
			string percent = (loadingSlider.value * 100).ToString ("F0");
			loadingText.text = string.Format ("<size=35>{0}%</size>", percent);
			// Check if the load has finished
			if (asyncOperation.progress >= 0.9f && loadingSlider.value == 1f)
			{
				//Change the Text to show the Scene is ready
				asyncOperation.allowSceneActivation = true;
			}

			yield return null;
		}
	}

}
