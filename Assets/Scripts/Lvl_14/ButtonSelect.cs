using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button wrongButton;

    private Observer observer;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        rightButton.onClick.AddListener(RightClick);
        wrongButton.onClick.AddListener(WrongClick);
        observer.AddElement(rightButton.gameObject);
        observer.AddFailElement(wrongButton.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RightClick()
    {
        observer.RemoveElement(rightButton.gameObject);
    }
    private void WrongClick()
    {
        observer.RemoveElement(wrongButton.gameObject);
    }
}
