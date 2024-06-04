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
        WebApplication.Initialize(StopGame);
    }

    public void LoadAdvert()
    {
        Debug.Log("Start load Advert");
        Advertisement.Initialize();
        LoadLanguage();
        Billing.Initialize();
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
        Debug.Log("End load lang");
        GetComponent<Loader>().ContinueLoad();
    }

    public void StartGameReady()
    {
        if(PlayerData.firstInit)
        { 
            PlayerData.firstLoad = false;
            YandexGamesSdk.GameReady();
        }
    }

    public void LoadAds(Action closeAction)
    {
        AudioListener.pause = true;
        PreAdScreen.Instance.ShowInterstitialAdClicker(closeAction);
    }

    public void LoadAdsWithReward(Action action, Action closeAction = null)
    {
        AudioListener.pause = true;
        PreAdScreen.Instance.ShowRewardedAdClicker(action, closeAction);
    }

    public void Purchase(string id)
    {
        Billing.PurchaseProduct(id, AfterPurchase);
    }

    private void AfterPurchase( Agava.YandexGames.PurchaseProductResponse product)
    {
        var token = product.purchaseData.purchaseToken;
        if(token == PurchaseData.id[0])
        {
            PlayerData.lvlAds = false;
        }
        else if(token == PurchaseData.id[0])
        {
            PlayerData.lvlAds = false;
            PlayerData.UnlockAllRoom();
            PlayerData.AddCoin(15000);
        }
        else
        {

        }
        Billing.ConsumeProduct(token);
        GetComponent<Observer>().SavePlayerData();
    }



    private void StopGame(bool isStopGame)
    {
        AudioListener.pause = isStopGame;
        AudioListener.volume = isStopGame ? 0 : 1;
        Time.timeScale = isStopGame ? 0 : 1;
    }
}
