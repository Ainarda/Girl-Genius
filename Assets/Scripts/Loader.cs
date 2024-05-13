using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observer observer = GetComponent<Observer>();
        try
        {
            observer.LoadData();
        }
        catch {

        }
        SceneManager.LoadScene("Maison");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
