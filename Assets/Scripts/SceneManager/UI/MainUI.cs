using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    private GameObject LvlObject;
    [SerializeField]
    private Button skipButton;
    [SerializeField]
    private Button hintButton;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button retryButton;

    private GameObject observer;
    // Start is called before the first frame update
    void Awake()
    {
        homeButton.onClick.AddListener(GoHome);
        observer = GameObject.FindGameObjectWithTag("Observer");
        retryButton.onClick.AddListener(observer.GetComponent<Observer>().ReloadScene);
        skipButton.onClick.AddListener(delegate { observer.GetComponent<YdLoader>().LoadAdsWithReward(observer.GetComponent<Observer>().SkipLevel); });
        hintButton.onClick.AddListener(delegate { observer.GetComponent<YdLoader>().LoadAdsWithReward(AddHint); });
        if(!PlayerData.lvlsWithoutHelper.Contains(PlayerData.CurrentLvl))
            hintButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideLvlObject()
    {
        LvlObject.SetActive(false);
    }

    public Button GetSkipButton()
    {
        return skipButton;
    }

    public Button GetHintButton()
    {
        return hintButton;
    }
    public void GoHome()
    {
        observer.GetComponent<Observer>().LoadMainMenu();
    }

    public void ActivateHint()
    {
        observer.GetComponent<YdLoader>().LoadAdsWithReward(AddHint);
    }

    public void AddHint()
    {
        PlayerData.lvlHints = true;
        observer.GetComponent<Observer>().ReloadScene();
    }
}
