using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField]
    private float maxAngle = 45f;
    [SerializeField]
    private float minAngle = -45f;
    [SerializeField]
    private float currentAngle = 0f;
    [SerializeField]
    private float angleGrow = 5f;

    [SerializeField]
    private Vector2 rightAngle;
    [SerializeField]
    private bool Click = true;

    private Observer observer;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        if (Click)
        {
            observer.AddElement(this.gameObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAngle <= maxAngle && currentAngle >= minAngle)
        {
            currentAngle += angleGrow * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        }
        else
        {
            angleGrow *= -1;
            currentAngle += angleGrow * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        }
        if(Input.GetMouseButtonDown(0) && Click)
        {
            Debug.Log("+");
            angleGrow = 0;
            if (currentAngle <= rightAngle.y && currentAngle >= rightAngle.x)
                observer.RemoveElement(this.gameObject);
            else
                observer.ReloadScene();
            Click = false;

        }
    }

    public void StopArrow()
    {
        angleGrow = 0;
        Debug.Log(currentAngle);
    }

    
}
