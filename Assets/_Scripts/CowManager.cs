using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
public class CowManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public GameObject  animalcontrolls, _playercontrolls,rcccam;
	public SmoothFollow _targetSheep;
	public GameObject back;
	public	GameObject anim,_1stlevelcow,_2ndlevelcow;
	public GameObject _truckcow1, _truckcow2,seconpositiontruck,arrowlevel4,arrowlevel5,backk;

	void Start () {
		Time.timeScale = 1f;
       // PlayerPrefs.SetInt("CLevel", 5);
        int currentlevel = PlayerPrefs.GetInt ("CLevel");
       // int currentlevel = 1;
        _levels.gameObject.transform.GetChild (currentlevel - 1).gameObject.SetActive (true);
		_player.transform.position = _levels.gameObject.transform.GetChild (currentlevel-1).transform.GetChild (0).position;
		_player.transform.rotation = _levels.gameObject.transform.GetChild (currentlevel-1).transform.GetChild (0).rotation;
		_textoflevel ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void _textoflevel()
	{
		int currentlevel = PlayerPrefs.GetInt ("CLevel");
		if (currentlevel == 1) {
			_type.ShowDlgBar ("A LandLord purchase cow and buffalo from Animal Market..Go to Animal Market");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [0];
			anim = _1stlevelcow.gameObject;

		}

		if (currentlevel == 2) {
			backk.gameObject.SetActive (false);
			seconpositiontruck.gameObject.SetActive (true);
			_truckcow1.gameObject.SetActive (true);
			_targetSheep.target = _2ndlevelcow.transform;
			_targetSheep.gameObject.SetActive (true);
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim =_2ndlevelcow.gameObject;
			_type.ShowDlgBar ("Take Buffalo in truck");
			_time.Minutes = 1f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			rcccam.gameObject.SetActive (false);
			animalcontrolls.SetActive (true);
			_playercontrolls.SetActive (false);
			_2ndlevelcow.gameObject.GetComponent<Human_Controller1> ().enabled=true;
			Invoke ("waitforback", 2f);
		}

		if (currentlevel == 3) {
			_truckcow1.gameObject.SetActive (true);
			_truckcow2.gameObject.SetActive (true);
			_type.ShowDlgBar ("Take them to city farm of landlord");
			_time.Minutes = 4f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [1];
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
		}

		if (currentlevel == 4) {
			backk.gameObject.SetActive (false);
			arrowlevel4.gameObject.SetActive (true);
			_targetSheep.target = _truckcow1.transform;
			anim =_truckcow1.gameObject;
			_targetSheep.gameObject.SetActive (true);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_truckcow1.gameObject.SetActive (true);
			_truckcow2.gameObject.SetActive (true);
			_truckcow1.gameObject.transform.parent = null;
			_truckcow1.gameObject.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<MeshCollider> ().enabled = true;
			_truckcow1.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_truckcow1.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take Cow into Farm");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			Invoke ("waitforback", 2f);
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			rcccam.SetActive (false);
		}

		if (currentlevel == 5) {
			arrowlevel5.gameObject.SetActive (true);
			_target._target = _assighntargets [2];
			_targetSheep.target = _truckcow2.transform;
			anim =_truckcow2.gameObject;
//			_targetSheep.gameObject.SetActive (true);
//			_playercontrolls.SetActive (false);
//			animalcontrolls.SetActive (true);
			_truckcow2.gameObject.SetActive (true);
//			_truckcow2.gameObject.transform.parent = null;
//			_truckcow2.gameObject.transform.GetChild (1).gameObject.GetComponent<MeshCollider> ().enabled = true;
//			_truckcow2.gameObject.GetComponent<Human_Controller1> ().enabled = true;
//			_truckcow2.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
//			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Drive Truck to next farm ahead to you and take buffalo in farm");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
//			_target.gameObject.SetActive (false);
//			_playercontrolls.SetActive (false);
//			animalcontrolls.SetActive (true);
//			Invoke ("waitforback", 2f);
//			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
//			rcccam.SetActive (false);
		}
	}


	public void _upmoveSheep()
	{
		anim.gameObject.GetComponent<Human_Controller1> ()._downstate ();

	}

	public void _idle()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().up ();

	}

	public void _kickSheep()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().Kick ();

	}


	void waitforback()
	{
		back.SetActive (true);
	}
}
