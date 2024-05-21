using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSlingshot : MonoBehaviour
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
    private bool Click = true;

    [SerializeField]
    private Text coinText;
    [SerializeField]
    private int coins = 200;

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
        if (Input.GetMouseButtonDown(0) && Click)
        {
            Debug.Log("+");
            angleGrow = 0;
            //CheckAngle
            if(Mathf.Abs(currentAngle) <25)
            {

            }
            else if(Mathf.Abs(currentAngle)<55)
            {

            }
            else
            {

            }
            Click = false;

        }

        if (Mathf.Abs(currentAngle) < 25)
        {
            coinText.text = (200 * 4).ToString();
        }
        else if (Mathf.Abs(currentAngle) < 55)
        {
            coinText.text = (200 * 3).ToString();
        }
        else
        {
            coinText.text = (200 * 2).ToString();
        }
    }

    public void StopArrow()
    {
        angleGrow = 0;
        Debug.Log(currentAngle);
    }
}
