using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessageUI : MonoBehaviour
{
    [SerializeField]
    private GameObject rightRightMessage;
    [SerializeField]
    private GameObject rightLeftMessage;
    [SerializeField]
    private GameObject leftLeftMessage;
    [SerializeField]
    private GameObject leftRightMessage;

    [SerializeField]
    private Transform firstMessage;
    [SerializeField]
    private Transform secondMessage;

    private GameObject observer;

    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        observer.GetComponent<ActionVariant>().SetTextField(rightRightMessage, leftLeftMessage);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
