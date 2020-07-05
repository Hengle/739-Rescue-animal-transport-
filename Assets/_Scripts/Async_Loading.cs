using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Async_Loading : MonoBehaviour {

	public Text m_Text;
	public Button m_Button;
	public Slider loadingSlider;
	bool loadCheck;
	public Text loadingText;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void loadButton()
	{
		StartCoroutine(LoadScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadScene()
	{
		yield return null;

		//Begin to load the Scene you specify
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("RCC AIO Demo");
		//Don't let the Scene activate until you allow it to
		asyncOperation.allowSceneActivation = false;
		Debug.Log("Pro :" + asyncOperation.progress);
		//When the load is still in progress, output the Text and progress bar
		while (!asyncOperation.isDone)
		{
			//Output the current progress
			loadingSlider.value = loadingSlider.value + 0.1f * Time.deltaTime * 2;
			string percent = (loadingSlider.value * 100).ToString ("F0");
			loadingText.text = string.Format ("<size=35>{0}%</size>", percent);
			Debug.Log("Pro :" + m_Text.text);
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
