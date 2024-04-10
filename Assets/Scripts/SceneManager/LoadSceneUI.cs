using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour
{
    Text coinText;
    Text lvlText;
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private GameObject loseUI;
    private void Awake()
    {
        mainUI = Instantiate(mainUI);
        loseUI = Instantiate(loseUI);
        loseUI.SetActive(false);
        lvlText = GameObject.FindGameObjectWithTag("LevelUI").GetComponent<Text>();
        coinText = GameObject.FindGameObjectWithTag("CoinUI").GetComponent<Text>();
        string[] sceneNameText = SceneManager.GetActiveScene().name.Split('_', System.StringSplitOptions.RemoveEmptyEntries);
        lvlText.text = sceneNameText[0] + " " + sceneNameText[1];
        coinText.text = "Coin: " + PlayerData.PlayerCoin;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLoseUI()
    {
        loseUI.SetActive(true);
    }
}
