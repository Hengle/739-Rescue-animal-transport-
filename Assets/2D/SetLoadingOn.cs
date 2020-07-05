using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLoadingOn : MonoBehaviour
{
    public GameObject loadingPanal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        loadingPanal.SetActive(true);


    }
}
