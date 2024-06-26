using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour
{
    TMP_Text coinText;
    Text lvlText;
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private GameObject loseUI;
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject messageUI;
    [SerializeField]
    private GameObject petRewardUI;
    [SerializeField]
    private GameObject environmentRewardUI;
    [SerializeField]
    private GameObject eventSystem;
    [SerializeField]
    private GameObject sceneAudioSource;
    [SerializeField]
    private GameObject mainAudioSource;
    [SerializeField]
    private ActionVariant actionManager;
    [SerializeField]
    private GameObject audioManager;

    private Observer observer;
    private void Awake()
    {
        if (!GameObject.Find("EventSystem"))
            eventSystem = Instantiate(eventSystem);
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        actionManager = GetComponent<ActionVariant>();
        InitUI();
        InitAudio();

        observer.AddScreens(winUI, loseUI, mainUI, petRewardUI, environmentRewardUI);
        lvlText = GameObject.FindGameObjectWithTag("LevelUI").GetComponent<Text>();
        coinText = GameObject.FindGameObjectWithTag("CoinUI").GetComponent<TMP_Text>();
        PlayerData.CoinUI = coinText;
        string[] sceneNameText = SceneManager.GetActiveScene().name.Split('_', System.StringSplitOptions.RemoveEmptyEntries);
        string sceneName;
        if (PlayerData.localText == "ru")
            sceneName = "Уровень";
        else
            sceneName = "Level";
        lvlText.text = sceneName + " " + sceneNameText[1];
        coinText.text = "<sprite index=0> "+PlayerData.PlayerCoin.ToString();
    }

    private void InitUI()
    {
        mainUI = Instantiate(mainUI);
        messageUI = Instantiate(messageUI);
        loseUI = Instantiate(loseUI);
        winUI = Instantiate(winUI);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        petRewardUI = Instantiate(petRewardUI);
        environmentRewardUI = Instantiate(environmentRewardUI);
        petRewardUI.SetActive(false);
        environmentRewardUI.SetActive(false);
        //TODO init pet and environment canvas

        winUI.GetComponent<WinUI>().SetButtonAction(3, observer.CompleteSceneWithoutCheck);
        Debug.Log(winUI.name);
        winUI.GetComponent<WinUI>().SetButtonAction(2, observer.ReloadScene);
        winUI.GetComponent<WinUI>().SetButtonAction(0, observer.LoadMainMenu);
        loseUI.GetComponent<LoseUI>().SetRetryButton(observer.ReloadScene);
    }

    private void InitAudio()
    {
        sceneAudioSource = Instantiate(sceneAudioSource);
        mainAudioSource = Instantiate(mainAudioSource);
        if(PlayerData.musicPlay)
            mainAudioSource.GetComponent<AudioSource>().Play();
        actionManager.SetAudioSource(sceneAudioSource.GetComponent<AudioSource>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO delete from this
    public void LoadLoseUI()
    {
        loseUI.SetActive(true);
        loseUI.GetComponent<LoseUI>().ActivateTimer();
    }
}
