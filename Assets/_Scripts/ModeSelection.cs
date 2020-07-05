using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void _horsemood()
	{
	    //  //CustomAnalytics.logLevelStarted ("ModSelection","Zebra");
		PlayerPrefs.SetInt ("MHorse",1);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}



	public void _lionemood()
	{
     	  //CustomAnalytics.logLevelStarted ("ModSelection","Lionmood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",1);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _sheepemood()
	{
		  //CustomAnalytics.logLevelStarted ("ModSelection","sheepemood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",1);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _cowmood()
	{
	  //CustomAnalytics.logLevelStarted ("ModSelection","cowmood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",1);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _Deermood()
	{
		  //CustomAnalytics.logLevelStarted ("ModSelection","Deermood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",1);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _Dogmood()
	{
		  //CustomAnalytics.logLevelStarted ("ModSelection","TigerMod");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",1);

	}

	public void _back()
	{
		  //CustomAnalytics.logLevelStarted ("levelBackBtn","ModSelection");
		Application.LoadLevel ("MainMenu");
	}

}
