using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {
	public AudioSource _audiosource;
	public AudioClip _btnsound;
	// Use this for initialization
	void Start () {
		
	}

	public void btnclicksound()
	{
		_audiosource.clip = _btnsound;
		_audiosource.PlayOneShot (_btnsound);
	}
}
