using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField]
    private bool isInvert;
    private bool missionTask = true;
    Observer observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        if (isInvert)
            observer.AddElement(this.gameObject);
        observer.AddCheck(IsLevelComplete);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "DroppedObject")
        {
            if (isInvert)
            {
                Debug.Log("+");
                observer.RemoveElement(this.gameObject);
                missionTask = true;
            }
            else
            {
                missionTask = false;
            }
            
        }
        //some time wait and restart lvlv
    }

    public bool IsLevelComplete()
    {
        return missionTask;
    }
}
