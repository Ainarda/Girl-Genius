using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ActionVariant : MonoBehaviour
{
    [SerializeField]
    private string groupName;
    [SerializeField]
    private List<GameObject> group;
    [SerializeField]
    private List<ActionType> typeActionList;
    [SerializeField]
    private List<string> animationName;
    [SerializeField]
    private List<Transform> walkPosition;
    [SerializeField]
    private List<string> talkText;

    [SerializeField]
    private bool activateStage = false;

    private int animationNameNumber, walkPositionNumber, talkTextNumber;


    private List<DoAction> activateAction;
    // Start is called before the first frame update
    void Start()
    {
        activateAction = new List<DoAction>();
        InitAction();

    }

    private int currentAction = 0;
    // Update is called once per frame
    void Update()
    {
        if(activateStage)
        {
            activateStage = false;
            activateAction[currentAction++]();
        }   
    }

    private void InitAction()
    {
        foreach(var action in typeActionList)
        {
            switch(action)
            {
                case ActionType.playAnimation:
                    activateAction.Add(StartAnimation);
                    break;
                case ActionType.walk:
                    activateAction.Add(StartWalk);
                    break;
                case ActionType.talk:
                    activateAction.Add(StartTalk);
                    break;
                default:
                    break;
            }
        }
    }

    private void StartAnimation()
    {
        foreach(GameObject elem in group)
        {
            elem.GetComponent<Animator>().SetBool(animationName[animationNameNumber], true);
        }
        animationNameNumber++;
    }

    private void StartWalk()
    {
        //TODO Делать кое-что другое. Пока заглушка
        foreach (GameObject elem in group)
        {
            elem.transform.position = walkPosition[walkPositionNumber].position;
        }
        walkPositionNumber++;
    }

    private void StartTalk()
    {
        //TODO show current message
        Debug.Log(talkText[talkTextNumber++]);
    }
    
}
public enum ActionType
{
    playAnimation,
    walk,
    talk,
    wait
}
