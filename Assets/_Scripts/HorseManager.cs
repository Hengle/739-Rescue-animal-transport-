using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
public class HorseManager : MonoBehaviour {
	public GameObject _levels,_player;
	public TypingText _type;
	public TimeCounter _time;
	public ArrowTarget _target;
	public Transform[] _assighntargets;
	public GameObject _2ndhorse, truck, animalcontrolls, truckcontrolls,rcccam;
	public SmoothFollow _targethorse;
	public GameObject _1sthorsetruck,_2ndhorsetruck,destination,back,_1sthorse,_2ndlevelhorse;
	public	GameObject anim,upbtn,kickbtn,horsearrowlevel4,horsearrowlevel5,backk;
	public GameObject[] _colorbtn;
	public GameObject _dog,attackbtn,upbtns;
    Animation anim1;
    Animation anim2;
// Use this for initialization
    void Start () {
		Time.timeScale = 1f;
       // PlayerPrefs.SetInt("HLevel", 5);

        int currentlevel = PlayerPrefs.GetInt ("HLevel");
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
		int currentlevel = PlayerPrefs.GetInt ("HLevel");
	


		if (currentlevel == 1) {
			_type.ShowDlgBar ("Land Lord want his Zebra to city from farm..Go to farm");
			_time.Minutes = 2f;
			_time.Seconds = 20f;
			_target._target = _assighntargets [0];
			anim = _1sthorse.gameObject;

		}

		if (currentlevel == 2) {
			_targethorse.target = _2ndhorse.transform;
			anim = _2ndlevelhorse.gameObject;
			backk.gameObject.SetActive (false);
			_type.ShowDlgBar ("Take Zebra to truck");
			_time.Minutes = 1f;
			_time.Seconds = 20f;
			_target.gameObject.SetActive (false);
			_targethorse.gameObject.SetActive (true);
			rcccam.gameObject.SetActive (false);
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic=true;

			_1sthorsetruck.gameObject.SetActive (true);
			destination.gameObject.SetActive (true);
			animalcontrolls.SetActive (true);
			truckcontrolls.SetActive (false);
			Invoke ("waitforback", 2f);
		}

		if (currentlevel == 3) {
            anim1 = _1sthorsetruck.GetComponent<Animation>();
            anim2 = _2ndhorsetruck.GetComponent<Animation>();
            anim1.CrossFade("Rearing up (Attack01)");
            anim2.CrossFade("Eating");
            _1sthorsetruck.gameObject.SetActive (true);
			_2ndhorsetruck.gameObject.SetActive (true);
			_type.ShowDlgBar ("Drive Truck and take to city Horse farm");
			_time.Minutes = 2f;
			_time.Seconds = 20f;
			_target._target = _assighntargets [1];

		}

		if (currentlevel == 4) {
			for (int i = 0; i < _colorbtn.Length; i++)
			{
				_colorbtn [i].gameObject.SetActive (false);
			}
			_1sthorsetruck.gameObject.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
			_1sthorsetruck.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_1sthorsetruck.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			backk.gameObject.SetActive (false);
			horsearrowlevel4.gameObject.SetActive (true);
			truck.gameObject.GetComponent<playerscript> ().enabled = false;
			anim = _1sthorsetruck.gameObject;
			_type.ShowDlgBar ("Take Zebra Horse into farm");
			_1sthorsetruck.gameObject.SetActive (true);
			_time.Minutes = 2f;
			_time.Seconds = 20f;
			_2ndhorsetruck.gameObject.SetActive (true);
			_target.gameObject.SetActive (false);
			truckcontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_targethorse.target = _1sthorsetruck.transform;
			Invoke ("waitforback", 2f);
			truck.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			rcccam.SetActive (false);
			_targethorse.gameObject.SetActive (true);
			_1sthorsetruck.gameObject.transform.parent = null;
		}

		if (currentlevel == 5) {
			for (int i = 0; i < _colorbtn.Length; i++)
			{
				_colorbtn [i].gameObject.SetActive (false);
			}
			backk.gameObject.SetActive (false);
			anim = _2ndhorsetruck.gameObject;
			horsearrowlevel5.gameObject.SetActive (true);
			truck.gameObject.GetComponent<playerscript> ().enabled = false;
			_targethorse.target = _2ndhorsetruck.transform;
			_type.ShowDlgBar ("Take Zebra Horse into farm");
			_1sthorsetruck.gameObject.SetActive (false);
			_time.Minutes = 2f;
			_time.Seconds = 20f;
			_2ndhorsetruck.gameObject.SetActive (true);
			_target.gameObject.SetActive (false);
			truckcontrolls.SetActive (false);
			animalcontrolls.SetActive (true);
			_2ndhorsetruck.gameObject.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
			_2ndhorsetruck.gameObject.GetComponent<Human_Controller1> ().enabled = true;
			_2ndhorsetruck.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			Invoke ("waitforback", 2f);
			Invoke ("wait11", 2f);
			truck.gameObject.GetComponent<Rigidbody> ().isKinematic=true;
			rcccam.SetActive (false);
			_targethorse.gameObject.SetActive (true);
			_2ndhorsetruck.gameObject.transform.parent = null;

		}
	}


	public void _upmovehorse()
	{
		anim.gameObject.GetComponent<Human_Controller1> ()._downstate ();
		upbtn.gameObject.GetComponent<Button> ().interactable = false;
		StartCoroutine (waitforupbuttton(upbtn.gameObject.GetComponent<Button>()));
	}

	public void _idle()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().up ();

	}

	public void _kickhorse()
	{
		anim.gameObject.GetComponent<Human_Controller1> ().Kick ();
		kickbtn.gameObject.GetComponent<Button> ().interactable = false;
		StartCoroutine (waitforkickbuttton(kickbtn.gameObject.GetComponent<Button>()));
	}

	IEnumerator waitforupbuttton(Button btn)
	{
		yield return new WaitForSeconds (2.7f);
		btn.interactable = true;
	}

	IEnumerator waitforkickbuttton(Button btn)
	{
		yield return new WaitForSeconds (1f);
		btn.interactable = true;
	}

	void waitforback()
	{
		back.SetActive (true);

	}

	void wait11()
	{
		_1sthorsetruck.gameObject.GetComponent<Human_Controller1> ().enabled = true;
	}
}
