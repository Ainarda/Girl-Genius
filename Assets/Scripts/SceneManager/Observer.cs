using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    List<CheckComplete> checkList;
    public List<GameObject> unCompletedElement;
    int elementMaxCount;
    DoAction action;
    GameObject winScreen;
    GameObject loseScren;

    public void AddScreens(GameObject addedWinScreen, GameObject addedLoseScreen)
    {
        winScreen = addedWinScreen;
        loseScren = addedLoseScreen;
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


    public void RemoveElement(GameObject element)
    {
        unCompletedElement.Remove(element);
        if(unCompletedElement.Count == 0)
            OpenWinScreen();// CompleteSceneWithoutCheck();
    }

    public void RemoveElementWithEraser(GameObject element)
    {
        unCompletedElement.Remove(element);
        if (unCompletedElement.Count < elementMaxCount / 8)
            OpenWinScreen();//CompleteSceneWithoutCheck();
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
        foreach (CheckComplete check in checkList)
        {
            if (!check())
            {
                isComplete = false;
                break;
            }

        }
        if (isComplete)
            OpenWinScreen();
        //PlayerData.LoadNextLevel();
        else
            OpenLoseScreen();
            //ReloadScene();
    }

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void OpenLoseScreen()
    {
        loseScren.SetActive(true);
    }

    public void CompleteSceneWithoutCheck()
    {
        PlayerData.LoadNextLevel();
    }

    public void ReloadScene()
    {
        PlayerData.ReloadScene();
    }
}

//TODO tmp
public delegate bool CheckComplete();
public delegate void DoAction();
public delegate void DoActionWithId(int id);
