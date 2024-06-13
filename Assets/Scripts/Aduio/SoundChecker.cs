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
        PlayerData.musicPlay = silence;
        if (silence)
        {
            AudioListener.pause = false;
            audioMixer.SetFloat("Volume", silence ? EnabledVolume : DisabledVolume);
        }
        else
        {
            AudioListener.pause = true;
            audioMixer.SetFloat("Volume", DisabledVolume);
        }

        // Or / And
        //AudioListener.volume = silence ? 0 : 1;
    }
}
