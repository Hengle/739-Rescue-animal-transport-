using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsConsentFirstController : MonoBehaviour {


	public GameObject consentad_untickpanel, consenttad_tickpanel, UserSplash;
	public static int firstcount = 0;
//	public string GameUniqueIdValue ="";
//	public static string GameUniqueId = "";
	string imagePath1 ="";
	string imagePath2 ="";

	void Awake(){

       
     //  PlayerPrefs.DeleteAll ();

	
	}
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt ("ConsentAd", 0)==0)
        {
            UserSplashScreen();
            Consent1Load();
            Consent2Load();
        } else
        {
            consentad_untickpanel.SetActive(false);
            UserSplashScreen();
            StartCoroutine(WaitForMainMenu());
            //SceneManager.LoadScene (1);
        }
		
        //		consenttad_tickpanel.SetActive (false);
        //		consentad_untickpanel.SetActive (true);

       

       
	}


	void Consent1Load(){
        UserSplash.SetActive(false);
        imagePath1 =Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"ConsentS1.jpg";
		if (Application.platform == RuntimePlatform.Android) {
			StartCoroutine (loadConsent1_Image ()); 
		} else {
			imagePath1="file:///"+ Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"ConsentS1.jpg";

			StartCoroutine (loadConsent1_Image()); 
		}
	}
	IEnumerator loadConsent1_Image()
	{
		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false);
		WWW www = new WWW (imagePath1);
		yield return www;

		if (www.error != null) {

			print ("filenotfound"+www.error);
		} else {
			www.LoadImageIntoTexture (text);
			if(consentad_untickpanel.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null){
				consentad_untickpanel.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = true;
				Sprite tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
				consentad_untickpanel.gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = tempaddsprite;
				if (PlayerPrefs.GetInt ("ConsentAd", 0) == 0) {
					consentad_untickpanel.gameObject.SetActive (true);
				}
			}
		}
	}
	void Consent2Load(){
		imagePath2=Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"ConsentS2.jpg";

		if (Application.platform == RuntimePlatform.Android) {
			StartCoroutine (loadConsent2_Image ()); 
		} else {
			imagePath2="file:///"+ Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"ConsentS2.jpg";
			StartCoroutine (loadConsent2_Image()); 
		}
	}
	IEnumerator loadConsent2_Image()
	{
		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false);
		WWW www = new WWW (imagePath2);
		yield return www;

		if (www.error != null) {

			print ("filenotfound"+www.error);
		} else {
			www.LoadImageIntoTexture (text);
			if(consenttad_tickpanel.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null){
				consenttad_tickpanel.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = true;
				Sprite tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
				consenttad_tickpanel.gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = tempaddsprite;
//				consenttad_tickpanel.gameObject.SetActive (true);
			}
		}
	}
    void UserSplashScreen()
    {
        imagePath2 = Application.streamingAssetsPath + "/" + PlayerPrefs.GetString("GameId") + "UserSplash.jpg";

        if (Application.platform == RuntimePlatform.Android)
        {
            StartCoroutine(UserSplashScreen_Image());
        }
        else
        {
            imagePath2 = "file:///" + Application.streamingAssetsPath + "/" + PlayerPrefs.GetString("GameId") + "UserSplash.jpg";
            StartCoroutine(UserSplashScreen_Image());
        }
    }
    IEnumerator UserSplashScreen_Image()
    {
        Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false);
        WWW www = new WWW(imagePath2);
        yield return www;

        if (www.error != null)
        {

            print("filenotfound" + www.error);
        }
        else
        {
            www.LoadImageIntoTexture(text);
            if (UserSplash.gameObject.GetComponent(typeof(UnityEngine.UI.Image)) != null)
            {
                UserSplash.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
                Sprite tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width, text.height), new Vector2(0.5f, 0.5f), 128f);
                UserSplash.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = tempaddsprite;
               
            }
        }
    }

    public void On_tickbutton(){
		consenttad_tickpanel.SetActive (true);
		consentad_untickpanel.SetActive (false);
	}

	public void On_Untickbutton(){
		consenttad_tickpanel.SetActive (false);
		consentad_untickpanel.SetActive (true);
	}

	public void On_consentokbutton(){
        UserSplash.SetActive(true);
        consentad_untickpanel.SetActive(false);
        //UserSplashScreen();
        consenttad_tickpanel.SetActive(false);
        PlayerPrefs.SetInt("ConsentAd", 1);
        StartCoroutine(WaitForMainMenu());
       
		//SceneManager.LoadScene (1);
	}
	public void On_withdraw(){
		PlayerPrefs.SetInt ("ConsentAd",0);
		
	}

	public void On_consentokMainbutton(){
		PlayerPrefs.SetInt ("ConsentAd",1);
		
	}
    IEnumerator WaitForMainMenu()
    {

        UserSplash.SetActive(true);
        consentad_untickpanel.SetActive(false);
        consenttad_tickpanel.SetActive(false);
        try
        {
            //GaminatorAds.Instance.ShowSmartBanner(0);

        }
        catch
        {
            Debug.Log("Pre Splash Screen Fail ShowBigBannerTopLeft");
        }

        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);

    }
//	public void On_consentokMainbtn(){
//		
//	}

//	public void On_privacyCrossbtn(){
//		
//	}
//
//	public void On_privacytextbtn(){
//		
//	}
//
//	public void On_privacywithdrawbtn(){
//		
//	}
}
