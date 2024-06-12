using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public static bool[] dress = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false };
    public static List<int> unlockId;
    public static int dressProgress = 0;
    public static TMP_Text CoinUI;
    private static int currentUnclokNumber = 0;
    //TODO add unlocking room interier on 13 and after each 10 lvl, animal after 10 and each 10, rent after 16 and each 10
    public static int lvlInterier = 13, lvlAnimal = 10, lvlRent = 16, lvlGetRent = 22;
    public static bool[] unlockingRoom = new bool[] { true, false, false, false, false, false, false, false, false, false, false };
    public static int[] lvlUnlockedRoom = new int[] {6, 10, 8, 13, 23, 28, 43, 38, 43, 48 };
    public static bool[] renterState = new bool[] { false, false, false, false, false, false, false, false };

    public static List<int> lvlsWithoutHelper = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 20, 23, 24, 25, 27, 28, 32, 39, 41, 48, 50, 54, 56, 57, 58, 60, 63, 70, 73, 77, 87, 98 };//{ 22, 30, 43, 52, 55, 61, 62, 66, 69, 71, 75, 81, 83, 93, 94 };
    public static bool lvlAds = true;
    public static bool lvlHints = false;

    public static bool musicPlay = true;
    public static int currentRenter = 0;

    public static bool openRenterCanvas = false;
    public static bool canSelectRenter = false;

    public static bool[] pet = new bool[] { true, false, false, false, false, false, false, false, false };

    private static PetSlot currentPet;
    public static int currentPetId = -1;

    public static Observer currentObserver;
    private static DressSlot currentDress;
    public static int currentDressId = 12;

    public static bool firstInit = true;
    
    public static bool isFirstRullet = true;

    public static string localText = "ru";//TMP next load local text "ru" "eng"

    

    public static bool mansionScene = true;

    public static int currentRenterSelected = 0;

    //TODO add win UI and load dressUnlocker after complete all dress unlocking stages
    public static void LoadNextLevel()
    {
        currentObserver?.SavePlayerData();
        if (openRenterCanvas)
            SceneManager.LoadScene("Maison");
        else if (CurrentLvl == 7 && mansionScene)
            SceneManager.LoadScene("MaisonAction");
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
        if(CurrentLvl >= lvlRent && currentRenter < 8)
        {
            //TODO may be need add bool type to open this scrin after load next level?
            openRenterCanvas = true;
            canSelectRenter = true;
            currentObserver.OpenRentScreen();
            lvlRent += 10;
        }
        if(CurrentLvl >= lvlGetRent)
        {
            lvlGetRent += 10;
            SceneManager.LoadScene("MaisonRenter1");
        }
        //TODO if lvl complete can't add reward
        CurrentLvl++;
        
        AddCoin(50);
        UpdateCoinCount();
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
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
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
        CoinUI.text = "<sprite index=0> " + PlayerCoin.ToString();
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
        //todo вместо environmentNumber может name;
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

    public static int GetNextUnlockDressId()
    {
        int retId = -1;
        for (int i = 0; i < dress.Length; i++)
        {
            if (!dress[i])
            {
                retId = i;
                break;
            }
        }
        return retId;
    }
}
