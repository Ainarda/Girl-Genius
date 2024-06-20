using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMP_Skip : MonoBehaviour
{
    [SerializeField]
    private Button skipFree;

    private GameObject observer;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        skipFree.onClick.AddListener(observer.GetComponent<Observer>().SkipLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
