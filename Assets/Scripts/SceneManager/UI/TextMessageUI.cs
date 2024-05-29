using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessageUI : MonoBehaviour
{
    [SerializeField]
    private GameObject playerMessage;
    [SerializeField]
    private GameObject otherMessage;

    [SerializeField]
    private Transform firstMessage;
    [SerializeField]
    private Transform secondMessage;

    private GameObject observer;

    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        observer.GetComponent<ActionVariant>().SetTextField(playerMessage, otherMessage);
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
