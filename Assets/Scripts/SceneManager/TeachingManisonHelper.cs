using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeachingManisonHelper : MonoBehaviour
{
    [SerializeField]
    private Button buttonClick;
    [SerializeField]
    private GameObject helperHand;
    [SerializeField]
    private Button NextLvl;
   /* [SerializeField]
    private GameObject helperHandNextLevel;*/

    GameObject observer;
    private void Awake()
    {
        buttonClick.onClick.AddListener(HelpDoAction);
        NextLvl.onClick.AddListener(GoNext);
        observer = GameObject.FindGameObjectWithTag("Observer");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelpDoAction()
    {
        helperHand.SetActive(false);
        //helperHandNextLevel.SetActive(true);
        observer.GetComponent<ActionVariant>().NextAction();
    }

    public void GoNext()
    {
        PlayerData.mansionScene = false;
        PlayerData.LoadNextLevel();
    }
}
