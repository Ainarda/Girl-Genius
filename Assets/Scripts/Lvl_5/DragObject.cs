using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    private bool moveOnX = true;
    [SerializeField]
    private bool moveOnY = true;
    [SerializeField]
    private GameObject endPosition;
    [SerializeField]
    private Vector2 startPosition;
    private Vector3 offset;
    private bool moveObject = false;

    GameObject obserever;
    private void Awake()
    {
        obserever = GameObject.FindGameObjectWithTag("Observer");
        transform.position = startPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        if(moveObject)
        {
            Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float oX = transform.position.x, oY = transform.position.y;
            if (moveOnX)
            {
                oX = cam.x;
            }
            else
            { offset.x = 0; }
            if (moveOnY)
            {
                offset.y = 0;
                oY = cam.y;
            }
            else
            { offset.y = 0;}
            transform.position = offset + new Vector3(oX, oY);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("+");
        moveObject = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        moveObject = false;
        if(Vector2.Distance(offset+Camera.main.ScreenToWorldPoint(Input.mousePosition),endPosition.transform.position)<0.5f)
        {
            transform.position = endPosition.transform.position;
            obserever.GetComponent<Observer>().CompleteSceneWithoutCheck();
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
