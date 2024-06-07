using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChecker : MonoBehaviour
{
    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        if (PlayerPrefs.GetInt("AudioState", 1) == 0)
            AudioListener.pause = false;
        else
            AudioListener.pause = silence;
        // Or / And
        //AudioListener.volume = silence ? 0 : 1;
    }
}
