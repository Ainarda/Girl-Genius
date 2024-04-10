using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressHold : MonoBehaviour
{
    [SerializeField]
    private int targetValue = 5;

    private Observer observer;
    private int currentValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(Hold());
    }

    private void OnMouseUp()
    {
        StopCoroutine(Hold());
        Debug.Log(currentValue);
    }

    private IEnumerator Hold()
    {
        while(currentValue < targetValue)
        {
            yield return new WaitForSeconds(1f);
            currentValue++;
        }
        Debug.Log("ActionComplete");
        observer.CompleteSceneWithoutCheck();
    }
}
