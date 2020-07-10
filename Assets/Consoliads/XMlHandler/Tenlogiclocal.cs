
using System.Collections;
using UnityEngine;
using GamintorAdSdk;
using System.IO;
using System;
using System.Xml;
using UnityEngine.UI;

using EncryptStringSample;

public enum XML
{
    Local,
    Global,
    AGlobal
};

public class Tenlogiclocal : GaminatorNetworkHandlerDelegate
{
	public static XML xmltype;
	public static Tenlogiclocal Tenlogiclocal_ins;

	//public GameObject disclamerText;//LoadingBar

    public string filePath = "";
	public string result = "";
	public static bool onetimecall=true;
	public static bool onetimetimer=true;

	bool firstcheck,secondcheck,thirdcheck;
	public static bool fourthcheck;
	//public Text load_Text;
	public float time,scenetime=10f;//testing
	public static bool admanagercreated = false;
	string tempaddpackage,url;
	
	string imagePath, loadtextPath;
	string [] loading_Words;
	
	
	bool NetConnected = false;

	void Awake()
    {
        Tenlogiclocal_ins = this;
        try
        {

            if (onetimecall)
            {
                filePath = Application.streamingAssetsPath + "/" + PlayerPrefs.GetString("GameId") + "UserDetails.xml";
                xmltype = XML.Local;
            }

        }
        catch
        {
            Debug.LogError("XML Not Loaded");
        }

       // DontDestroyOnLoad(disclamerText.transform.parent.gameObject);

    }
	
	// Use this for initialization
	void Start ()
    {

        try
        {

            Time.timeScale = 1f;
           
            time = 0;
            

            if (onetimecall)
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    StartCoroutine(userDetailsXmlPath1());
                }
                else
                {
                    userDetailsXmlPath();
                }
                firstcheck = true;
                secondcheck = true;
                thirdcheck = true;
                onetimecall = true;
                fourthcheck = true;
            }

            onload_textdata();
            onload_disclaimerimage();
            

