using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour {
    public static ModeSelection Instance;
    public GameObject EnvSelection;
    public GameObject[] ModesLevel;
    private GameObject CurrentModeLevel;
    public GameObject Loading;
	// Use this for initialization
	void Start () {
		
	}
	
	public void _horsemood()
	{
	    CustomAnalytics.logLevelStarted ("ModSelection","Zebra");
		PlayerPrefs.SetInt ("MHorse",1);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}



	public void _lionemood()
	{
     	  CustomAnalytics.logLevelStarted ("ModSelection","Lionmood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",1);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _sheepemood()
	{
		  CustomAnalytics.logLevelStarted ("ModSelection","sheepemood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",1);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}
	public void _cowmood()
	{
	  CustomAnalytics.logLevelStarted ("ModSelection","cowmood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",1);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _Deermood()
	{
		 CustomAnalytics.logLevelStarted ("ModSelection","Deermood");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",1);
		PlayerPrefs.SetInt ("MDog",0);
	}


	public void _Dogmood()
	{
		 CustomAnalytics.logLevelStarted ("ModSelection","TigerMod");
		PlayerPrefs.SetInt ("MHorse",0);
		PlayerPrefs.SetInt ("MLion",0);
		PlayerPrefs.SetInt ("MSheep",0);
		PlayerPrefs.SetInt ("MCow",0);
		PlayerPrefs.SetInt ("MDeer",0);
		PlayerPrefs.SetInt ("MDog",1);

	}

	public void _back()
	{
		 CustomAnalytics.logLevelStarted ("levelBackBtn","ModSelection");
		Application.LoadLevel ("MainMenu");
	}
    public void SelectMode(GameObject currentmode)
    {
        CurrentModeLevel = currentmode;
        StartCoroutine("CR_LoadScene", CurrentModeLevel);
    }
    public void EnvSelectMode(GameObject currentmode)
    {
        CurrentModeLevel = currentmode;
        StartCoroutine("CR_LoadScene",EnvSelection);
    }
    private IEnumerator CR_LoadScene(GameObject envmod)
    {
        yield return new WaitForSeconds(3f);
        envmod.SetActive(true);
        Loading.SetActive(false);
    }
    public void SelectModeLevel()
    {
        foreach (GameObject j in ModesLevel)
            j.SetActive(false);
        StartCoroutine("CR_LoadScene", CurrentModeLevel);
    }
    public void Back_From_Mode(GameObject obj)
    {
        StartCoroutine("CR_LoadScene",obj);
    }
}
