using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kimicu.YandexGames;
using System;

public class YdLoader : MonoBehaviour
{
    public void YdInit()
    {
        Advertisement.Initialize();
        YandexGamesSdk.Initialize(GetComponent<Loader>().ContinueLoad);
    }

    public void StartGameReady()
    {
        if(PlayerData.firstLoad)
        { 
            PlayerData.firstLoad = false;
            YandexGamesSdk.GameReady();
        }
    }

    public void LoadAds()
    {
        Advertisement.ShowInterstitialAd();
    }

    public void LoadAdsWithReward(Action action)
    {
        Advertisement.ShowVideoAd(action);
    }
}
