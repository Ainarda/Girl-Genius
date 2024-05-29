using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    [SerializeField]
    private string[] purchasingId;
    // Start is called before the first frame update
    void Start()
    {
        /*      try
              {
      #if UNITY_WEBGL && !UNITY_EDITOR
              PlayerData.localText = GetLang();

      #endif
              }
              catch
              {
                  Debug.LogWarning("Can't get lang from ySDK");
              }
        */
        PurchaseData.id = purchasingId;
        Observer observer = GetComponent<Observer>();
        try
        {
            observer.LoadData();
        }
        catch {

        }
        try
        {
            GetComponent<YdLoader>().YdInit();
        }
        catch
        {
            Debug.LogWarning("Can't load yandexSDK");
            ContinueLoad();
        }

    }

    public void ContinueLoad()
    {
        if (!PlayerData.firstInit)
            SceneManager.LoadScene("Maison");
        else
            SceneManager.LoadScene("Level_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
