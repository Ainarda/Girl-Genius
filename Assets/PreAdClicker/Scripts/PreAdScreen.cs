using System;
using System.Collections;
using Kimicu.YandexGames;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PreAdScreen : MonoBehaviour
{
    [SerializeField] private ActiveLanguageSwitcher timer;
    [SerializeField] private int adDelaySec;
    [SerializeField] private PreAdClicker clicker;

    public static PreAdScreen Instance;

    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(transform.parent.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);

        canvasGroup = GetComponent<CanvasGroup>();
    } 
    
    #if UNITY_EDITOR
    [ContextMenu("Show AdClicker")]
    private void ShowAdClicker()
    {
        ShowInterstitialAdClicker();
    }
    #endif
    
    public void ShowInterstitialAdClicker(Action onClose = null)
    {
        if (!Advertisement.AdvertisementIsAvailable || !PlayerData.lvlAds)
            return;
        
        StartCoroutine(AdTimer(() =>
        {
            Advertisement.ShowInterstitialAd(onCloseCallback: onClose);
        }));
    }

    public void ShowRewardedAdClicker(Action rewardCallback, Action closeCallback = null)
    {
        StartCoroutine(AdTimer(() =>
        {
            Advertisement.ShowVideoAd(onRewardedCallback: rewardCallback, onCloseCallback: closeCallback);
        }));
    }

    private IEnumerator AdTimer(Action adCallback)
    {
        WebApplication.CustomValue = true;
        
        AnimatedShow();
        clicker.StartField();

        for (int i = adDelaySec; i > 0; i--)
        {
            timer.UpdateValue(i);
            yield return new WaitForSecondsRealtime(1);
        }
        
        AnimatedHide();
        clicker.StopField();

        adCallback.Invoke();
        
        WebApplication.CustomValue = false;
    }

    private void AnimatedShow()
    {        
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void AnimatedHide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
