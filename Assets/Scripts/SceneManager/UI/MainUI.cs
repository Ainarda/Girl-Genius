using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    private GameObject LvlObject;
    [SerializeField]
    private Button skipButton;
    [SerializeField]
    private Button hintButton;
    // Start is called before the first frame update
    void Awake()
    {
        skipButton.onClick.AddListener(PlayerData.SkipLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideLvlObject()
    {
        LvlObject.SetActive(false);
    }

    public Button GetSkipButton()
    {
        return skipButton;
    }

    public Button GetHintButton()
    {
        return hintButton;
    }
}
