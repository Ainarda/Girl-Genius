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
        AudioListener.pause = true;
        Advertisement.ShowInterstitialAd(onCloseCallback: () => { AudioListener.pause = false; closeAction.Invoke(); });
    }

    public void LoadAdsWithReward(Action action, Action closeAction = null)
    {
        AudioListener.pause = true;
        Advertisement.ShowVideoAd(onRewardedCallback: ()=> { AudioListener.pause = false ; action.Invoke(); }, onCloseCallback: closeAction);
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
}