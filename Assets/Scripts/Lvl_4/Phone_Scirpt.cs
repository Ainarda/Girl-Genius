using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone_Scirpt : MonoBehaviour
{
    [SerializeField]
    private Button agree;
    [SerializeField]
    private Button degree;
    [SerializeField]
    private GameObject senderBlock;
    [SerializeField]
    private GameObject myBlock;

    [SerializeField]
    private string startMessage;
    [SerializeField]
    List<string> goodSenderText;
    [SerializeField]
    List <string> badSenderText;
    [SerializeField]
    List<string> blueAnsweringText;
    [SerializeField]
    List<string> redAnsweringText;

    private int currentMessageSender = 0;
    private int currentMessageAnswering = 0;
    // Start is called before the first frame update
    void Awake()
    {
        agree.onClick.AddListener(AgreeButton);
        degree.onClick.AddListener(DegreeButton);
    }

    private void Start()
    {
        senderBlock.transform.GetChild(0).GetComponent<Text>().text = startMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AgreeButton()
    {
        myBlock.transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering];
        currentMessageAnswering++;
        StartCoroutine(NextLetter(true));
    }

    private void DegreeButton()
    {
        myBlock.transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering];
        currentMessageAnswering++;
        StartCoroutine(NextLetter(false));
    }



    IEnumerator NextLetter(bool answerType)
    {
        
        agree.gameObject.SetActive(false);
        degree.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        string text;
        if (answerType)
        {
            text = goodSenderText[currentMessageSender];
        }
        else
        {
            text = badSenderText[currentMessageSender];
        }
        senderBlock.transform.GetChild(0).GetComponent<Text>().text = text;
        currentMessageSender++;

        if (!(currentMessageAnswering >= blueAnsweringText.Count))
        {
            yield return new WaitForSeconds(2);
            agree.gameObject.SetActive(true);
            degree.gameObject.SetActive(true);
        }
    }
}
