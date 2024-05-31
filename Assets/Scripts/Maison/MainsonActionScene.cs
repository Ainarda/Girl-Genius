using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainsonActionScene : MonoBehaviour
{
    [SerializeField]
    private bool loadNextLevel = true;
    private void Awake()
    {
        PlayerData.mansionScene = false;
        if (loadNextLevel)
            PlayerData.LoadNextLevel();
        else
            SceneManager.LoadScene("Maison");
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
