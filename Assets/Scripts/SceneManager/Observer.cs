using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{

    List<CheckComplete> checkList;
    DoAction action;
    public void AddCheck(CheckComplete check)
    {
        if(checkList == null)
            checkList = new List<CheckComplete>();
        checkList.Add(check);
    }

    public void AddAction(DoAction inuputAction)
    {
        action = inuputAction;
    }

    public void ActivateAction()
    {
        action();
    }

    public void CompleteScene()
    {
        foreach(CheckComplete check in checkList)
        {
            if (!check())
                Debug.Log("Reload");

        }
        PlayerData.LoadNextLevel();
    }
}

//TODO tmp
public delegate bool CheckComplete();
public delegate void DoAction();