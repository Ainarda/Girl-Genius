using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private LoseTimeField timerObject;

    private Observer observer;
    private DoAction retryAction;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
    }

    public void ActivateTimer()
    {
        timerObject.StartTimer(retryAction);
    }

    public void SetRetryButton(DoAction action)
    {
        retryAction = action;
        retryButton.onClick.AddListener(retryAction.Invoke);
    }

    public void ActivateHint()
    {
        //TODO Hint activation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
