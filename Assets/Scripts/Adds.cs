using Kimicu.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAds(Action nextAction)
    {
        Advertisement.ShowInterstitialAd(onCloseCallback: nextAction);
    }

    public void ShowRewardAds(Action rewardAction)
    {
        Advertisement.ShowVideoAd(onRewardedCallback: rewardAction);
    }
}
