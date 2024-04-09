using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour
{
    Text lvlText;
    [SerializeField]
    private GameObject mainUI;
    private void Awake()
    {
        mainUI = Instantiate(mainUI);
        lvlText = GameObject.FindGameObjectWithTag("LevelUI").GetComponent<Text>();
        string[] sceneNameText = SceneManager.GetActiveScene().name.Split('_', System.StringSplitOptions.RemoveEmptyEntries);
        lvlText.text = sceneNameText[0] + " " + sceneNameText[1];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
