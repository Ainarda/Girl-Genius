using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPipeConnector : MonoBehaviour
{
    [SerializeField]
    private GameObject lineRendererPrefab;
    [SerializeField]
    private List<Transform> startPoint;
    [SerializeField]
    private EndPoint[] endPoint;

    private GameObject currentLRgo;
    private LineRenderer currentLineRenderer;
    private bool canDrag = false;
    private GameObject observer;

    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canDrag)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            currentLineRenderer.SetPosition(1, pos);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        currentLRgo = Instantiate(lineRendererPrefab, transform);
        currentLineRenderer = currentLRgo.GetComponent<LineRenderer>();
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        currentLineRenderer.SetPosition(0, pos);
        canDrag = true;
    }

    private void OnMouseUp()
    {
        canDrag = false;
        bool rightStart = false, rightEnd = false;
        int numerator = -1;
        foreach(Transform t in startPoint)
        {
            numerator++;
            if (Vector3.Distance(t.position, currentLineRenderer.GetPosition(0))<=1)
            {
                rightStart = true;
                currentLineRenderer.SetPosition(0, t.position);
                break;
            }
        }
        if(rightStart)
        {
            int pointId = -1;
            //EndPoint point = new EndPoint();
            for(int i = 0; i < endPoint.Length; i++)
            {
                if (Vector3.Distance(endPoint[i].point.position, currentLineRenderer.GetPosition(1))<=1)
                {
                    if (!endPoint[i].connectState)
                    {
                        rightEnd = true;
                        currentLineRenderer.SetPosition(1, endPoint[i].point.position);
                        pointId = i;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if(rightEnd)
            {
                endPoint[pointId].connectionId = numerator;
                endPoint[pointId].ChangeConnectState(true);
                for(int i = 0; i < endPoint[pointId].rightEndPoints.Count;i++)
                {
                    if (endPoint[pointId].rightEndPoints[i].position == currentLineRenderer.GetPosition(0))
                    {
                        endPoint[pointId].ChangeRightConnection(true);
                        break;
                    }
                }
            }
            else
            {
                ClearLineRenderer();
            }    
        }
        else
        {
            ClearLineRenderer();
        }
        bool canEnd = true;
        if(rightStart && rightEnd)
        {
            foreach(EndPoint end in endPoint)
            {
                if(!end.connectState) 
                {
                    canEnd = false;
                    break;
                }
            }
        }
        else
        {
            canEnd  = false;
        }
        if(canEnd)
        {
            bool isRightEnd = true;
            foreach(EndPoint end in endPoint)
            {
                if(!end.rightConnection)
                {
                    isRightEnd = false;
                    break;
                }
            }
            if(!isRightEnd)
            {
                Debug.Log("Lvl Failed");
                PlayerData.isLvlFail = true;
            }
            GetComponent<NewPipeShowElements>().ShowPipes(endPoint[0], endPoint[1]);
            observer.GetComponent<ActionVariant>().NextAction();
        }
    }

    private void ClearLineRenderer()
    {
        Destroy(currentLRgo);
        currentLineRenderer = null;
    }
}

[Serializable]
public struct EndPoint
{
    public Transform point;
    public bool connectState;
    public bool rightConnection;
    public List<Transform> rightEndPoints;
    public int connectionId;

    public void ChangeConnectState(bool state)
    {
        connectState = state;
    }

    public void ChangeRightConnection(bool state)
    {
        rightConnection = state;
    }
}
