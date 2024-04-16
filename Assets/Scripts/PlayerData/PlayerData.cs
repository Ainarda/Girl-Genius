using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 500;
    public static int CurrentLvl = 1;
    public static List<Dress> dress;
    public static List<int> unlockId;
    private static int dressProgress = 0;
    private static int currentUnclokNumber = 0;
    public static void LoadNextLevel()
    {
        CurrentLvl++;
        PlayerCoin += 20;
        dressProgress++;
        if (dressProgress == 3)
        {
            dressProgress = 0;
            dress[unlockId[currentUnclokNumber++]].UnlockDress();
        }
        SceneManager.LoadScene("Level_" + CurrentLvl);
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

    public static void SpendCoin(int cost,DoAction action)
    {
        if(CanSpendCoin(cost))
        {
            PlayerCoin -= cost;
            action();
        }
        Debug.Log("Can't spend coin");
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
}
