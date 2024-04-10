using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 0;
    public static int CurrentLvl = 55;
    public static List<Dress> dress;
    private static List<int> unlockId;
    public static void LoadNextLevel()
    {
        CurrentLvl++;
        PlayerCoin += 20;
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
