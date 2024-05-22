using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kimicu.YandexGames;
using System;
using Kimicu.YandexGames.Utils;

public class YdLoader : MonoBehaviour
{
    public void YdInit()
    {
        Debug.Log("Start load SDK");
        StartCoroutine(YandexGamesSdk.Initialize(LoadAdvert));
        Debug.Log("Step 2");
    }

    public void LoadAdvert()
    {
        Debug.Log("Start load Advert");
        Advertisement.Initialize();
        LoadLanguage();
    }

    public void LoadLanguage()
    {
        Debug.Log("Start load lang");
        try
        {
            PlayerData.localText = YandexGamesSdk.Environment.i18n.lang;
        }
        catch
        {
            Debug.Log("Can't load SDK!");
        }
        GetComponent<Loader>().ContinueLoad();
    }

    public void StartGameReady()
    {
        if(PlayerData.firstLoad)
        { 
            PlayerData.firstLoad = false;
            YandexGamesSdk.GameReady();
        }
    }

    public void LoadAds(Action closeAction)
    {
        Advertisement.ShowInterstitialAd(onCloseCallback: closeAction);
    }

    public void LoadAdsWithReward(Action action, Action closeAction = null)
    {
        Advertisement.ShowVideoAd(onRewardedCallback: action, onCloseCallback: closeAction);
    }
}
