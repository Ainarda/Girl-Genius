using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 0;
    public static int CurrentLvl = 1;
    public static bool[] dress = new bool[] { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public static List<int> unlockId;
    public static int dressProgress = 0;
    public static Text CoinUI;
    private static int currentUnclokNumber = 0;
    public static bool[] unlockingRoom = new bool[] { false, false, false, false, false, false, false };
    public static int[] lvlUnlockedRoom = new int[] { 10, 11, 12, 16, 24,36, 52 };

    private static DressSlot currentDress;
    public static int currentDressId = 2;
    public static void LoadNextLevel()
    {
        
        SceneManager.LoadScene("Level_" + CurrentLvl);
    }

    public static void AddReward()
    {
        for (int i = 0; i < lvlUnlockedRoom.Length; i++)
        {
            if (lvlUnlockedRoom[i] == CurrentLvl)
            {
                Debug.LogWarning("Room " + i + "unlocked");
                unlockingRoom[i] = true;
                //Unlock manison room
            }
        }
        //TODO if lvl complete can't add reward
        CurrentLvl++;
        Debug.Log(CurrentLvl);
        PlayerCoin += 50;
        CoinUI.text = PlayerCoin.ToString();
        dressProgress++;
        if (dressProgress == 4)
        {
            Debug.LogWarning("Dress can be added");
            int i;
            for(i =0; i < dress.Length; i++)
            {
                if (!dress[i])
                    break;
            }
            UnlockCustom(i);
            //In observerOpenOnWinUI dresUnlockingScreen;
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
        dress[id] = true;
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

    public static List<bool[]> environmentIntoRooms = new List<bool[]>() { new bool[] { false, false,false, false }, 
        new bool[] { false }, 
        new bool[] { false }, 
        new bool[] { false }, 
        new bool[] { false }, 
        new bool[] { false }, 
        new bool[] { false } };
    public static void OpenEnvironmentIntoRooms(int roomNumber, int environmentNumber)
    {
        //todo גלוסעמ environmentNumber למזוע name;
        environmentIntoRooms[roomNumber][environmentNumber] = true;
    }

    public static void SetCurrentDress(DressSlot slot)
    {
        if(currentDress != null)
            currentDress.DeselectCurrentDress();
        currentDress = slot;
        currentDress.SelectCurrentDress();
        currentDressId = currentDress.GetDressId();
    }

    public static bool DressIsUnlocked(int dressId)
    {
        return dress[dressId];
    }
}
