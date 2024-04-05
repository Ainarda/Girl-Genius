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

    private Vector2 startPos;
    private Vector3 offset;
    private bool canDrag = false;
    private bool complete = false;

    private Vector2 moveVector;

    private void Awake()
    {
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
            if(Mathf.Abs(moveVector.y) < scrollRange)
                transform.position = moveVector;
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
        if(transform.position.y-rightRange<0.1f)
        {

            complete = true;
            rightChecker.SetActive(true);
        }
    }
}
