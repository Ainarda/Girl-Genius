using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorPoint : MonoBehaviour
{
    [SerializeField]
    private MinigameObserver miniObs;

    private bool connectorState;

    private bool connetced = false;

    // Start is called before the first frame update
    void Start()
    {
        miniObs.AddElement(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectLine(bool state)
    {
        connetced = true;
        connectorState = state;
        miniObs.RemoveElement(gameObject, connectorState);
    }

    public bool LineIsConnected()
    {
        return connetced;
    }
}
