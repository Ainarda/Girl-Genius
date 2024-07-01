using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPipeShowElements : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pipesFirst;
    [SerializeField]
    private GameObject[] pipesSecond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPipes(EndPoint first, EndPoint second)
    {
        pipesFirst[first.connectionId].SetActive(true);
        pipesSecond[second.connectionId].SetActive(true);
    }
}
