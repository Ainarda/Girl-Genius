using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionNode : MonoBehaviour
{
    ConnectionPoint pointer;

    private Observer observer;
    private bool CanInteract = true;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        observer.AddElement(this.gameObject);
        pointer = GameObject.FindGameObjectWithTag("Connector").GetComponent<ConnectionPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(CanInteract && pointer.canDrag)
        {
            observer.RemoveElement(this.gameObject);
            pointer.NextPoint(transform.position);
            CanInteract = false;
        }
        
    }
}
