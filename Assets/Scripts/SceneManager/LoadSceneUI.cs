using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour
{
    Text coinText;
    Text lvlText;
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private GameObject loseUI;
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject eventSystem;
    [SerializeField]
    private GameObject sceneAudioSource;
    [SerializeField]
    private GameObject mainAudioSource;
    [SerializeField]
    private GameObject actionManager;

    private Observer observer;
    private void Awake()
    {
        if (!GameObject.Find("EventSystem"))
            eventSystem = Instantiate(eventSystem);
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        actionManager = GameObject.FindGameObjectWithTag("ActionManager");
        InitUI();
        InitAudio();

        observer.AddScreens(winUI, loseUI, mainUI);
        lvlText = GameObject.FindGameObjectWithTag("LevelUI").GetComponent<Text>();
        coinText = GameObject.FindGameObjectWithTag("CoinUI").GetComponent<Text>();
        PlayerData.CoinUI = coinText;
        string[] sceneNameText = SceneManager.GetActiveScene().name.Split('_', System.StringSplitOptions.RemoveEmptyEntries);
        lvlText.text = sceneNameText[0] + " " + sceneNameText[1];
        coinText.text = PlayerData.PlayerCoin.ToString();
    }

    private void InitUI()
    {
        mainUI = Instantiate(mainUI);
        loseUI = Instantiate(loseUI);
        winUI = Instantiate(winUI);
        loseUI.SetActive(false);
        winUI.SetActive(false);

        winUI.GetComponent<WinUI>().SetButtonAction(3, observer.CompleteSceneWithoutCheck);
        winUI.GetComponent<WinUI>().SetButtonAction(2, observer.ReloadScene);
        winUI.GetComponent<WinUI>().SetButtonAction(0, observer.LoadMainMenu);
        loseUI.GetComponent<LoseUI>().SetRetryButton(observer.ReloadScene);
    }

    private void InitAudio()
    {
        sceneAudioSource = Instantiate(sceneAudioSource);
        mainAudioSource = Instantiate(mainAudioSource);
        mainAudioSource.GetComponent<AudioSource>().Play();
        actionManager.GetComponent<ActionVariant>().SetAudioSource(sceneAudioSource.GetComponent<AudioSource>());
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
