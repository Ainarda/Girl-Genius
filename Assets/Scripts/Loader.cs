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
        Debug.Log("Continue Load");
        Debug.Log(PlayerData.firstInit);
        GetComponent<YdLoader>().StartGameReady();
        if (PlayerData.firstInit)
            SceneManager.LoadScene("Maison");
        else
        {
            PlayerData.firstInit = true;
            GetComponent<Observer>().SavePlayerData();
            SceneManager.LoadScene("Level_1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
