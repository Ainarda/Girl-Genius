using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;

    private Observer observer;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
    }

    public void SetRetryButton(DoAction action)
    {
        retryButton.onClick.AddListener(action.Invoke);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
