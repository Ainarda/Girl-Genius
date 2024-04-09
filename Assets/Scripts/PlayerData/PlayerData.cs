using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 0;
    public static int CurrentLvl = 51;
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
}
