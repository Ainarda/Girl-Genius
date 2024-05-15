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

    private void Awake()
    {
        loseReward.onClick.AddListener(CloseWindow);
        getRewardButton.onClick.AddListener(GetReward);
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
        switch (rewardType)
        {
            case RewardType.pet:
                PlayerData.pet[GetComponent<GachaCreater>().GetSelectedPetId()] = true;
                break;
            case RewardType.room:
                GetComponent<RoomReward>().UnlockEnvironment();
                break;
            case RewardType.dress:
                PlayerData.dress[0] = true;
                break;
            default:
                Debug.Log("Nothing!");
                break;
        }
    }
}

public enum RewardType
{
    pet,
    room,
    dress
}
