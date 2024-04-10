using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserBoxCheck : MonoBehaviour
{
    [SerializeField]
    private bool IsDelete = false;

    private Observer observer;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
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
            observer.RemoveElementWithEraser(this.gameObject);
            IsDelete = true;
        }
    }
}
