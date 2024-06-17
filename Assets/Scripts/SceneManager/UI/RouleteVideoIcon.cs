using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouleteVideoIcon : MonoBehaviour
{
    [SerializeField]
    private GameObject videoIcon;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerData.isFirstRullet)
            videoIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
