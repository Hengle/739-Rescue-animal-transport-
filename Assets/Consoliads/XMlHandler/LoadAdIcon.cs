using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamintorAdSdk;
using System.IO;

public class LoadAdIcon : MonoBehaviour
{
    int iterateicon;
    string tempaddpackage, url;
   // bool IsAdIcon;
    void Awake()
    {
        iterateicon = 0;
        DontDestroyOnLoad(this.gameObject);
    }
    public void loadAddsicon()
    {
        
       
        try
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (TenlogixAds.arlist.Count > 0)
                {
                    if (iterateicon < TenlogixAds.arlist.Count)
                    {
                        //					url = TenlogixAds.arlist [UnityEngine.Random.Range (0, TenlogixAds.arlist.Count)];
                        url = TenlogixAds.arlist[iterateicon];
                        tempaddpackage = TenlogixAds.GetProductName(url);
                        StartCoroutine("Temp_atbackend_GetAddPackage");
                    }
                }
            }
            else
            {

                if (iterateicon < TenlogixAds.arrpackages.Length)
                {
                    //				url=TenlogixAds.getaddsurlpackage ();
                    url = TenlogixAds.arrpackages[iterateicon];
                    tempaddpackage = TenlogixAds.GetProductName(url);
                    StartCoroutine("Temp_atbackend_GetAddPackage");
                }
            }


        }
        catch
        {
            Debug.LogError("LoadAdIcon Not Loaded");
        }

    }

    IEnumerator Temp_atbackend_GetAddPackage()
    {
        //	Debug.Log ("t-"+tempaddpackage+"-u-"+url);
        //		Texture2D text = new Texture2D(512, 512, TextureFormat.DXT1, false); //TextureFormat must be DXT
        //-check whether the required imageicon present in cache(persistantdata) or otherwise it will be download form site and add in cache.
        if (File.Exists(Application.persistentDataPath + "/" + tempaddpackage + ".png"))
        {
            Debug.LogError("LoadAdIcon   "+ "iterateicon    " + iterateicon + "tempaddpackage   " + tempaddpackage);
            yield return null;
            iterateicon++;
            loadAddsicon();
        }
        else
        {
            // Start a download of the given URL
            WWW www = new WWW(url);
            // Wait for download to complete
            yield return www;
            if (www.error != null)
            {
                Debug.Log("Internet not connected-- couldnot find icon");

            }
            else
            {
                
                File.WriteAllBytes(Application.persistentDataPath + "/" + tempaddpackage + ".png", www.bytes);
                iterateicon++;
                loadAddsicon();

            }
        }

    }
}
