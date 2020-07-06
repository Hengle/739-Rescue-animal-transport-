using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoreGames : MonoBehaviour {

	Button MoreAppsButton;
	// Use this for initialization

	void Start () 
	{
		MoreAppsButton = this.GetComponent<Button> () as Button;
		MoreAppsButton.onClick.AddListener (GaminatorAds.Instance.MoreApps);
	}

}
