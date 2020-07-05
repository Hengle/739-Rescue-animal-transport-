using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
public class SheepManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public GameObject  animalcontrolls, _playercontrolls,rcccam;
	public SmoothFollow _targetSheep;
	public GameObject back;
	public	GameObject anim,_1stlevelsheep,_2ndlevelsheep;
	public GameObject _trucksheep1, _trucksheep2,seconpositiontruck,sheeparrowlevel4,sheeparrowlevel5,backk;
    Animation anim1;
    Animation anim2;
	void Start () {
        Time.timeScale = 1f;
         //   PlayerPrefs.SetInt("SLevel", 5);

        int currentlevel = PlayerPrefs.GetInt ("SLevel");
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
		int currentlevel = PlayerPrefs.GetInt ("SLevel");
		if (currentlevel == 1) {
			_type.ShowDlgBar ("A landLord purcahse some sheeps from Animal Market..Go to Animal Market..");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [0];
			anim = _1stlevelsheep.gameObject;

		}

		if (currentlevel == 2) {
			backk.gameObject.SetActive (false);
			seconpositiontruck.gameObject.SetActive (true);
			_trucksheep1.gameObject.SetActive (true);
			_targetSheep.target = _2ndlevelsheep.transform;
			_targetSheep.gameObject.SetActive (true);
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim =_2ndlevelsheep.gameObject;
			_type.ShowDlgBar ("take Sheep to truck");
			_time.Minutes = 1f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			rcccam.gameObject.SetActive (false);
			animalcontrolls.SetActive (true);
			_playercontrolls.SetActive (false);
			_2ndlevelsheep.gameObject.GetComponent<Human_Controller1> ().enabled=true;
			Invoke ("waitforback", 2f);
		}

		if (currentlevel == 3) {
             anim1 = _trucksheep1.GetComponent<Animation>();
             anim2 = _trucksheep2.GetComponent<Animation>();
             anim1.CrossFade("metarig|Idle2");
             anim2.CrossFade("metarig|Eat");
            _trucksheep1.GetComponent<Rigidbody>().IsSleeping();
            _trucksheep2.GetComponent<Rigidbody>().IsSleeping();
            _trucksheep1.gameObject.SetActive (true);
			_trucksheep2.gameObject.SetActive (true);
			_type.ShowDlgBar ("Take these Sheeps to LandLord Farm...");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [1];
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
		}

		if (currentlevel == 4) {
			backk.gameObject.SetActive (false);
			sheeparrowlevel4.gameObject.SetActive (true);
			_targetSheep.target = _trucksheep1.transform;
			anim =_trucksheep1.gameObject;
			_targetSheep.gameObject.SetActive (true);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_trucksheep1.gameObject.SetActive (true);
			_trucksheep2.gameObject.SetActive (true);
			_trucksheep1.gameObject.transform.parent = null;
			_trucksheep1.gameObject.transform.GetChild (1).gameObject.GetComponent<MeshCollider> ().enabled = true;
			_trucksheep1.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_trucksheep1.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take first Sheep into farm");
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
			backk.gameObject.SetActive (false);
			sheeparrowlevel5.gameObject.SetActive (true);
			_targetSheep.target = _trucksheep2.transform;
			anim =_trucksheep2.gameObject;
			_targetSheep.gameObject.SetActive (true);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_trucksheep2.gameObject.SetActive (true);
			_trucksheep2.gameObject.transform.parent = null;
			_trucksheep2.gameObject.transform.GetChild (1).gameObject.GetComponent<MeshCollider> ().enabled = true;
			_trucksheep2.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_trucksheep2.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take Second Sheep into farm");
			_time.Minutes = 1f;
			_time.Seconds = 30f;
			_target.gameObject.SetActive (false);
			_playercontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
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
