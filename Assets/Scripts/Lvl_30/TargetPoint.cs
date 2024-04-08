using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    Observer observer;
    bool complete = false;
    bool canActivate = false;

    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        observer.AddCheck(IsComplete);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanActivate()
    {
        canActivate  = true;
    }

    private void OnMouseEnter()
    {
        if(canActivate)
            complete = true;
    }

    private bool IsComplete()
    {
        return complete;
    }
}