            StartCoroutine(checkInternetConnection((isConnected) =>
            {
                print("NET (((((((((((((((((((((((((    = " + isConnected);
                if (!isConnected)
                {

                    NetConnected = false;
                  

                }
                else
                {
                    NetConnected = true;
                }
                
            }));

           
        }
        catch
        {
            Debug.LogError("Ads Not Initialized");
        }

	}
    public void ShowNativeAd()
    {
        if (onetimetimer)
        {
            return;
        }

       // disclamerText.transform.parent.gameObject.GetComponent<Canvas>().sortingOrder = 100;
      //  disclamerText.transform.parent.gameObject.SetActive(true);
    }
    public void HideNativeAd()
    {
       // disclamerText.transform.parent.gameObject.GetComponent<Canvas>().sortingOrder = -100;
      //  disclamerText.transform.parent.gameObject.SetActive(false);
    }
    public void setnextscentimer(float settime)
    {
		scenetime = scenetime + settime;	
	}



	IEnumerator checkInternetConnection(Action<bool> action)
    {
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null)
        {
			action (false);
		} else
        {
			action (true);
		}
	} 


	// Update is called once per frame
	void Update ()
    {

        if(!onetimetimer)
        {
            return;
        }

		if (time>scenetime&&onetimetimer)
        {
			onetimetimer = false;
			onetimecall = false;
			
		} else
        {
			time += Time.deltaTime;
			
		}

		if (onetimecall&& xmltype==XML.Global)
        {
			if (string.IsNullOrEmpty (TenlogixAds.UR))
            {

			} else if (thirdcheck)
            {

				thirdcheck = false;
				if (!TenlogixAds.tenlogixAdsSdk_initialized)
                {

					Screen.sleepTimeout = SleepTimeout.NeverSleep;
					NetworkHandler networkobj = new NetworkHandler (this);
					TenlogixAds.setConfig (false, AGameUtils.PACKAGE_NAME, AGameUtils.PRODUCT_NAME, "1", networkobj, TenlogixAds.ScreenOrientation_Landscape);
				}
			}

            Debug.LogError("TenlogixAds.isadIDS_loadcounter   " + TenlogixAds.isadIDS_loadcounter);
           
            if (TenlogixAds.isadIDS_loadcounter == 1 && secondcheck)
            {
				
				onetimecall = false;
				secondcheck = false;
                Debug.LogError("LoadAdIcon TenlogixAds.isadIDS_loadcounter  loadstart_upads " + TenlogixAds.isadIDS_loadcounter);
                GameObject.Find("LoadAdIcon").GetComponent<LoadAdIcon>().loadAddsicon();
                

			} else if (TenlogixAds.isadIDS_loadcounter == 2 && secondcheck)
            {
				
				onetimecall = false;
				secondcheck = false;

			    Debug.LogError("LoadAdIcon Call loadAddsicon ");
                GameObject.Find("LoadAdIcon").GetComponent<LoadAdIcon>().loadAddsicon();
                   
				
                Debug.LogError("TenlogixAds.isadIDS_loadcounter 2 loadstart_upads " + TenlogixAds.isadIDS_loadcounter);
                
				
			}

		}
        else if(onetimecall&& xmltype==XML.AGlobal)
        {

			if (string.IsNullOrEmpty (TenlogixAds.AUR))
            {

			} else if (firstcheck)
            {
				firstcheck = false;
				if (!TenlogixAds.tenlogixAdsSdk_initialized)
                {
					Screen.sleepTimeout = SleepTimeout.NeverSleep;
					NetworkHandler networkobj = new NetworkHandler (this);
					TenlogixAds.setConfig (false, AGameUtils.PACKAGE_NAME, AGameUtils.PRODUCT_NAME, "1", networkobj, TenlogixAds.ScreenOrientation_Landscape);
				}

			}else if(!firstcheck)
            {
				if (TenlogixAds.isadIDS_loadcounter == 1 && secondcheck)
                {
					onetimecall = false;
					secondcheck = false;
				} 
			}

		}
        
	}
	void onload_textdata()
    {
		loadtextPath=Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"LoadText.txt";

		if (Application.platform == RuntimePlatform.Android)
        {
			StartCoroutine (loaddata_TextData ()); 
		} else
        {
			loadtextPath="file:///"+ Application.streamingAssetsPath + "/LoadText.txt";
			StartCoroutine (loaddata_TextData ()); 
		}
	}

	void onload_disclaimerimage()
    {
		
		imagePath=Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"Disclaimer.png";
		
		if (Application.platform == RuntimePlatform.Android)
        {
			StartCoroutine (loadsplash_Image ()); 
		} else
        {
			imagePath="file:///"+ Application.streamingAssetsPath + "/"+PlayerPrefs.GetString ("GameId")+"Disclaimer.png";

            loadsplash_Image1();

            //StartCoroutine (loadsplash_Image ()); 
		}
	}

	IEnumerator loadsplash_Image()
	{
		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false);
		WWW www = new WWW (imagePath);
		yield return www;

		if (www.error != null) {

			print ("filenotfound"+www.error);
		} else {
			www.LoadImageIntoTexture (text);

            //if (disclamerText.gameObject.GetComponent(typeof(UnityEngine.UI.Image)) != null)
            //{
            //    disclamerText.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            //    Sprite tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width, text.height), new Vector2(0.5f, 0.5f), 128f);
            //    disclamerText.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = tempaddsprite;
            //    disclamerText.gameObject.SetActive(true);
            //}
        }
    }

    void loadsplash_Image1()
    {
        Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false);
        WWW www = new WWW(imagePath);
       

        if (www.error != null)
        {

            print("filenotfound" + www.error);
        }
        else
        {
            www.LoadImageIntoTexture(text);

            //if (disclamerText.gameObject.GetComponent(typeof(UnityEngine.UI.Image)) != null)
            //{
            //    disclamerText.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            //    Sprite tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width, text.height), new Vector2(0.5f, 0.5f), 128f);
            //    disclamerText.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = tempaddsprite;
            //    disclamerText.gameObject.SetActive(true);
            //}
        }
    }

    IEnumerator loaddata_TextData()
	{
		WWW www = new WWW (loadtextPath);
		yield return www;

		if (www.error != null)
        {

			print ("filenotfound"+www.error);

		}
        else
        {

			string result=www.text;

			TextReader textReader = new StringReader (result);
			var filecontents = textReader.ReadToEnd ();
			result=StringCipher.Decrypt(filecontents, AGameUtils.Cipher_Passwords);
			loading_Words = result.Split ('\n');
			InvokeRepeating ("loadstrings", 1f, 2f);
		}
	}

	
	IEnumerator userDetailsXmlPath1()
	{
		WWW www = new WWW (filePath);
		yield return www;

		if (www.error != null)
        {

			print ("filenotfound");
		} else
        {
			string result = www.text;
			TextReader textReader = new StringReader (result);
			var filecontents = textReader.ReadToEnd ();
			result=StringCipher.Decrypt(filecontents, AGameUtils.Cipher_Passwords);
			TenlogixAds.temp_parsingxml(result);

		}
	}

	void userDetailsXmlPath() 
	{
        try
        {
            var stream = new StreamReader(filePath);
            var filecontents = stream.ReadToEnd();
            result = filecontents.ToString();
            //		print (result);
            result = StringCipher.Decrypt(result, AGameUtils.Cipher_Passwords);
            //		adtext.text = "" + result;
            TenlogixAds.temp_parsingxml(result);

        }
        catch
        {
            Debug.LogError("Ads Not Initialized");
        }

	}

	public override void NetworkCallFailure (string errorMsg)
	{
        try
        {
            TenlogixAds.init();
        }
        catch
        {
            Debug.LogError("Ads Not Initialized");
        }

	}

	public override void NetworkCallSuccess (string data)
	{
        try
        {
            Debug.LogError("NetworkCallSuccess");
            TenlogixAds.init(data);
        }
        catch
        {
            Debug.LogError("Ads Not Initialized");
        }

	}

}
