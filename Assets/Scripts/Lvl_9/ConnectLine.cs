using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool canDrag = false;
    [SerializeField]
    private GameObject endPoint;
    [SerializeField]
    private List<GameObject> failEndPoint;
    [SerializeField]
    private bool isWrong = false;

    private Observer observer;
    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        if(!isWrong)
            observer.AddElement(gameObject);
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
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseUp()
    {
        canDrag = false;
        if(Vector2.Distance(offset + Camera.main.ScreenToWorldPoint(Input.mousePosition), endPoint.transform.position) > 0.5f)
        {
            bool findEndPoint = false;
            foreach (var elem in failEndPoint)
            {
                if (Vector2.Distance(offset + Camera.main.ScreenToWorldPoint(Input.mousePosition), elem.transform.position) < 0.5f)
                {
                    findEndPoint = true;
                    lineRenderer.SetPosition(1, elem.transform.position);
                    break;
                }
            }
            if (!findEndPoint)
                lineRenderer.SetPosition(1, lineRenderer.GetPosition(0));
            else
                foreach (var elem in failEndPoint)
                    observer.OpenLoseScreen();
        }
        else
        {
            lineRenderer.SetPosition(1, endPoint.transform.position);
            if(!isWrong)
                observer.RemoveElement(gameObject);
        }
    }
}
