using System;
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
    private PhoneText startMessage;
    [SerializeField]
    List<PhoneText> goodSenderText;
    [SerializeField]
    List <PhoneText> badSenderText;
    [SerializeField]
    List<PhoneText> blueAnsweringText;
    [SerializeField]
    List<PhoneText> redAnsweringText;
    [SerializeField]
    Transform messageScroll;
    [SerializeField]
    Sprite senderSprite;
    [SerializeField]
    Sprite answerSprite;

    private List<GameObject> allText;
    private int currentMessageSender = 0;
    private int currentMessageAnswering = 0;

    private int currentMessageNumber = 0; //All message number

    private Vector3 step = new Vector3(5, 75);
    private Vector3 startPos = new Vector3(-5, 140);

    private Observer observer;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        observer.AddElement(this.gameObject);
        allText = new List<GameObject>();
        agree.onClick.AddListener(AgreeButton);
        degree.onClick.AddListener(DegreeButton);
    }

    private void Start()
    {
        //GameObject newMessage = Instantiate(myBlock, transform);
        StartDialoge();
       // senderBlock
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartDialoge()
    {
        GameObject newMessage = Instantiate(senderBlock, messageScroll);
        newMessage.transform.localPosition = startPos;
        newMessage.GetComponent<SenderImage>().SetImage(senderSprite);
        if (PlayerData.localText == "ru")
            newMessage.transform.GetChild(0).GetComponent<Text>().text = startMessage.ruText;
        else
            newMessage.transform.GetChild(0).GetComponent<Text>().text = startMessage.enText;
        allText.Add(newMessage);
        currentMessageNumber++;
        ActivateButton();
        NextPlayerMessage();
    }

    private void NextPlayerMessage()
    {
        GameObject newMessage = Instantiate(myBlock, messageScroll);
        newMessage.transform.localPosition = new Vector3(step.x, allText[allText.Count - 1].transform.localPosition.y - step.y, 0);
        newMessage.GetComponent<SenderImage>().SetImage(answerSprite);
        allText.Add(newMessage);
        currentMessageNumber++;
        allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = "...";
    }

    private void AgreeButton()
    {
        
        if(PlayerData.localText == "ru")
            allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering].ruText;
        else
            allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering].enText;
        currentMessageAnswering++;
        StartCoroutine(NextLetter(true));
    }

    private void DegreeButton()
    {
        if (PlayerData.localText == "ru")
            allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering].ruText;
        else
            allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering].enText;
        currentMessageAnswering++;
        StartCoroutine(NextLetter(false));
    }



    IEnumerator NextLetter(bool answerType)
    {
        agree.gameObject.SetActive(false);
        degree.gameObject.SetActive(false);
        GameObject newMessage = Instantiate(senderBlock, messageScroll);
        newMessage.transform.localPosition = new Vector3(-step.x, allText[allText.Count - 1].transform.localPosition.y - step.y, 0);
        newMessage.GetComponent<SenderImage>().SetImage(senderSprite);
        allText.Add(newMessage);
        currentMessageNumber++;
        newMessage.transform.GetChild(0).GetComponent<Text>().text = "...";
        yield return new WaitForSeconds(4);
        if (answerType)
        {
            if (PlayerData.localText == "ru")
                newMessage.transform.GetChild(0).GetComponent<Text>().text = goodSenderText[currentMessageSender].ruText;
            else
                newMessage.transform.GetChild(0).GetComponent<Text>().text = goodSenderText[currentMessageSender].enText;
            
        }
        else
        {
            if (PlayerData.localText == "ru")
                newMessage.transform.GetChild(0).GetComponent<Text>().text = badSenderText[currentMessageSender].ruText;
            else
                newMessage.transform.GetChild(0).GetComponent<Text>().text = badSenderText[currentMessageSender].enText;
            yield return new WaitForSeconds(2);
        }
        currentMessageSender++;

        if (!(currentMessageAnswering >= blueAnsweringText.Count))
        {
            yield return new WaitForSeconds(2);
            //TODO change text on agree and degree button
            ActivateButton();
            NextPlayerMessage();
        }
        else
        {
            yield return new WaitForSeconds(4);
            observer.RemoveElement(this.gameObject);
        }

        if (currentMessageNumber > 3)
            ScrollText();

        
    }

    private void ActivateButton()
    {
        agree.gameObject.SetActive(true);
        if (PlayerData.localText == "ru")
            agree.transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering].ruText;
        else
            agree.transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering].enText;
        degree.gameObject.SetActive(true);
        if (PlayerData.localText == "ru")
            degree.transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering].ruText;
        else
            degree.transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering].enText;
    }

    private void ScrollText()
    {
        currentMessageNumber -= 2;
        messageScroll.position += new Vector3   (0, step.y * 2);
    }
}

[Serializable]
public struct PhoneText
{
    public string ruText;
    public string enText;
}
