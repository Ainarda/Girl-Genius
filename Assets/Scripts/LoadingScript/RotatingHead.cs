using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHead : MonoBehaviour
{
    [SerializeField]
    private Transform head;
    float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation -= 0.005f;
        head.transform.Rotate(new Vector3(0, 0, -0.5f));
    }
}