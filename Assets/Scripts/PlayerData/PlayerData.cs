using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 350;
    public static int CurrentLvl = 1;
    public static List<Dress> dress;
    public static List<int> unlockId;
    public static int dressProgress = 0;
    public static Text CoinUI;
    private static int currentUnclokNumber = 0;
    private static bool[] unlockingRoom = new bool[] { true, false, false, false, false };

    public static void LoadNextLevel()
    {
        
        SceneManager.LoadScene("Level_" + CurrentLvl);
    }

    public static void AddReward()
    {
        CurrentLvl++;
        Debug.Log(CurrentLvl);
        PlayerCoin += 50;
        CoinUI.text = PlayerCoin.ToString();
        dressProgress++;
        if (dressProgress == 4)
        {
            dressProgress = 0;
            //dress[unlockId[currentUnclokNumber++]].UnlockDress();
        }
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene("Level_" + CurrentLvl);
    }

    //TMP
    public static void UnlockCustom(int id)
    {
        dress[id].UnlockDress();
    }

    public static void SpendCoin(int cost, int roomId,int enviId, DoAction action)
    {
        if(CanSpendCoin(cost))
        {
            PlayerCoin -= cost;
            OpenEnvironmentIntoRooms(roomId, enviId);
            action();
            UpdateCoinCount();
        }
        else
        {
            Debug.Log("Can't spend coin");
        }
    }

    public static bool CanSpendCoin(int cost)
    {
        bool retValue = false;
        if (PlayerCoin - cost >= 0)
        {
            retValue = true;
        }
        return retValue;
    }

    public static bool RoomIsOpen(int roomNumber)
    {
        return unlockingRoom[roomNumber - 1];
    }

    public static void UpdateCoinCount()
    {
        CoinUI.text = PlayerCoin.ToString();
    }

    public static List<bool[]> environmentIntoRooms = new List<bool[]>() { new bool[] { true, false,false }, new bool[] { false }, new bool[] { false } };
    public static void OpenEnvironmentIntoRooms(int roomNumber, int environmentNumber)
    {
        //todo גלוסעמ environmentNumber למזוע name;
        environmentIntoRooms[roomNumber][environmentNumber] = true;
    }
}
