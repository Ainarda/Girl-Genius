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
            OpenWinScreen();// CompleteSceneWithoutCheck();
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
        mainScreen.GetComponent<MainUI>().HideLvlObject();
    }

    public void OpenLoseScreen()
    {
        loseScreen.SetActive(true);
        mainScreen.GetComponent<MainUI>().HideLvlObject();
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
