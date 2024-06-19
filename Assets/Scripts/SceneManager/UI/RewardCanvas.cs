using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardCanvas : MonoBehaviour
{
    [SerializeField]
    private RewardType rewardType;
    [SerializeField]
    private Button getRewardButton;
    [SerializeField]
    private Button loseReward;
    [SerializeField]
    private GameObject congratWindow;
    [SerializeField]
    private Button continueButton;

    private GameObject observer;
    private void Awake()
    {
        loseReward.onClick.AddListener(CloseWindow);
        getRewardButton.onClick.AddListener(GetReward);
        continueButton.onClick.AddListener(Continue);
        observer = GameObject.FindGameObjectWithTag("Observer");
    }
    // Start is called before the first frame update
    void Start()
    {
        observer.GetComponent<Observer>().CloseMainUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLoseButton()
    {
        loseReward.gameObject.SetActive(true);
    }

    private void CloseWindow()
    {
        observer.GetComponent<Observer>().OpenMainUI();
        this.gameObject.SetActive(false);
    }

    private void GetReward()
    {
        Action action;
        switch (rewardType)
        {
            case RewardType.pet:
                action = () => { PlayerData.pet[GetComponent<GachaCreater>().GetSelectedPetId()] = true; OpenCongratWindow(); };
                break;
            case RewardType.room:
                action = () => { GetComponent<RoomReward>().UnlockEnvironment(); OpenCongratWindow(); };
                break;
            case RewardType.dress:
                action = () => { PlayerData.dress[0] = true; OpenCongratWindow(); };
                    break;
            default:
                action = () => Debug.Log("Nothing!");
                break;
        }
        observer.GetComponent<YdLoader>().LoadAdsWithReward(action);
        //observer.GetComponent<Observer>().OpenMainUI();
    }

    public void OpenCongratWindow()
    {
        loseReward.gameObject.SetActive(false);
        getRewardButton.gameObject.SetActive(false);
        congratWindow.SetActive(true);
    }

    private void Continue()
    {
        PlayerData.LoadNextLevel();
    }

}

public enum RewardType
{
    pet,
    room,
    dress
}
