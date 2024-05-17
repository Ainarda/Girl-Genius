using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string GetLang();
#endif

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerData.localText = GetLang();
#endif
        Observer observer = GetComponent<Observer>();
        try
        {
            observer.LoadData();
        }
        catch {

        }
        GetComponent<YdLoader>().YdInit();
    }

    public void ContinueLoad()
    {
        SceneManager.LoadScene("Maison");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
