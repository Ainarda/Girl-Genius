using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserBoxCheck : MonoBehaviour
{
    [SerializeField]
    private bool isFailElem = false;
    [SerializeField]
    private bool IsDelete = false;

    private Observer observer;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        if (isFailElem)
            observer.AddFailElement(this.gameObject);
        else
            observer.AddElement(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            if(isFailElem)
                observer.RemoveFailElementWithEraser(this.gameObject);
            else
                observer.RemoveElementWithEraser(this.gameObject);
            IsDelete = true;
        }
    }
}
