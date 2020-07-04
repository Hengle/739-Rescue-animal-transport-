using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class transparenteffect : MonoBehaviour {
	
	public GameObject[] _levels;
	// Use this for initialization
	void Start () {
		
	}

	public void _transparenteffect()
	{
		_levels [0].gameObject.SetActive (true);
		for (int i = 1; i < _levels.Length; i++) 
		{
			_levels [i].gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
