using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class AdIconListner : MonoBehaviour
{
    private RawImage img;
    private Animator anim;

    private string appIdentifier;
    bool adIconLoaded = false;

    float time = 0;
    float delay = 7;
    float defaultDelay = 5;
    float adCheckDelay = 2;

    private void Start()
    {
        img = this.GetComponent<RawImage>();
        anim = this.GetComponent<Animator>();

        time = 1;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (IsAdTextureAvaiable()) {

                anim.SetTrigger("LoadAd");
            }
            
            time = delay;
        }
    }

    private bool IsAdTextureAvaiable() {

        Texture tex = GaminatorAds.AdIconHandler.Get_AdIconTexHandling();
        if (tex != null)
        {
            delay = defaultDelay;
            return true;
        }
        else
        {
            delay = adCheckDelay;
            return false;
        }
    }

    public void LoadIconData() {

        Texture tex = GaminatorAds.AdIconHandler.Get_AdIconTexHandling();
        appIdentifier = GaminatorAds.AdIconHandler.GetCurAdIconIdentifier();

        img.texture = tex;
        adIconLoaded = true;
        GaminatorAds.AdIconHandler.Inc_CurAdIconHandling();

    }

    public void OnPress_Icon()
    {
        //GaminatorAds.Soundmanager.PlaySound(GaminatorAds.Soundmanager.buttonPress);

        if (adIconLoaded)
        {
          //  GaminatorAds.GaminatorAds.GA_DesignEvent("Press_AdIcon_" + appIdentifier);
            Application.OpenURL(Constants.link_StoreInitial + appIdentifier);
        }
        else {
         //   Toolbox.GameManager.GA_DesignEvent("Press_AdIcon_" + Constants.localAdAppIdentifier);
            Application.OpenURL(Constants.link_StoreInitial + Constants.localAdAppIdentifier);
        }
    }
}
