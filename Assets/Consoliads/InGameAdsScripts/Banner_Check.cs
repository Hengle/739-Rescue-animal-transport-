using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner_Check : MonoBehaviour
{
    public GameObject[] banners;

    void OnEnable()
    {
        if (banners != null)
        {
            for (int i = 0; i < banners.Length; i++)
            {
                banners[i].SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        if (banners != null)
        {
            for (int i = 0; i < banners.Length; i++)
            {
                banners[i].SetActive(true);
            }
        }
    }

    void OnDestroy()
    {
        if (banners != null)
        {
            for (int i = 0; i < banners.Length; i++)
            {
                banners[i].SetActive(false);
            }
        }
        print("checked destroy");
    }
}
