using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainsonActionScene : MonoBehaviour
{
    [SerializeField]
    private bool loadNextLevel = true;
    [SerializeField]
    private Button nextScene;
    [SerializeField]
    private Button completeMinigame;
    [SerializeField]
    private TMP_Text coinText;

    private GameObject observer;
    private void Awake()
    {
        PlayerData.CoinUI = coinText;
        PlayerData.UpdateCoinCount();
        observer = GameObject.FindGameObjectWithTag("Observer");
        nextScene.onClick.AddListener(NextLevel);
        completeMinigame.onClick.AddListener(CompleteMinigame);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextLevel()
    {
        PlayerData.mansionScene = false;
        if (loadNextLevel)
            PlayerData.LoadNextLevel();
        else
            SceneManager.LoadScene("Maison");
    }
    private void CompleteMinigame()
    {
        observer.GetComponent<ActionVariant>().NextAction();
    }
}
