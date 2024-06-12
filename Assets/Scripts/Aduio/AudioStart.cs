using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStart : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("AudioState", 1) == 0)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
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
