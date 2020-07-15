using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class DogManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public SmoothFollow _targetLionCam;
	public GameObject back,rccCamera;
	public	GameObject anim;
    Animation animation;
	public GameObject firstdog,truckdog,truckcontrolls,Dogcontrols,backk,truckdesti,leve4dog,truckdesti2,arrowlevel5;

	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetInt("DogLevel",3);
        int currentlevel = PlayerPrefs.GetInt ("DogLevel");
		print("level :"+currentlevel);
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
		

		int currentlevel = PlayerPrefs.GetInt ("DogLevel");
		if (currentlevel == 1) {
			_type.ShowDlgBar ("Land Lord buy a Tiger from his friend..Go to friend house.");
			_time.Minutes = 1f;
			_time.Seconds = 20f;
			_target._target = _assighntargets [0];
			anim = firstdog.gameObject;

		}

		if (currentlevel == 2) {
			_type.ShowDlgBar ("Take Tiger to Truck");
			_time.Minutes = 2f;
			backk.gameObject.SetActive (false);
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim = firstdog.gameObject;
			Invoke ("waitforback", 1f);
			truckcontrolls.SetActive (false);
			Dogcontrols.SetActive (true);
			firstdog.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_targetLionCam.gameObject.SetActive (true);

			_targetLionCam.target = firstdog.gameObject.transform;
			truckdesti.gameObject.SetActive (true);
			rccCamera.SetActive (false);
		}

		if (currentlevel == 3) {
			_type.ShowDlgBar ("Take Tiger to hospital and take to veterinary doctor for checkup");
			_time.Minutes = 2f;
			truckdog.gameObject.SetActive (true);
			anim = truckdog.gameObject;
            animation = truckdog.GetComponent<Animation>();
            animation.CrossFade("Eating");
            truckdog.GetComponent<Rigidbody>().IsSleeping();
            truckdog.gameObject.SetActive (true);
			_target._target = _assighntargets [1];
		}

		if (currentlevel == 4) {
			backk.gameObject.SetActive (false);
			_type.ShowDlgBar ("Take Tiger to truck and move to farm");
			_time.Minutes = 2f;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim = leve4dog.gameObject;
			Invoke ("waitforback", 1f);
			truckcontrolls.SetActive (false);
			Dogcontrols.SetActive (true);
			leve4dog.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_targetLionCam.target = leve4dog.gameObject.transform;
			_targetLionCam.gameObject.SetActive (true);
			rccCamera.SetActive (false);
			truckdesti2.SetActive (true);
		}

		if (currentlevel == 5) {
			arrowlevel5.gameObject.SetActive (true);
			_target.gameObject.SetActive (false);
			backk.gameObject.SetActive (false);
			Invoke ("waitforback", 1f);
			_type.ShowDlgBar ("Take Tiger to destination for protection of farm");
			_time.Minutes = 1f;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			anim = truckdog.gameObject;
			truckcontrolls.SetActive (false);
			Dogcontrols.SetActive (true);
			truckdog.transform.parent = null;
			truckdog.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
			truckdog.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			truckdog.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			truckdog.gameObject.SetActive (true);
			_targetLionCam.gameObject.SetActive (true);
			_targetLionCam.target = truckdog.gameObject.transform;
			rccCamera.SetActive (false);
		}
	}


	public void _upmoveLion()
	{
		anim.gameObject.GetComponent<Human_Controller1> ()._downstate ();
	}

	public void _idle()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().up ();
	}

	public void _kickLion()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().Kick ();
	}

	void waitforback()
	{
		back.SetActive (true);
	}
}
