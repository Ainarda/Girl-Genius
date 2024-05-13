using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    List<CheckComplete> checkList;
    public List<GameObject> unCompletedElement;
    public List<GameObject> unCompletedFailElements;
    int elementMaxCount, failElemenetMaxCount;
    private DoAction action;
    private GameObject winScreen;
    private GameObject loseScreen;
    private GameObject mainScreen;

    private bool IsLevelComplete = false;
    public void AddScreens(GameObject addedWinScreen, GameObject addedLoseScreen, GameObject addedMainScreen)
    {
        winScreen = addedWinScreen;
        loseScreen = addedLoseScreen;
        mainScreen = addedMainScreen;
    }

    public void AddCheck(CheckComplete check)
    {
        if (checkList == null)
            checkList = new List<CheckComplete>();
        checkList.Add(check);
    }

    public void AddElement(GameObject element)
    {
        if(unCompletedElement == null)
            unCompletedElement = new List<GameObject>();
        unCompletedElement.Add(element);
        elementMaxCount = unCompletedElement.Count;
    }

    public void AddFailElement(GameObject element)
    {
        if(unCompletedFailElements == null)
            unCompletedFailElements = new List<GameObject>();
        unCompletedFailElements.Add(element);
        failElemenetMaxCount = unCompletedFailElements.Count;
    }

    public void RemoveElement(GameObject element)
    {
        unCompletedElement.Remove(element);
        if(unCompletedElement.Count == 0)
            GetComponent<ActionVariant>().NextAction();//OpenWinScreen();// CompleteSceneWithoutCheck();
    }

    public void RemoveFailElementWithEraser(GameObject element)
    {
        unCompletedFailElements.Remove(element);
        if( unCompletedFailElements.Count < failElemenetMaxCount/8)
            OpenLoseScreen();
    }

    public void RemoveElementWithEraser(GameObject element)
    {
        unCompletedElement.Remove(element);
        if (unCompletedElement.Count <= elementMaxCount / 8 && !IsLevelComplete)
        {
            IsLevelComplete = true;
            GetComponent<ActionVariant>().NextAction();//OpenWinScreen();
        }
            //CompleteSceneWithoutCheck();
    }

    public void AddAction(DoAction inuputAction)
    {
        action = inuputAction;
    }

    public void ActivateAction()
    {
        if(action != null)
            action();
        else
            CompleteScene();
    }

    public void CompleteScene()
    {
        bool isComplete = true;
        if (checkList != null)
        {
            foreach (CheckComplete check in checkList)
            {
                if (!check())
                {
                    isComplete = false;
                    break;
                }

            }
        }
        if (isComplete)
            GetComponent<ActionVariant>().NextAction();//OpenWinScreen();
        //PlayerData.LoadNextLevel();
        else
            OpenLoseScreen();
            //ReloadScene();
    }

    public void OpenWinScreen()
    {
        PlayerData.AddReward();
        winScreen.GetComponent<WinUI>().SetDressScale();
        winScreen.SetActive(true);
        mainScreen.GetComponent<MainUI>().HideLvlObject();
    }

    public void OpenLoseScreen()
    {
        loseScreen.SetActive(true);
        loseScreen.GetComponent<LoseUI>().ActivateTimer();
        mainScreen.GetComponent<MainUI>().HideLvlObject();
    }

    public void CompleteSceneWithoutCheck()
    {
        SavePlayerData();
        PlayerData.LoadNextLevel();
    }

    public void ReloadScene()
    {
        PlayerData.ReloadScene();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Maison");
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("PlayerCoin", PlayerData.PlayerCoin);
        PlayerPrefs.SetInt("CurrentLvl", PlayerData.CurrentLvl);
        PlayerPrefs.SetInt("dressProgress", PlayerData.dressProgress);
        PlayerPrefs.SetInt("currentPetId", PlayerData.currentPetId);
        PlayerPrefs.SetInt("currentDressId", PlayerData.currentDressId);
        SaveFloatArray("dress", PlayerData.dress);
        SaveFloatArray("unlockingRoom", PlayerData.unlockingRoom);
        SaveFloatArray("pet", PlayerData.pet);
    }

    private void SaveFloatArray(string name, bool[] array)
    {
        string savingLine = "";
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i])
                savingLine += 1;
            else
                savingLine += 0;
        }
        PlayerPrefs.SetString(name, savingLine);
    }

    private bool[] LoadFloatArray(string name)
    {
        string strArray = PlayerPrefs.GetString(name);
        bool[] retArray = new bool[strArray.Length];
        for(int i = 0; i < strArray.Length; i++)
        {
            if ((int)strArray[i] == 1)
                retArray[i] = true;
            else
                retArray[i] = false;
        }
        return retArray;
    }

    public void LoadData()
    {
        PlayerData.PlayerCoin = PlayerPrefs.GetInt("PlayerCoin");
        PlayerData.CurrentLvl = PlayerPrefs.GetInt("CurrentLvl");
        PlayerData.dressProgress = PlayerPrefs.GetInt("dressProgress");
        PlayerData.currentPetId = PlayerPrefs.GetInt("currentPetId");
        PlayerData.currentDressId = PlayerPrefs.GetInt("currentDressId");
        PlayerData.dress = LoadFloatArray("dress");
        PlayerData.unlockingRoom = LoadFloatArray("unlockingRoom");
        PlayerData.pet = LoadFloatArray("pet");
    }

    public void ResetData()
    {
        PlayerData.PlayerCoin = 0;
        PlayerData.CurrentLvl = 1;
        PlayerData.dressProgress = 0;
        PlayerData.currentPetId = 0;
        PlayerData.currentDressId = 0;
        PlayerData.dress = new bool[PlayerData.dress.Length];
        PlayerData.unlockingRoom = new bool[PlayerData.unlockingRoom.Length];
        PlayerData.pet = new bool[PlayerData.pet.Length];

    }

    public void SkipLevel()
    {
        PlayerData.CurrentLvl++;
        SavePlayerData();
        PlayerData.LoadNextLevel();
    }

}

//TODO tmp
public delegate bool CheckComplete();
public delegate void DoAction();
public delegate void DoActionWithId(int id);
