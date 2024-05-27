using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static bool firstLoad = true;
    public static string PlayerName;
    public static int PlayerCoin = 0;
    public static int CurrentLvl = 1;
    public static bool[] dress = new bool[] { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public static List<int> unlockId;
    public static int dressProgress = 0;
    public static Text CoinUI;
    private static int currentUnclokNumber = 0;
    //TODO add unlocking room interier on 13 and after each 10 lvl, animal after 10 and each 10, rent after 16 and each 10
    public static int lvlInterier = 13, lvlAnimal = 10, lvlRent = 16;
    public static bool[] unlockingRoom = new bool[] { false, false, false, false, false, false, false, false, false, false, false };
    public static int[] lvlUnlockedRoom = new int[] {6, 10, 8, 13, 23, 28, 43, 38, 43, 48 };
    public static bool[] renterState = new bool[] { false, false, false, false, false, false, false, false };

    public static List<int> lvlsWithoutHelper = new List<int>() { 22, 30, 43, 52, 55, 61, 62, 66, 69, 71, 75, 81, 83, 93, 94 };
    public static bool lvlAds = true;
    public static bool lvlHints = false;

    public static bool musicPlay = true;
    public static int currentRenter = 0;
    public static bool openRenterCanvas = false;

    public static bool[] pet = new bool[] { true, false, false, false, false, false, false, false, false };

    private static PetSlot currentPet;
    public static int currentPetId = -1;

    public static Observer currentObserver;
    private static DressSlot currentDress;
    public static int currentDressId = 2;

    public static bool firstInit;
    
    public static bool isFirstRullet = true;

    public static string localText = "ru";//TMP next load local text "ru" "eng"

    //TODO add win UI and load dressUnlocker after complete all dress unlocking stages
    public static void LoadNextLevel()
    {
        if(openRenterCanvas)
            SceneManager.LoadScene("Maison");
        else
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
        //TODO go deeper, if dress unlocked, do not show this
        if(CurrentLvl >= lvlAnimal)
        {
            lvlAnimal += 10;
            currentObserver.OpenAnimalRewardScreen();
            
        }
        if(CurrentLvl >= lvlInterier)
        {
            lvlInterier += 10;
            currentObserver.OpenEnvironmentRewardScreen();
        }
        if(CurrentLvl >= lvlRent)
        {
            //TODO may be need add bool type to open this scrin after load next level?
            openRenterCanvas = true;
            currentObserver.OpenRentScreen();
            lvlRent += 10;
        }
        //TODO if lvl complete can't add reward
        CurrentLvl++;
        
        AddCoin(50);
        CoinUI.text = PlayerCoin.ToString();
        dressProgress++;
        if (dressProgress == 4)
        {
            //currentObserver.OpenEnvironmentRewardScreen();
            //currentObserver.win
            //In observerOpenOnWinUI dresUnlockingScreen;
            //dressProgress = 0;
            //dress[unlockId[currentUnclokNumber++]].UnlockDress();
        }
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene("Level_" + CurrentLvl);
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

    public static void AddCoin(int addedCoin)
    {
        PlayerCoin += addedCoin;
    }

    public static bool RoomIsOpen(int roomNumber)
    {
        return unlockingRoom[roomNumber - 1];
    }

    public static void UpdateCoinCount()
    {
        CoinUI.text = PlayerCoin.ToString();
    }

    public static List<bool[]> environmentIntoRooms = new List<bool[]>() { new bool[] { false, false,false, false, false,false,false,false,false,false,false,false,false },
        new bool[] { false, false, false, false, false },
        new bool[] { false, false, false, false, false, false, false },
        new bool[] { false, false, false, false, false },
        new bool[] { false, false, false, false, false, false},
        new bool[] { false, false, false },
        new bool[] { false, false, false },
        new bool[] { },
        new bool[] { },
        new bool[] { },
        new bool[] { false, false } };
    public static void OpenEnvironmentIntoRooms(int roomNumber, int environmentNumber)
    {
        //todo גלוסעמ environmentNumber למזוע name;
        environmentIntoRooms[roomNumber][environmentNumber] = true;
    }

    #region Dress
    public static void UnlockCustom()
    {
        Debug.LogWarning("Dress can be added");
        int i;
        for (i = 0; i < dress.Length; i++)
        {
            if (!dress[i])
                break;
        }
        dress[i] = true;
    }

    public static void UnlockCustom(int id)
    {
        dress[id] = true;
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
    #endregion

    #region Pet
    public static void SetCurrentPet(PetSlot slot)
    {
        if(currentPet != null)
            currentPet.DeselectCurrentPet();
        currentPet = slot;
        currentPet.SelectCurrentPet();
        currentPetId = currentPet.GetPetId();
    }

    public static bool PetIsUnlocked(int petId)
    {
        return pet[petId];
    }
    #endregion   

    public static void UnlockAllRoom()
    {
        for(int i = 0; i < unlockingRoom.Length; i++ )
        {
            unlockingRoom[i] = true;
        }
    }
}
