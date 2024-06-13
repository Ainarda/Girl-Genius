using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioStart : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    private const float DisabledVolume = -80;
    private const float EnabledVolume = 0;
    private void Awake()
    {
        bool state = PlayerPrefs.GetInt("AudioState", 1) == 1;
        AudioListener.pause = state;
        audioMixer.SetFloat("Volume", state ? EnabledVolume : DisabledVolume);
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
