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
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("+");
            if(currentAngle <= rightAngle.y && currentAngle >= rightAngle.x)
            {
                Debug.Log("Right");
                angleGrow = 0;
            }
        }
    }

    
}
