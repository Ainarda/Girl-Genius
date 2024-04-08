using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 offset;
    private bool canDrag = false;

    private int currentPoint = 0;

    private Vector3 currentPointPos;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        currentPointPos = transform.position;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position+new Vector3(-0.1f,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(canDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(currentPoint+1, mousePos + offset);
        }
    }

    private void OnMouseDown()
    {
        canDrag = true;
        
    }

    public void NextPoint(Vector3 _pointPos)
    {
        if (Vector3.Distance(_pointPos, currentPointPos) <= 2)
        {
            lineRenderer.SetPosition(currentPoint + 1, _pointPos);
            lineRenderer.positionCount++;
            currentPoint++;
            currentPointPos = _pointPos;
            RecalcOffset();
        }
    }

    private void RecalcOffset()
    {
        offset = currentPointPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        canDrag = false;
        lineRenderer.SetPosition(currentPoint + 1, currentPointPos);
    }
}
