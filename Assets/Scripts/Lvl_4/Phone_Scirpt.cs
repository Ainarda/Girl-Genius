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

    private List<GameObject> allText;
    private int currentMessageSender = 0;
    private int currentMessageAnswering = 0;

    private Vector3 step = new Vector3(50, 65);
    private Vector3 startPos = new Vector3(-50, 180);

    private Observer observer;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
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
        GameObject newMessage = Instantiate(senderBlock, transform);
        newMessage.transform.localPosition = startPos;
        newMessage.transform.GetChild(0).GetComponent<Text>().text = startMessage;
        allText.Add(newMessage);
        ActivateButton();
        NextPlayerMessage();
    }

    private void NextPlayerMessage()
    {
        GameObject newMessage = Instantiate(myBlock, transform);
        newMessage.transform.localPosition = new Vector3(step.x, allText[allText.Count - 1].transform.localPosition.y - step.y, 0);
        allText.Add(newMessage);
        allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = "...";
    }

    private void AgreeButton()
    {
        
        allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering];
        currentMessageAnswering++;
        StartCoroutine(NextLetter(true));
    }

    private void DegreeButton()
    {
        
        allText[allText.Count - 1].transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering];
        currentMessageAnswering++;
        StartCoroutine(NextLetter(false));
    }



    IEnumerator NextLetter(bool answerType)
    {
        agree.gameObject.SetActive(false);
        degree.gameObject.SetActive(false);
        GameObject newMessage = Instantiate(senderBlock, transform);
        newMessage.transform.localPosition = new Vector3(-step.x, allText[allText.Count - 1].transform.localPosition.y - step.y, 0);
        allText.Add(newMessage);
        newMessage.transform.GetChild(0).GetComponent<Text>().text = "...";
        yield return new WaitForSeconds(4);
        newMessage.transform.GetChild(0).GetComponent<Text>().text = answerType ? goodSenderText[currentMessageSender] : badSenderText[currentMessageSender];
        currentMessageSender++;
        
        if (!(currentMessageAnswering >= blueAnsweringText.Count))
        {
            yield return new WaitForSeconds(2);
            //TODO change text on agree and degree button
            ActivateButton();
            NextPlayerMessage();
            /*agree.gameObject.SetActive(true);
            agree.transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering];
            degree.gameObject.SetActive(true);
            degree.transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering];*/
        }
        else
        {
            observer.CompleteSceneWithoutCheck();
        }
    }

    private void ActivateButton()
    {
        agree.gameObject.SetActive(true);
        agree.transform.GetChild(0).GetComponent<Text>().text = blueAnsweringText[currentMessageAnswering];
        degree.gameObject.SetActive(true);
        degree.transform.GetChild(0).GetComponent<Text>().text = redAnsweringText[currentMessageAnswering];
    }
}
