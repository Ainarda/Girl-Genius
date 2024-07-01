using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button hintButton;
    [SerializeField]
    private LoseTimeField timerObject;

    private Observer observer;
    private DoAction retryAction;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        hintButton.onClick.AddListener(delegate { observer.GetComponent<YdLoader>().LoadAdsWithReward(ActivateHint); });
    }

    public void ActivateTimer()
    {
        timerObject.StartTimer(retryAction);
    }

    public void SetRetryButton(DoAction action)
    {
        retryAction = action;
        //retryButton.gameObject.SetActive(true);
        //retryAction.Invoke);
        Invoke("ActivateMainsonButton", 2);
    }


    public void ActivateMainsonButton()
    {
        retryButton.gameObject.SetActive(true);
        retryButton.onClick.AddListener(delegate { SceneManager.LoadScene("Maison"); });
    }

    public void ActivateHint()
    {
        PlayerData.lvlHints = true;
        observer.GetComponent<Observer>().ReloadScene();
        //TODO Hint activation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
