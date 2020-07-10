using UnityEngine;
using System.Collections;
using System;
using GamintorAdSdk;
using UnityEngine.UI;
using System.IO;
using Random=UnityEngine.Random;
public class MiniADdIcon_script : MonoBehaviour {
	public bool switchadicon=false;

	string url = "";
	string miniicon_url="";
	string tempaddpackage= "";
	public Mesh quadmesh;//must add quad mesh in it in Inspector.
	string switchtempaddpackage="",switchurl="";
	Sprite tempaddsprite,switchtempaddsprite;
	bool checkurl=false;
	string tempurl="";
	bool checkshowadd;
	// for next icon implementation
	bool isNicon=false;//next icon available
	bool isTransicon=false;//is transition of next icon happen
	// for transition variables ----------------------------
	GameObject child;
	float journeyLength;
	float speed=200f,startTime;
	Vector3 startMarker, endMarker;
	bool checktransition, lerpiconcheck=true;
	int recursivecalls=0;
	void Start () {
		if (PlayerPrefManager.Instance.IsAdsRemoved())
        {
			this.gameObject.SetActive (false);
			return;
		}
		//transition stuff--------------------------------------
		checktransition = false;
		recursivecalls = 0;
		if (this.gameObject.transform.childCount > 0) {
			child = this.gameObject.transform.GetChild (0).gameObject;
			startMarker = new Vector3 (this.gameObject.GetComponent<RectTransform> ().localPosition.x, this.gameObject.GetComponent<RectTransform> ().localPosition.y, this.gameObject.GetComponent<RectTransform> ().localPosition.z);
			endMarker = new Vector3 (this.gameObject.GetComponent<RectTransform> ().rect.width * -1f, this.gameObject.GetComponent<RectTransform> ().localPosition.y, this.gameObject.GetComponent<RectTransform> ().localPosition.z);

			//			endMarker.position = new Vector3 (this.gameObject.GetComponent<RectTransform> ().rect.width * -1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		} else {
			switchadicon = false;
		}

		// transition stuff ----------------------------------------------
		checkshowadd = true;
		checkurl = false; // for switch everytimeadicon
		miniicon_url="";//for switch everytimeadicon
		url = "";//for switch everytimeadicon
		tempaddpackage = "";//for switch everytimeadicon
		switchtempaddpackage = "";//for switch everytimeadicon
		if (this.gameObject.GetComponent (typeof(UnityEngine.UI.Image)) != null) {
			this.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = false;
		}
		if (this.gameObject.GetComponent (typeof(SpriteRenderer)) != null) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}

		if((this.gameObject.GetComponent (typeof(UnityEngine.UI.Image)) == null)&&(this.gameObject.GetComponent(typeof(MeshFilter))==null)&&(this.gameObject.GetComponent(typeof(SpriteRenderer))==null)){
			checkshowadd = false;
		}
		
