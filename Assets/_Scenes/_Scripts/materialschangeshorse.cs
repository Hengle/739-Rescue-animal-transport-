using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialschangeshorse : MonoBehaviour {
	public Material[] _materialh1,_materialh2,_materialh3,_materialh4,_materialh5;
	public Renderer [] _horse,_horse2;
	void Start ()
	{
		if (PlayerPrefs.GetInt ("horse1cl") == 1) 
		{
			_horse [0].materials = _materialh1;
			_horse [1].materials = _materialh1;
		}

		if (PlayerPrefs.GetInt ("horse1cl2") == 1) 
		{
			_horse2 [0].materials = _materialh1;
			_horse2 [1].materials = _materialh1;
		}

		if (PlayerPrefs.GetInt ("horse1cl") == 2) 
		{
			_horse [0].materials = _materialh2;
			_horse [1].materials = _materialh2;
		}

		if (PlayerPrefs.GetInt ("horse1cl2") == 2) 
		{
			_horse2 [0].materials = _materialh2;
			_horse2 [1].materials = _materialh2;
		}

		if (PlayerPrefs.GetInt ("horse1cl") == 3) 
		{
			_horse [0].materials = _materialh3;
			_horse [1].materials = _materialh3;
		}

		if (PlayerPrefs.GetInt ("horse1cl2") == 3) 
		{
			_horse2 [0].materials = _materialh3;
			_horse2 [1].materials = _materialh3;
		}


		if (PlayerPrefs.GetInt ("horse1cl") == 4) 
		{
			_horse [0].materials = _materialh4;
			_horse [1].materials = _materialh4;
		}

		if (PlayerPrefs.GetInt ("horse1cl2") == 4) 
		{
			_horse2 [0].materials = _materialh4;
			_horse2 [1].materials = _materialh4;
		}


		if (PlayerPrefs.GetInt ("horse1cl") == 5) 
		{
			_horse [0].materials = _materialh5;
			_horse [1].materials = _materialh5;
		}

		if (PlayerPrefs.GetInt ("horse1cl2") == 5) 
		{
			_horse2 [0].materials = _materialh5;
			_horse2 [1].materials = _materialh5;
		}
	}

	public void firstmaterial()
//	void Start () 
	{
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
		if (currentlevel == 1) {
			_horse [0].materials = _materialh1;
			_horse [1].materials = _materialh1;
			PlayerPrefs.SetInt ("horse1cl",1);
		}
		if (currentlevel == 2) {
			_horse2 [0].materials = _materialh1;
			_horse2 [1].materials = _materialh1;
			PlayerPrefs.SetInt ("horse1cl2",1);
		}
	}



	public void secondmaterial()
	{
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
		if (currentlevel == 1) {
			_horse [0].materials = _materialh2;
			_horse [1].materials = _materialh2;
			PlayerPrefs.SetInt ("horse1cl",2);
		}
		if (currentlevel == 2) {
			_horse2 [0].materials = _materialh2;
			_horse2 [1].materials = _materialh2;
			PlayerPrefs.SetInt ("horse1cl2",2);
		}
	}


	public void thirdmaterial()
	{
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
		if (currentlevel == 1) {
			_horse [0].materials = _materialh3;
			_horse [1].materials = _materialh3;
			PlayerPrefs.SetInt ("horse1cl",3);
		}
		if (currentlevel == 2) {
			_horse2 [0].materials = _materialh3;
			_horse2 [1].materials = _materialh3;
			PlayerPrefs.SetInt ("horse1cl2",3);
		}
	}

	public void fourmaterial()
	{
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
		if (currentlevel == 1) {
			_horse [0].materials = _materialh4;
			_horse [1].materials = _materialh4;
			PlayerPrefs.SetInt ("horse1cl",4);
		}
		if (currentlevel == 2) {
			_horse2 [0].materials = _materialh4;
			_horse2 [1].materials = _materialh4;
			PlayerPrefs.SetInt ("horse1cl2",4);
		}
	}


	public void fivematerial()
	{
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
		if (currentlevel == 1) {
			_horse [0].materials = _materialh5;
			_horse [1].materials = _materialh5;
			PlayerPrefs.SetInt ("horse1cl",5);
		}
		if (currentlevel == 2) {
			_horse2 [0].materials = _materialh5;
			_horse2 [1].materials = _materialh5;
			PlayerPrefs.SetInt ("horse1cl2",5);
		}
	}

}
