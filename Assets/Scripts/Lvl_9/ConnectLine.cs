using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool canDrag = false;
    [SerializeField]
    private GameObject endPoint;

    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrag)
        {
            Debug.Log("+");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, mousePos+offset);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        canDrag = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        canDrag = false;
        if(Vector2.Distance(offset + Camera.main.ScreenToWorldPoint(Input.mousePosition), endPoint.transform.position) > 0.5f)
        {
            lineRenderer.SetPosition(1, new Vector2(0,0));
        }
        else
        {
            lineRenderer.SetPosition(1, endPoint.transform.position);
        }
    }
}
