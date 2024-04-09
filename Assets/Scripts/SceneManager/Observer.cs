using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    List<CheckComplete> checkList;
    List<GameObject> unCompletedElement;
    DoAction action;
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
    }


    public void RemoveElement(GameObject element)
    {
        unCompletedElement.Remove(element);
        if(unCompletedElement.Count == 0)
            CompleteSceneWithoutCheck();
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
        foreach (CheckComplete check in checkList)
        {
            if (!check())
                Debug.Log("Reload");

        }
        PlayerData.LoadNextLevel();
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