		if (Application.platform == RuntimePlatform.Android && TenlogixAds.arlist.Count<=0) {
			this.gameObject.SetActive (false);
		}
		//		if (checkshowadd && checkurl) {
		//			if (TenlogixAds.isBackFilledEnabled) {
		//				StartCoroutine ("GetAddPackage");
		//
		//			}else {
		//				print ("this run");
		//				this.gameObject.SetActive (false);
		//			}
		//		}
//		print ("this run4");
	}
	IEnumerator CallManageRoutine(float sec)
	{
		yield return new WaitForSecondsRealtime(sec);
		ManageswitchController ();
	}
	IEnumerator CallswitchRoutine(float sec)
	{
		yield return new WaitForSecondsRealtime(sec);
		switchicontransitionmanager ();
	}
	void OnGUI ()
    {
		if (!checkurl)
        {
			if (string.IsNullOrEmpty (tempurl))
            {
				if (Application.platform != RuntimePlatform.Android) {
					tempurl = "" + TenlogixAds.getaddsurlpackage ();
					//Debug.Log ("backfill-"+TenlogixAds.isBackFilledEnabled);
					if (switchadicon) {
						int i = 0;
						//Debug.Log ("Count-"+TenlogixAds.arrpackages.Length);
						foreach(string arr in TenlogixAds.arrpackages){
//							Debug.Log ("pack-"+arr);
							if(arr.Contains (switchtempaddpackage))
								i++;
						}
//						i = i * 4;
						i = 4;
						//						Invoke ("ManageswitchController",2f);
						StartCoroutine(CallManageRoutine (2f));
						//						Invoke ("switchicontransitionmanager", (float)i);
						StartCoroutine(CallswitchRoutine ((float)i));
					}
				} else {
					Debug.Log ("Count-"+TenlogixAds.arlist.Count);
					if (TenlogixAds.arlist.Count > 0) {
						tempurl = "" + TenlogixAds.arlist [Random.Range (0, TenlogixAds.arlist.Count)];
						if (switchadicon) {
							int i = 0;
							foreach (var list in TenlogixAds.arlist) {
								if (list.Contains (tempurl))
									i++;
							}
//							i = i * 4;
							i = 4;
							//						Invoke ("ManageswitchController",2f);
							StartCoroutine(CallManageRoutine (2f));
							//						Invoke ("switchicontransitionmanager", (float)i);
							StartCoroutine(CallswitchRoutine ((float)i));
						}
					}
				}

			}  else
            {
				url = tempurl;
				tempaddpackage = GetProductName (tempurl);

				checkurl = true;
	

				miniicon_url = "market://details?id=" + tempaddpackage;

				if (checkshowadd)
                {

					StartCoroutine ("GetAddPackage");
				}  else
                {
					if (PlayerPrefManager.Instance.IsAdsRemoved())//PlayerPrefManager.Instance.IsAdsRemoved()//TenlogixAds.isBackFilledEnabled
                    {
						print ("this run2");
						StartCoroutine ("Temp_atbackend_GetAddPackage");
					} else
                    {					
						this.gameObject.SetActive (false);
					}
				}
			}

		}


		if (checktransition)
        {
			do_transition ();
		}	

	}

	IEnumerator GetAddPackage()
    {

		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false); //TextureFormat must be DXT
		//-check whether the required imageicon present in cache(persistantdata) or otherwise it will be download form site and add in cache.
		if (File.Exists (Application.persistentDataPath + "/" + tempaddpackage+ ".png"))
        {
			byte[] imgBytes=System.IO.File.ReadAllBytes (Application.persistentDataPath + "/" + tempaddpackage+ ".png");
			//			Debug.Log (Application.persistentDataPath + "/" + tempaddpackage+ ".png");
			text.LoadImage (imgBytes);

			//if we use mesh filter in our game object 
			if(this.gameObject.GetComponent(typeof(MeshFilter))!=null){
				this.GetComponent<MeshFilter> ().mesh = quadmesh;
				Renderer renderer = GetComponent<Renderer>();
				renderer.material.mainTexture = text;
				renderer.material.shader = Shader.Find ("Sprites/Default");
			}
			//if we use Image(script) in our game object like in our canvas 
			else if(this.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null){
				//				Debug.Log ("in elseif UI image");
				this.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = true;
				tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
				this.gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = tempaddsprite;
			}
			//if we use SpriteRenderer in our game object 
			else if(this.gameObject.GetComponent(typeof(SpriteRenderer))!=null){
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = tempaddsprite;
				this.gameObject.GetComponent<SpriteRenderer>().material.shader = Shader.Find ("Sprites/Default");
			}
		}  else
        {
			// Start a download of the given URL
			WWW www = new WWW(url);
			// Wait for download to complete
			yield return www;

			if (www.error != null) {
				//				Debug.Log ("Internet not connected-- couldnot find icon"+www.error.ToString());
				print ("this run");
				this.gameObject.SetActive(false);

			}  else {
				www.LoadImageIntoTexture (text);
				System.IO.File.WriteAllBytes (Application.persistentDataPath + "/" + tempaddpackage + ".png", www.bytes);
				//				Debug.Log (Application.persistentDataPath + "/" + tempaddpackage+ ".png");
				//if we use mesh filter in our game object 
				if(this.gameObject.GetComponent(typeof(MeshFilter))!=null){
					this.GetComponent<MeshFilter> ().mesh = quadmesh;
					Renderer renderer = GetComponent<Renderer>();
					renderer.material.mainTexture = text;
					renderer.material.shader = Shader.Find ("Sprites/Default");
				}
				//if we use Image(script) in our game object like in our canvas 
				else if(this.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null){
					//					Debug.Log ("in elseif UI image");
					this.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = true;
					tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
					this.gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = tempaddsprite;
				}
				//if we use SpriteRenderer in our game object 
				else if(this.gameObject.GetComponent(typeof(SpriteRenderer))!=null){
					this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
					tempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = tempaddsprite;
					this.gameObject.GetComponent<SpriteRenderer>().material.shader = Shader.Find ("Sprites/Default");
				}
			}
		}
	}
	//use for back end  running to get icon while player playing the game in game playing mode.
	IEnumerator Temp_atbackend_GetAddPackage()
    {
		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false); //TextureFormat must be DXT
		//-check whether the required imageicon present in cache(persistantdata) or otherwise it will be download form site and add in cache.
		if (File.Exists (Application.persistentDataPath + "/" + tempaddpackage+ ".png"))
        {

		}  else
        {
			// Start a download of the given URL
			WWW www = new WWW(url);

			yield return www;
			if (www.error != null)
            {
				Debug.Log ("Internet not connected-- couldnot find icon");

			}else
            {
				www.LoadImageIntoTexture (text);
				System.IO.File.WriteAllBytes (Application.persistentDataPath + "/" + tempaddpackage + ".png", www.bytes);
			}
		}
	}
	IEnumerator temporaryload_icon()
    {
		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false); //TextureFormat must be DXT
		//-check whether the required imageicon present in cache(persistantdata) or otherwise it will be download form site and add in cache.
		if (File.Exists (Application.persistentDataPath + "/" + switchtempaddpackage+ ".png"))
        {
			byte[] imgBytes=System.IO.File.ReadAllBytes (Application.persistentDataPath + "/" + switchtempaddpackage+ ".png");
			//			Debug.Log (Application.persistentDataPath + "/" + switchtempaddpackage+ ".png");
			text.LoadImage (imgBytes);
			if(this.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null){
				switchtempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
				child.GetComponent<UnityEngine.UI.Image> ().sprite = switchtempaddsprite;
			}

			isNicon = true;
			if (isTransicon) {
				switchicontransitionmanager ();
			}
			//			Debug.Log (Application.persistentDataPath + "/" + switchtempaddpackage+ ".png");
		}
        else
        {
			// Start a download of the given URL
			WWW www = new WWW(switchurl);
			// Wait for download to complete
			yield return www;
			if (www.error != null)
            {
				ManageswitchController ();
			}  else
            {
				www.LoadImageIntoTexture (text);
				System.IO.File.WriteAllBytes (Application.persistentDataPath + "/" + switchtempaddpackage + ".png", www.bytes);

				if(this.gameObject.GetComponent(typeof(UnityEngine.UI.Image))!=null)
                {
					switchtempaddsprite = Sprite.Create(text, new Rect(0f, 0f, text.width,text.height), new Vector2(0.5f, 0.5f),128f);
					child.GetComponent<UnityEngine.UI.Image> ().sprite = switchtempaddsprite;
				}
				isNicon = true;
				if (isTransicon)
                {
					switchicontransitionmanager ();
				}
				//				Debug.Log (Application.persistentDataPath + "/" + switchtempaddpackage+ ".png");
			}
		}
	}


	void OnEnable(){
		if (PlayerPrefManager.Instance.IsAdsRemoved()) {
			this.gameObject.SetActive (false);
			return;
		}
		
		if (Application.platform == RuntimePlatform.Android && TenlogixAds.arlist.Count<=0) {
			this.gameObject.SetActive (false);
			return;
		}
		if (checkurl) {
			if (isNicon) {
				switchicontransitionmanager ();
			} else {
				//checktransition = true;
//				Debug.Log ("NNNOt nexticonavailable");
				if (this.gameObject.GetComponent (typeof(UnityEngine.UI.Image)) != null) {
					this.gameObject.GetComponent<UnityEngine.UI.Image> ().enabled = false;
				}
				tempurl = "";
				checkurl = false;
				
			}
		}
			
	}

	void rearrangethings(){
		tempaddpackage = switchtempaddpackage;
		miniicon_url = "market://details?id=" + tempaddpackage;
		isNicon = false;
//		lerpiconcheck = true;
		if (Application.platform == RuntimePlatform.Android)
        {
			
				int i = 0;
				foreach (var list in TenlogixAds.arlist)
                {
					if (list.Contains (switchtempaddpackage))
						i++;
				}
				i = i * 2;

				StartCoroutine (CallswitchRoutine ((float)i));
			
		} else
        {
			
				int i = 0;
				foreach (string arr in TenlogixAds.arrpackages)
                {
					if (arr.Contains (switchtempaddpackage))
						i++;
				}
				i = i * 2;

				StartCoroutine (CallswitchRoutine ((float)i));
			
		}
		ManageswitchController ();
	}

	void do_transition()
    {
		float distCovered = (Time.unscaledTime - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		this.gameObject.GetComponent<RectTransform>().transform.localPosition = Vector3.Lerp(startMarker, endMarker, fracJourney);

		if (fracJourney > 1f) {
			checktransition = false;
			this.gameObject.GetComponent<RectTransform> ().localPosition = startMarker;
			this.gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = child.GetComponent<UnityEngine.UI.Image> ().sprite;
			rearrangethings ();
		}

	}

	void switchicontransitionmanager()
    {
		if (switchadicon && isNicon)
        {
			checktransition = true;
			startTime = Time.unscaledTime;
			isTransicon = false;
//			lerpiconcheck = false;
			journeyLength = Vector3.Distance (startMarker, endMarker);

		} else if (switchadicon && !isNicon)
        {
			isTransicon = true;
		}
	}

	void ManageswitchController(){
		if (!isNicon&&switchadicon) {
			if (Application.platform != RuntimePlatform.Android)
            {
				switchurl = "" + TenlogixAds.getaddsurlpackage ();
				recursivecalls++;
			} else {
				switchurl = "" + TenlogixAds.arlist[Random.Range(0,TenlogixAds.arlist.Count)];
				recursivecalls++;
			}

			if ((GetProductName(switchurl) == tempaddpackage) && recursivecalls<13 ) {
				ManageswitchController ();
			}else {
				//				Debug.Log (GetProductName(switchurl)+tempaddpackage);
				recursivecalls=0;
				switchtempaddpackage = GetProductName (switchurl);
//				Debug.Log ("manages"+switchtempaddpackage);
				StartCoroutine ("temporaryload_icon");
			}
		}
	}


	string GetProductName(string getstringname) {
		string dataPath = getstringname;
		if (dataPath.Contains ("/") && dataPath.Contains (".")) {
			int lastPartStart = dataPath.LastIndexOf ("/", StringComparison.Ordinal) + 1;
			getstringname = dataPath.Substring (lastPartStart, dataPath.Length - lastPartStart);
			lastPartStart = getstringname.LastIndexOf (".", StringComparison.Ordinal) + 1;
			//			print ("lastpart-" + lastPartStart + "getstringlenth" + getstringname.Length);
			return getstringname.Substring (0, getstringname.Length - (getstringname.Length - lastPartStart + 1));
		} else {
			return dataPath;
		}
	}

	public void OnMiniaddicon(){
//		Debug.Log ("PP-"+miniicon_url);
		Application.OpenURL (""+miniicon_url);
	}

	public void OnCrossbtn(){
		if (this.gameObject.activeInHierarchy) {
			this.gameObject.SetActive (false);
			Invoke ("OnthisObject", 11f);
		}
	}

	void OnthisObject(){
		this.gameObject.SetActive (true);
	}
}

