using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class LionManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public SmoothFollow _targetLionCam;
	public GameObject back,rccCamera;
	public	GameObject anim;
	public GameObject cage1;
	public GameObject firstlion,secondlion,trucklion,trucklion2,truckcontrolls,lioncontrols,arrowlevel3,backk;
    Animation animation;
    // Use this for initialization
    void Start () {
       // PlayerPrefs.SetInt("LLevel",5);
        int currentlevel = PlayerPrefs.GetInt ("LLevel");
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
		
		//cage1.gameObject.SetActive (true);
		int currentlevel = PlayerPrefs.GetInt ("LLevel");
		if (currentlevel == 1) {
			_type.ShowDlgBar ("Zoo Owner want new lion in collection.Go to Jungle..!");
			_time.Minutes = 2f;
			_time.Seconds = 50f;
			_target._target = _assighntargets [0];
			anim = firstlion.gameObject;

		}

		if (currentlevel == 2) {
			_type.ShowDlgBar ("Take Lion to Zoo for people entrtainment");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
		//	cage1.gameObject.GetComponent<Animator> ().enabled = false;
			_target._target = _assighntargets [1];
			trucklion.gameObject.SetActive (true);
            animation = trucklion.GetComponent<Animation>();
            animation.CrossFade("Eating");
            trucklion.GetComponent<Rigidbody>().IsSleeping();
            //			back.SetActive (true);
        }

		if (currentlevel == 3) {
			backk.gameObject.SetActive (false);
			arrowlevel3.gameObject.SetActive (true);
			_type.ShowDlgBar ("Take Lion to his cage");
		//	cage1.gameObject.GetComponent<Animator> ().enabled = true;
		//	cage1.gameObject.GetComponent<Animator> ().SetBool ("doorOpen",true);
			_time.Minutes = 2f;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			Invoke ("waitforback", 2f);
			trucklion.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			anim = trucklion.gameObject;
			truckcontrolls.SetActive (false);
			lioncontrols.SetActive (true);
			trucklion.gameObject.SetActive (true);
			_target.gameObject.SetActive (false);
			trucklion.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			rccCamera.SetActive (false);
			_targetLionCam.gameObject.SetActive (true);
			_targetLionCam.target = trucklion.gameObject.transform;
		}

		if (currentlevel == 4) {
			
			_type.ShowDlgBar ("Lion is not in good condition.GO to Zoo..");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [2];
			anim = secondlion.gameObject;
            trucklion.gameObject.SetActive(true);
            animation = trucklion.GetComponent<Animation>();
            animation.CrossFade("Eating");
            trucklion.GetComponent<Rigidbody>().IsSleeping();
        }

		if (currentlevel == 5) {
			backk.gameObject.SetActive (false);
			anim = trucklion2.gameObject;
			_player.gameObject.GetComponent<playerscript> ().enabled = false;
			_type.ShowDlgBar ("Take Lion to veterinary Hospital for check up..");
			_time.Minutes = 2f;
			_time.Seconds = 30f;
			_target._target = _assighntargets [3];
            //	cage1.gameObject.GetComponent<Animator> ().enabled = false;
           // trucklion.gameObject.SetActive(false);
            trucklion2.gameObject.SetActive (true);
            animation = trucklion2.GetComponent<Animation>();
            animation.CrossFade("Eating");
            trucklion2.GetComponent<Rigidbody>().IsSleeping();
            //			trucklion.gameObject.GetComponent<Rigidbody> ().isKinematic=false;
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
