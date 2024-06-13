using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomReward : MonoBehaviour
{
    [SerializeField]
    private Image roomImage;
    [SerializeField]
    private Text cost;

    private int roomId;
    private int environmentId;
    // Start is called before the first frame update
    void Awake()
    {
        FindRoomEnvironment();
        Debug.LogError(roomId+" " + environmentId);
        roomImage.sprite = RoomStorage.roomData[roomId].environmentSprites[environmentId];
        cost.text = RoomStorage.roomData[roomId].cost[environmentId].ToString();
    }

    private void Start()
    {
        Invoke("ShowLoseButton", 2f);
    }

    private void ShowLoseButton()
    {
        GetComponent<RewardCanvas>().ShowLoseButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockEnvironment()
    {
        PlayerData.environmentIntoRooms[roomId][environmentId] = true;
    }

    private void FindRoomEnvironment()
    {
        List<int> unlockedRoom = new List<int>();
        for(int i = 0; i < PlayerData.unlockingRoom.Length;i++)
        {
            if (PlayerData.unlockingRoom[i])
                unlockedRoom.Add(i);
        }
        for(int i = 0; i < unlockedRoom.Count;i++)
        {
            for (int j = 0; j < PlayerData.environmentIntoRooms[i].Length; j++)
            {
                if (!PlayerData.environmentIntoRooms[i][j])
                {
                    roomId = i;
                    environmentId = j;
                }
            }
        }
    }
}
