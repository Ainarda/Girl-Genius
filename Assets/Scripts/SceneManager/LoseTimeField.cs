using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTimeField : MonoBehaviour
{
    [SerializeField]
    private Text numberText;
    [SerializeField]
    private Image fieldCircle;
    [SerializeField]
    private GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        //StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer(DoAction action)
    {
        StartCoroutine(Timer(action));
    }

    private IEnumerator Timer(DoAction action)
    {
        float timer = 1.0f;
        float displayTime = timer;
        while(timer >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            timer -= 0.001f;
            displayTime = timer * 10;
            if (displayTime - (int)displayTime > 0.15f)
                numberText.text = ((int)(displayTime + 1)).ToString();
            else
                numberText.text = ((int)displayTime).ToString();
            fieldCircle.fillAmount = timer;
            if(timer <= 0.5f)
                retryButton.SetActive(true);
        }
        numberText.text = 0 + "";
        action.Invoke();
    }
}
