using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button getRewardButton;
    [SerializeField]
    private Button homeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Set Action to button
    /// </summary>
    /// <param name="number"> 0 - home, 1 - get reward, 2 - retry, 3 - next</param>
    /// <param name="action">Button click action</param>
    public void SetButtonAction(int number, DoAction action)
    {
        Debug.Log("Set button action " + number);
        switch(number)
        {
            case 0:
                homeButton.onClick.AddListener(action.Invoke);
                break;
            case 1:
                getRewardButton.onClick.AddListener(action.Invoke);
                break;
            case 2:
                retryButton.gameObject.name += "+";
                retryButton.onClick.AddListener(action.Invoke);
                break;
            case 3:
                nextButton.gameObject.name += "+";
                nextButton.onClick.AddListener(action.Invoke);
                break;
            default:
                break;
        }
    }
}
