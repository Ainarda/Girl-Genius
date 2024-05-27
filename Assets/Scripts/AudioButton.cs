using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private AudioMixer audioMixer;

    private const float DisabledVolume = -80;
    private const float EnabledVolume = 0;
    
    private static bool AudioState
    {
        get => PlayerPrefs.GetInt("AudioState", 1) == 1;
        set => PlayerPrefs.SetInt("AudioState", value ? 1 : 0);
    }
    
    private void OnEnable()
    {
        ChangeGraphics(AudioState);
        ChangeSound(AudioState);
        
        button.onClick.AddListener(Switch);
    } 
    
    private void OnDisable()
    {
        button.onClick.AddListener(Switch);
    }
    
    private void Switch()
    {
        AudioState = !AudioState;
        ChangeGraphics(AudioState);
        ChangeSound(AudioState);
    }

    private void ChangeGraphics(bool state)
    {
        image.sprite = state ? enabledSprite : disabledSprite;
    }

    private void ChangeSound(bool state)
    {
        audioMixer.SetFloat("Volume", state ? EnabledVolume : DisabledVolume);
    }
}
