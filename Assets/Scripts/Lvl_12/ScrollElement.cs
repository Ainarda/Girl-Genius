using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollElement : MonoBehaviour
{
    [SerializeField]
    private float scrollRange;
    [SerializeField]
    private float rightRange;
    [SerializeField]
    private GameObject rightChecker;

    [SerializeField]
    private Vector3 currentPos;

    [SerializeField]
    private float rightRangeDist = 0.1f;
    [SerializeField]
    private Vector2 range;

    private Vector2 startPos;
    private Vector3 offset;
    private bool canDrag = false;
    private bool complete = false;


    private Vector2 moveVector;
    private Observer observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        observer.AddElement(this.gameObject);
        startPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(canDrag && !complete)
        {
            moveVector = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveVector.x = startPos.x;
            if (Mathf.Abs(moveVector.y - startPos.y) < scrollRange)
            {
                transform.position = moveVector;
                Debug.Log(moveVector.y - startPos.y);

            }
            else
            {
                if (moveVector.y - startPos.y < scrollRange)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, 0.64f);
                    canDrag = false;
                    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log("+");
                }
                else if (moveVector.y - startPos.y > scrollRange)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, -0.61f);
                    canDrag = false;
                    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log("-");
                }
            }
            currentPos = transform.position;
           /* if (currentPos.y > 0.69f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -.66f);
            }
            if (currentPos.y < -0.66f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, .69f);
            }*/
            //0.437
        }
    }

    private void OnMouseDown()
    {
        canDrag = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        canDrag = false;
        if(Mathf.Abs(transform.position.y-rightRange)< rightRangeDist)
        {
            complete = true;
            transform.position = new Vector3(transform.position.x, rightRange, 0);
            rightChecker.SetActive(true);
            observer.RemoveElement(this.gameObject);
        }
    }
}
