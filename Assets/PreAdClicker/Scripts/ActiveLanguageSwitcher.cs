using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveLanguageSwitcher : MonoBehaviour
{
    [SerializeField] private string ru;
    [SerializeField] private string en;
    [SerializeField] private TMP_Text text;

    private string label;

    private void Awake()
    {
        label = PlayerData.localText == "ru" ? ru : en;

        UpdateValue(0);
    }

    public void UpdateValue(int val)
    {
        text.text = $"{label} {val}";
    }    
}
