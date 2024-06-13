using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGamePanel : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;

    private void OnEnable()
    {
        restartGameButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        restartGameButton.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        PlayerData.CurrentLvl = 1;
        PlayerData.LoadNextLevel();
    }
}
