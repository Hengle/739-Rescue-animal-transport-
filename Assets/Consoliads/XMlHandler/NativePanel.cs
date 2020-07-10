using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NativePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cross;
    void OnEnable()
    {
        StartCoroutine(ActiveCrossButton());

    }
    IEnumerator ActiveCrossButton()
    {
        yield return new WaitForSeconds(5f);
        Cross.SetActive(true);
        try
        {
            int SceneIndex = SceneManager.GetActiveScene().buildIndex;

            Firebase.Analytics.FirebaseAnalytics.LogEvent("NativeAd_OnScene"+ SceneIndex.ToString());

        }
        catch
        {

        }
    }
    void OnDisable()
    {
        Cross.SetActive(false);
    }
}
