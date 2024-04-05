using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerCoin = 0;
    public static int CurrentLvl = 1;
    public static void LoadNextLevel()
    {
        SceneManager.LoadScene("Level_" + CurrentLvl++);
    }
}
