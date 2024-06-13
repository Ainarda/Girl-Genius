using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundChecker : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    private const float DisabledVolume = -80;
    private const float EnabledVolume = 0;
    void OnApplicationFocus(bool hasFocus)
    {
        Silence(hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        bool state = PlayerPrefs.GetInt("AudioState", 1) == 1;
        AudioListener.pause = state;


        if (state)
        {
            AudioListener.pause = silence;
            audioMixer.SetFloat("Volume", silence ? EnabledVolume : DisabledVolume);
        }
        else
            audioMixer.SetFloat("Volume", DisabledVolume);

        // Or / And
        //AudioListener.volume = silence ? 0 : 1;
    }
}
