using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour
{
    [SerializeField]
    private float rightAngle;

    bool canRotate = false;
    private Observer observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        observer.AddElement(this.gameObject);
    }

    float angle;
    // Update is called once per frame
    void Update()
    {
        if (canRotate) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            CheckAngle(angle);
            Debug.Log($"Angle: {angle}");
        }
    }

    private void CheckAngle(float angle)
    {
        if(Mathf.Abs(angle - rightAngle) <= 2.5f)
        {
            observer.RemoveElement(this.gameObject);
            Debug.Log("Complete");
            canRotate = false;
        }
    }

    private void OnMouseDown()
    {
        canRotate = true;
    }

    private void OnMouseUp()
    {
        canRotate = false;
        Debug.Log(angle);
    }
}
