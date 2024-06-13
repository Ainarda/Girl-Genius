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
        AudioListener.pause = PlayerData.musicPlay;
        audioMixer.SetFloat("Volume", PlayerData.musicPlay ? EnabledVolume : DisabledVolume);
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
