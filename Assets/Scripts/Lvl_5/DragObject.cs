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
    private GameObject losePosition;
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private bool someAction;
    [SerializeField]
    private bool isWorng = false;
    private Vector3 offset;
    private bool moveObject = false;
    
    Observer observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        transform.position = startPosition;
        if(!isWorng)
            observer.AddElement(this.gameObject);
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
        moveObject = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        moveObject = false;
        if(Vector2.Distance(offset+Camera.main.ScreenToWorldPoint(Input.mousePosition),endPosition.transform.position)<0.5f)
        {
            transform.position = endPosition.transform.position;
            observer.RemoveElement(this.gameObject);
            this.enabled = false;
            if (someAction)
                SomeAction();

        }
        else if(losePosition != null && Vector2.Distance(offset + Camera.main.ScreenToWorldPoint(Input.mousePosition), losePosition.transform.position) < 0.5f)
        {
            transform.position = losePosition.transform.position;
            observer.OpenLoseScreen();
            this.enabled = false;
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public void SomeAction()
    {
        GetComponent<LoadObject>().Activate();
    }
}
