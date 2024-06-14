using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private TMP_Text coinText;
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
            if (currentAngle < maxAngle)
            {
                transform.rotation = Quaternion.AngleAxis(maxAngle - 10, Vector3.forward);
                //currentAngle = maxAngle - 10;
            }
            else if(currentAngle > minAngle)
            {
                transform.rotation = Quaternion.AngleAxis(minAngle + 10, Vector3.forward);
                //currentAngle = minAngle + 10;
            }
            angleGrow *= -1;
            currentAngle += angleGrow * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
            
        }

        if (Mathf.Abs(currentAngle) < 25)
        {
            SetCoinText(200 * 4);
        }
        else if (Mathf.Abs(currentAngle) < 55)
        {
            SetCoinText(200 * 3);
        }
        else
        {
            SetCoinText(200 * 2);
        }
    }

    private void SetCoinText(int money)
    {
        coinText.text = $"<sprite index=0> <size=1.2em>{money}";
    }

    public int StopArrow()
    {
        int coin = 200;
        angleGrow = 0;
        Debug.Log(currentAngle);
        if (Mathf.Abs(currentAngle) < 25)
        {
            coin *= 4;
        }
        else if (Mathf.Abs(currentAngle) < 55)
        {
            coin *= 3;
        }
        else
        {
            coin *= 2;
        }
        Click = false;
        return coin;
    }
}
