using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private float scrollRange;

    private Vector3 offset;
    private Vector3 currentPos;
    private Vector2 moveVector;
    private Vector2 startPos;
    
    private bool canDrag = false;
    private bool complete = false;
    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }




    // Update is called once per frame
    void Update()
    {
        if (canDrag)
        {
            moveVector = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveVector.x = startPos.x;
            if (Mathf.Abs(moveVector.y - startPos.y) < scrollRange)
                transform.position = moveVector;
            currentPos = transform.position;
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
    }
}
