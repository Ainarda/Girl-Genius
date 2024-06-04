using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private string ru;
    [SerializeField] private string en;
    [SerializeField] private TMP_Text text;

    private string label;

    private void Awake()
    {
        label = PlayerData.localText == "ru" ? ru : en;

        text.text = label;
    }
}
