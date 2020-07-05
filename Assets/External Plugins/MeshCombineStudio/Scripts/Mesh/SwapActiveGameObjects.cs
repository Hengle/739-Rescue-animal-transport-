using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActiveGameObjects : MonoBehaviour {

	public GameObject go1, go2;
	public KeyCode key;

	bool active = true;

	void Start () {
		SetActive(active);
	}
	
	void Update () {
		if (Input.GetKeyDown(key))
		{
			active = !active;
			SetActive(active);
		}
	}

	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Label(new Rect(10, 10, 200, 20), "Toggle with '" + key.ToString() + "' key.");

		if (active) GUI.Label(new Rect(10, 50, 300, 20), "MeshCombineStudio is Enabled.");
		else GUI.Label(new Rect(10, 50, 300, 20), "MeshCombineStudio is Disabled.");

		GUI.color = Color.white;
	}

	void SetActive(bool active)
	{
		go1.SetActive(active);
		go2.SetActive(!active);
	}
}
