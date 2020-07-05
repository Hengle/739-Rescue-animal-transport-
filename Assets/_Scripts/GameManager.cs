using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class GameManager : MonoBehaviour {
	public GameObject _levels;
	public GameObject _player;
	public static int count;
	public static int totalcount;
	public GameObject _pausepannel,levelcomplete,levelfaild;
	public GameObject _levelanimal;
	public static int percount;
	public SmoothFollow _maincam;
	public GameObject _env;
	public TimeCounter _time;
	bool check;
	// Use this for initialization
	void Awake () {
		check = false;
//		Debug.ClearDeveloperConsole ();
		Time.timeScale = 1f;
		Instantiate (_env);
		count = 0;
		percount = 0;
		_animalpicklevel ();
		int currentlevel = PlayerPrefs.GetInt ("LeveNo");
		print (currentlevel);
		_levels.gameObject.transform.GetChild (currentlevel - 1).gameObject.SetActive (true);
		_player.transform.position = _levels.gameObject.transform.GetChild (currentlevel-1).transform.GetChild (0).position;
		_player.transform.rotation = _levels.gameObject.transform.GetChild (currentlevel-1).transform.GetChild (0).rotation;
		_levelsTime ();
		StartCoroutine (waitchheck ());
	}


	public void _pause()
	{
		Time.timeScale = 0f;
		_pausepannel.SetActive (true);
	}

	public void _resume()
	{
		Time.timeScale = 1f;
		_pausepannel.SetActive (false);
	}

	public void _restart()
	{
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}
	public void _home()
	{
		Application.LoadLevel ("MainMenu");

	}

	public void _Next()
	{
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}
	// Update is called once per frame
	void Update () {
		
		if (_levelanimal == null) {

			_levelanimal = GameObject.Find ("Animals");

		}

		if (check == true) {
			if (percount == 1) {
				_maincam.target = _levelanimal.GetComponent<LevelAnimals> ()._Animals [1].gameObject.transform;
				_levelanimal.GetComponent<LevelAnimals> ()._Animals [1].gameObject.GetComponent<Human_Controller1> ().enabled = true;
			}
			if (percount == 2) {
				_maincam.target = _levelanimal.GetComponent<LevelAnimals> ()._Animals [2].gameObject.transform;
				_levelanimal.GetComponent<LevelAnimals> ()._Animals [2].gameObject.GetComponent<Human_Controller1> ().enabled = true;
			}

			if (percount == 3) {
				_maincam.target = _levelanimal.GetComponent<LevelAnimals> ()._Animals [3].gameObject.transform;
				_levelanimal.GetComponent<LevelAnimals> ()._Animals [3].gameObject.GetComponent<Human_Controller1> ().enabled = true;
			}

			if (percount == 4) {
				_maincam.target = _levelanimal.GetComponent<LevelAnimals> ()._Animals [4].gameObject.transform;
				_levelanimal.GetComponent<LevelAnimals> ()._Animals [4].gameObject.GetComponent<Human_Controller1> ().enabled = true;
			}
		}
	}

	IEnumerator waitchheck()
	{
		yield return new WaitForSeconds (4f);
		check = true;

	}
	void _animalpicklevel()
	{
		int currentlevel = PlayerPrefs.GetInt ("LeveNo");
		if (currentlevel == 1) 
		{
			totalcount = 2;
		}

		if (currentlevel == 2) 
		{
			totalcount = 2;
		}

		if (currentlevel == 3) 
		{
			totalcount = 2;
		}

		if (currentlevel == 4) 
		{
			totalcount = 2;
		}if (currentlevel == 5) 
		{
			totalcount = 2;
		}if (currentlevel == 6) 
		{
			totalcount = 2;
		}if (currentlevel == 7) 
		{
			totalcount = 2;
		}if (currentlevel == 8) 
		{
			totalcount = 2;
		}if (currentlevel == 9) 
		{
			totalcount = 2;
		}if (currentlevel == 10) 
		{
			totalcount = 2;
		}

	}

	void _levelsTime()
	{
		_time.StartTime ();
		int currentlevel = PlayerPrefs.GetInt ("LeveNo");
		if (currentlevel == 1) {
			_time.Minutes = 4f;
		}
		if (currentlevel == 2) {
			_time.Minutes = 4f;
		}if (currentlevel == 3) {
			_time.Minutes = 5f;
		}if (currentlevel == 4) {
			_time.Minutes = 5f;
		}if (currentlevel == 5) {
			_time.Minutes = 5f;
		}if (currentlevel == 6) {
			_time.Minutes = 5f;
		}if (currentlevel == 7) {
			_time.Minutes = 5f;
		}if (currentlevel == 8) {
			_time.Minutes = 5f;
		}if (currentlevel == 9) {
			_time.Minutes = 5f;
		}if (currentlevel == 10) {
			_time.Minutes = 5f;
		}
	}
}
