using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
public class DeerManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public GameObject  animalcontrolls, _playercontrolls,rcccam;
	public SmoothFollow _targetDeer;
	public GameObject back;
	public	GameObject anim,_1stlevelDeer,_2ndlevelDeer;
	public GameObject _truckDeer1, _truckDeer2,seconpositiontruck,arrowlevel4,arrowlevel5,backk;

	void Start () {
		Time.timeScale = 1f;
		int currentlevel = PlayerPrefs.GetInt ("DLevel");
     
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
		int currentlevel = PlayerPrefs.GetInt ("DLevel");
		if (currentlevel == 1) {
			_type.ShowDlgBar ("Zoo Owner want add more animals in zoo collection..Go to jungle and take Deer ");
			_time.Minutes = 4f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [0];
			anim = _1stlevelDeer.gameObject;

		}

		if (currentlevel == 2) {
			backk.gameObject.SetActive (false);
			seconpositiontruck.gameObject.SetActive (true);
			_truckDeer1.gameObject.SetActive (true);
			_targetDeer.target = _2ndlevelDeer.transform;
			_targetDeer.gameObject.SetActive (true);
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim =_2ndlevelDeer.gameObject;
			_type.ShowDlgBar ("Take Deer to truck");
			_time.Minutes = 1f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			rcccam.gameObject.SetActive (false);
			animalcontrolls.SetActive (true);
			_playercontrolls.SetActive (false);
			_2ndlevelDeer.gameObject.GetComponent<Human_Controller1> ().enabled=true;
			Invoke ("waitforback", 2f);
		}

		if (currentlevel == 3) {
			_truckDeer1.gameObject.SetActive (true);
			_truckDeer2.gameObject.SetActive (true);
			_type.ShowDlgBar ("Take them to Zoo Safely..");
			_time.Minutes = 4f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [1];
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
		}

		if (currentlevel == 4) {
			backk.gameObject.SetActive (false);
			arrowlevel4.gameObject.SetActive (true);
			_targetDeer.target = _truckDeer1.transform;
			anim =_truckDeer1.gameObject;
			_targetDeer.gameObject.SetActive (true);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			//_truckDeer1.gameObject.SetActive (true);
			_truckDeer2.gameObject.SetActive (true);
            _truckDeer2.gameObject.transform.parent = null;
            _truckDeer2.gameObject.transform.GetChild (0).gameObject.GetComponent<MeshCollider> ().enabled = true;
            _truckDeer2.gameObject.GetComponent<Human_Controller1> ().enabled = true;
            _truckDeer2.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take first Deer in the cage");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
            _target._target = _assighntargets[2];
            _playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			Invoke ("waitforback", 2f);
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			rcccam.SetActive (false);
		}

		if (currentlevel == 5) {
			backk.gameObject.SetActive (false);
			arrowlevel5.gameObject.SetActive (true);
			_targetDeer.target = _truckDeer2.transform;
			anim =_truckDeer2.gameObject;
			_targetDeer.gameObject.SetActive (true);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_truckDeer2.gameObject.SetActive (true);
			_truckDeer2.gameObject.transform.parent = null;
			_truckDeer2.gameObject.transform.GetChild (0).gameObject.GetComponent<MeshCollider> ().enabled = true;
			_truckDeer2.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_truckDeer2.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take Second Deer in the cage");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			Invoke ("waitforback", 2f);
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			rcccam.SetActive (false);
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
