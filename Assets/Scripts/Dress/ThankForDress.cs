using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankForDress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CloseWindow", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
