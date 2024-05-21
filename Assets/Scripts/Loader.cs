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

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string GetLang();
#endif

    // Start is called before the first frame update
    void Start()
    {
        try
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerData.localText = GetLang();
        
#endif
        }
        catch
        {
            Debug.LogWarning("Can't get lang from ySDK");
        }

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
        SceneManager.LoadScene("Maison");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
