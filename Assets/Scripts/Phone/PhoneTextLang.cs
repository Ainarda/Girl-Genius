using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTextLang : MonoBehaviour
{
    [SerializeField]
    private PhoneText text;
    [SerializeField]
    private Text textField;
    private void Awake()
    {
        if (PlayerData.localText == "ru")
            textField.text = text.ruText;
        else
            textField.text = text.enText;
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
