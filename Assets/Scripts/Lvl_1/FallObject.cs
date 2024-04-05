using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>().AddAction(Action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        GetComponent<Rigidbody2D>().simulated = true;
    }
}
