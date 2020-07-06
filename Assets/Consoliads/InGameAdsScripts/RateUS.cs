using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RateUS : MonoBehaviour {

	Button RateUSButton;

	void Start () 
	{
		RateUSButton = this.GetComponent<Button> () as Button;
		RateUSButton.onClick.AddListener (GaminatorAds.Instance.RateUs);
	}


}
