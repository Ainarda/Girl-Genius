using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour
{
    [SerializeField]
    private float rightAngle;
    bool canRotate = false;
    private GameObject observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        Debug.Log(transform.rotation.z);
        if (transform.rotation.z >= 0.7071068)
        {
            canRotate = false;
            observer.GetComponent<Observer>().CompleteSceneWithoutCheck();
        }

    }

    private void OnMouseDown()
    {
        canRotate = true;
    }

    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.rotation.z - Quaternion.AngleAxis(rightAngle, Vector3.forward).z) <= 0.7f)
        {
            Debug.Log("Complete");
        }
    }
}
