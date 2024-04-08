using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionNode : MonoBehaviour
{
    ConnectionPoint pointer;

    private bool CanInteract = true;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Connector").GetComponent<ConnectionPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(CanInteract)
        {
            pointer.NextPoint(transform.position);
            CanInteract = false;
        }
        
    }
}
