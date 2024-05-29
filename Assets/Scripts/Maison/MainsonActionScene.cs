using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainsonActionScene : MonoBehaviour
{
    private void Awake()
    {
        PlayerData.mansionScene = false;
        PlayerData.LoadNextLevel();
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
