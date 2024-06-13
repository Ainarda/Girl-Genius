using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaiterText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTime(int time)
    {
        if (PlayerData.localText == "ru")
            timerText.text = "∆‰Ë: "+time;
        else
            timerText.text = "Wait: "+time;
    }
}
