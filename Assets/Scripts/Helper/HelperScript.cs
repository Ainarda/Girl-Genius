using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    [SerializeField]
    private GameObject helperPrefab;
    [SerializeField]
    private Transform[] points;

    private int currentPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        vectorMove = (points[currentPoints + 1].transform.position-helperPrefab.transform.position).normalized;
        vectorMove = NormilizeSpeed(vectorMove) * Time.fixedDeltaTime;
    }
    private Vector2 vectorMove;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentPoints+1< points.Length)
        {
            if(Vector3.Distance(helperPrefab.transform.position, points[currentPoints+1].position)< 0.1f)
            {
                currentPoints++;
                helperPrefab.transform.position = points[currentPoints].transform.position;
                if (currentPoints + 1 < points.Length)
                {
                    vectorMove = (points[currentPoints + 1].transform.position - helperPrefab.transform.position);
                    vectorMove = NormilizeSpeed(vectorMove) * Time.fixedDeltaTime;
                }
            }
            else
            {
                helperPrefab.transform.Translate(vectorMove);
            }
        }
        else
        {
            helperPrefab.transform.position = points[0].transform.position;
            currentPoints = 0;
            vectorMove = (points[currentPoints + 1].transform.position - helperPrefab.transform.position).normalized;
            vectorMove = NormilizeSpeed(vectorMove) * Time.fixedDeltaTime;
        }
    }

    //TODO переделать
    private Vector2 NormilizeSpeed(Vector2 inputVector)
    {
        Vector2 output = new Vector2();
        switch(inputVector.x)
        {
            case 0:
                output.x = 0;
                break;
            case < 0:
                output.x = -1;
                break;
            case > 0:
                output.x = 1;
                break;
        }
        switch (inputVector.y)
        {
            case 0:
                output.y = 0;
                break;
            case < 0:
                output.y = -1;
                break;
            case > 0:
                output.y = 1;
                break;
        }
        return output;
    }
}
