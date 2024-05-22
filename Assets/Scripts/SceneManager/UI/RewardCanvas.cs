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

    private GameObject observer;
    private void Awake()
    {
        loseReward.onClick.AddListener(CloseWindow);
        getRewardButton.onClick.AddListener(GetReward);
        observer = GameObject.FindGameObjectWithTag("Observer");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    private void GetReward()
    {
        Action action;
        switch (rewardType)
        {
            case RewardType.pet:
                action = () => { PlayerData.pet[GetComponent<GachaCreater>().GetSelectedPetId()] = true; CloseWindow(); };
                break;
            case RewardType.room:
                action = () => { GetComponent<RoomReward>().UnlockEnvironment(); CloseWindow(); };
                break;
            case RewardType.dress:
                action = () => { PlayerData.dress[0] = true; CloseWindow(); };
                    break;
            default:
                action = () => Debug.Log("Nothing!");
                break;
        }
        observer.GetComponent<YdLoader>().LoadAdsWithReward(action);
    }
}

public enum RewardType
{
    pet,
    room,
    dress
}
