using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class ButtonFlip : MonoBehaviour
{
    [SerializeField]
    private Vector2 angles;
    [SerializeField]
    private float angleGrow = 5f;
    [SerializeField]
    private float waitTime;

    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = angleGrow;
        StartCoroutine(Flipper());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float currentAngle = 0f;
    int number = 0;
    private IEnumerator Flipper()
    {
        while (true)
        {
            if (number < 3)
            {
                if (currentAngle <= angles.x)
                {
                    angle = angleGrow;
                    number++;
                }
                else if(currentAngle >= angles.y)
                {
                    angle = -angleGrow;
                    number++;
                }
                RotateButton();
            }
            else
            {
                if(currentAngle >= 0)
                {
                    RotateButton();
                }
                else
                {
                    number = 0;
                    angle = angleGrow;
                    yield return new WaitForSeconds(waitTime);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void RotateButton()
    {
        currentAngle += angle * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    }
}
