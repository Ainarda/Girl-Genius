using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PreAdTimer : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private Image fillImage;
    
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        Hide();

        InvokeRepeating(nameof(StartTimer), 70, 70); // если игра запускается не сразу, а с каким то меню или вроде того - запускай это после меню
    }

    private void StartTimer()
    {
        if (true) // проверяй доступна ли реклама тут
            StartCoroutine(AdTimerCoroutine());
    }

    private IEnumerator AdTimerCoroutine()
    {
        float timer = delay;
        fillImage.fillAmount = 1;

        Show();
        
        while (timer > 0)
        {
            yield return null;
            timer -= Time.deltaTime;
            fillImage.fillAmount = timer / delay;
        }
        
        Hide();
        
        PreAdScreen.Instance.ShowInterstitialAdClicker();
    }

    private void Show()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
