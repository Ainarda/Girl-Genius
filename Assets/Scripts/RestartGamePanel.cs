using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGamePanel : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button[] gameButtons;
    [SerializeField] private string[] gameLinks;
    
    private void OnEnable()
    {
        restartGameButton.onClick.AddListener(RestartGame);

        for (int i = 0; i < gameButtons.Length; i++)
        {
            int index = i;
            gameButtons[i].onClick.AddListener(() => OpenGame(index));
        }
    }

    private void OnDisable()
    {
        restartGameButton.onClick.RemoveListener(RestartGame);

        foreach (Button button in gameButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    private void RestartGame()
    {
        PlayerData.CurrentLvl = 1;
        PlayerData.LoadNextLevel();
    }

    private void OpenGame(int buttonIndex)
    {
        Application.OpenURL(gameLinks[buttonIndex]);
    }
}
