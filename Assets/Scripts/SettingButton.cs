using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject settingScreen;
    [SerializeField]
    private Sprite offSprite, onSprite;
    [SerializeField]
    private Image musicButtonImage;
    [SerializeField] 
    private AudioMixer audioMixer;

    private const float DisabledVolume = -80;
    private const float EnabledVolume = 0;
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
        
        bool state = PlayerPrefs.GetInt("AudioState", 1) == 1;
        state = !state;
        PlayerPrefs.SetInt("AudioState", state == true ? 1 : 0);
        if (state)
        {
            musicButtonImage.sprite = onSprite;
        }
        else
        {
            musicButtonImage.sprite = offSprite;
        }
        audioMixer.SetFloat("Volume", state ? EnabledVolume : DisabledVolume);
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
