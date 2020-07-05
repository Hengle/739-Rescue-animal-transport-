using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectanimal1 : MonoBehaviour {
	public playerscript _player;
	public Transform _nextarrows;
	public GameObject[] _nextdestinations;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "animal") 
		{
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			col.gameObject.tag="Untagged";
			col.gameObject.GetComponent<MeshCollider> ().enabled = false;
			col.gameObject.transform.parent.gameObject.transform.SetParent(this.gameObject.transform);
			col.gameObject.transform.parent.gameObject.GetComponent<Human_Controller1 >().enabled = false;
			col.gameObject.transform.parent.gameObject.GetComponent<Animation> ().CrossFade ("Idle");
			col.gameObject.transform.parent.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			GameManager.count += 1;
			if (GameManager.count == GameManager.totalcount) {
				_player._rccCam.gameObject.SetActive (true);
				_player.maincam.SetActive (false);
				_player._back.SetActive (false);
				_player.animalcontroller.SetActive (false);
				_player.truckcontrol.SetActive (true);
				_player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				_nextpoints ();
				_nextarrows.gameObject.SetActive (true);

			}
			else
			{
				GameManager.percount += 1;
				_nextarrows.gameObject.SetActive (true);
			}
			print (GameManager.count);
		}

		if (col.gameObject.tag == "animal1") 
		{
			
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			col.gameObject.tag="Untagged";
			GameManager.count += 1;
			col.gameObject.GetComponent<MeshCollider> ().enabled = false;
			col.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.SetParent(this.gameObject.transform);
			col.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Human_Controller1 >().enabled = false;
			col.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animation> ().CrossFade ("Idle");
			col.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Rigidbody> ().isKinematic = true;


			if (GameManager.count == GameManager.totalcount) {
				_player._rccCam.gameObject.SetActive (true);
				_player.maincam.SetActive (false);
				_player._back.SetActive (false);
				_player.animalcontroller.SetActive (false);
				_player.truckcontrol.SetActive (true);
				_player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				_nextpoints ();
				_nextarrows.gameObject.SetActive (true);

			}
			else
			{
				GameManager.percount += 1;
				_nextarrows.gameObject.SetActive (true);
			}
			print (GameManager.count);
		}

	}
	// Update is called once per frame
	void Update () {
		
	}

	void _nextpoints()
	{
		int currentlevel = PlayerPrefs.GetInt ("LeveNo");
		if (currentlevel == 1) 
		{
			_nextarrows = _nextdestinations [0].gameObject.transform;
		}

		if (currentlevel == 2) 
		{
			_nextarrows = _nextdestinations [1].gameObject.transform;
		}

		if (currentlevel == 3) 
		{
			_nextarrows = _nextdestinations [2].gameObject.transform;
		}
		if (currentlevel == 4) 
		{
			_nextarrows = _nextdestinations [3].gameObject.transform;
		}
		if (currentlevel == 5) 
		{
			_nextarrows = _nextdestinations [4].gameObject.transform;
		}
		if (currentlevel == 6) 
		{
			_nextarrows = _nextdestinations [5].gameObject.transform;
		}
		if (currentlevel == 7) 
		{
			_nextarrows = _nextdestinations [6].gameObject.transform;
		}
		if (currentlevel == 8) 
		{
			_nextarrows = _nextdestinations [7].gameObject.transform;
		}
		if (currentlevel == 9) 
		{
			_nextarrows = _nextdestinations [8].gameObject.transform;
		}
		if (currentlevel == 10) 
		{
			_nextarrows = _nextdestinations [9].gameObject.transform;
		}
	}
}
