using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField]
    private List<Transform> endPoint;
    [SerializeField]
    private List<LineRenderer> lines;

    [SerializeField]
    private GameObject[] pipes;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("Pipes");
        ActivatePipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivatePipes()
    {
        for(int i = 0; i < lines.Count; i++)
        {
            if (lines[i].positionCount == 1)
                continue;
            else
            {
                for(int j = 0; j < endPoint.Count;j++)
                {
                    if (lines[i].GetPosition(1) == endPoint[j].position)
                    {
                        pipes[i * endPoint.Count + j].SetActive(true);
                    }
                }
            }
        }
    }
}
