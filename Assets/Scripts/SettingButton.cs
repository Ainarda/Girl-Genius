using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject settingScreen;
    [SerializeField]
    private Sprite offSprite, onSprite;
    [SerializeField]
    private Image musicButtonImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OffMusic()
    {
        PlayerData.musicPlay = !PlayerData.musicPlay;
        if(PlayerData.musicPlay)
            musicButtonImage.sprite = onSprite;
        else
            musicButtonImage.sprite = offSprite;

    }

    public void OpenSettingScreen()
    {
        settingScreen.SetActive(!settingScreen.active);
    }

    public void OfSettingScreen()
    {
        settingScreen.SetActive(false);
    }
}
