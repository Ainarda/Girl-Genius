using System;
using System.Collections;
using System.Collections.Generic;
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
    private List<float> waitTime;
    [SerializeField]
    private List<float> cropSize;
    [SerializeField]
    private GameObject miniGame;

    [SerializeField]
    private List<GroupAction> groupActionList;

    [SerializeField]
    private bool activateStage = false;

    private int animationNameNumber, walkPositionNumber, talkTextNumber, waitTimeNumber, cropSizeNumber;

    private bool stageIsActive = false;

    private Observer observer;
    private List<DoAction> activateAction;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        activateAction = new List<DoAction>();
        InitAction();
        ActivateAction();
    }

    private int currentAction = 0;
    // Update is called once per frame
    void Update()
    {
        /*if(activateStage)
        {
            activateStage = false;
            activateAction[currentAction++]();
        } */  
    }

    private void ActivateAction()
    {
        if (currentAction < activateAction.Count)
            activateAction[currentAction++]();
        else
            Debug.LogWarning("EndScene");
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
                case ActionType.wait:
                    activateAction.Add(StartWait);
                    break;
                case ActionType.moveWithCamera:
                    activateAction.Add(StartMoveWithCamera);
                    break;
                case ActionType.cameraCrop:
                    activateAction.Add(StartCameraCrop);
                    break;
                case ActionType.activateMiniGame:
                    activateAction.Add(StartMinigame);
                    break;
                case ActionType.completeScene:
                    activateAction.Add(StartCompleteScene);
                    break;
                case ActionType.someAction:
                    activateAction.Add(StartSomeAction);
                    break;
                case ActionType.rotate:
                    activateAction.Add(StartRotate);
                    break;
                default:
                    break;
            }
        }
    }

    #region Start some action region
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
        //добавить IEnumerable
        /*foreach (GameObject elem in group)
        {
            elem.transform.position = walkPosition[walkPositionNumber].position;
        }*/
        Debug.Log("+");
        StartCoroutine(Walk(walkPosition[walkPositionNumber].position, group[0]));
        walkPositionNumber++;
    }

    private void StartTalk()
    {
        stageIsActive = false;
        //TODO show current message
        StartCoroutine(Talk());
    }
    
    private void StartWait()
    {
        StartCoroutine(Wait());
    }

    private void StartMoveWithCamera()
    {
        StartCoroutine(MoveWithCamera(walkPosition[walkPositionNumber++].position, group[0]));
    }

    private void StartCameraCrop()
    {
        StartCoroutine(CameraCrop(cropSize[cropSizeNumber++]));
    }

    private void StartRotate()
    {
        //TODO rotate
    }

    private void StartSomeAction()
    {

    }

    private void StartMinigame()
    {
        miniGame.SetActive(true);
    }

    private void StartCompleteScene()
    {
        observer.OpenWinScreen();
    }
    
    #endregion

    #region IEnumerator action region
    private IEnumerator Wait()
    {
        Debug.Log("Start wait");
        yield return new WaitForSeconds(waitTime[waitTimeNumber++]);
        Debug.Log("End wait");
        ActivateAction();
    }

    private IEnumerator Talk()
    {
        Debug.Log(talkText[talkTextNumber++]);
        yield return new WaitForSeconds(1);
        ActivateAction();
    }

    private IEnumerator Walk(Vector3 endPos, GameObject objectMove)
    {
        Vector3 moveVector = (endPos - objectMove.transform.position).normalized*0.05f;
        while (Vector3.Distance(objectMove.transform.position, endPos) > 0.1f)
        {
            yield return new WaitForSeconds(0.02f);
            objectMove.transform.Translate(moveVector);
        }
        objectMove.transform.position = endPos;
        stageIsActive = false;
        ActivateAction();
    }

    private IEnumerator MoveWithCamera(Vector3 endPos, GameObject objectMove)
    {
        Vector3 moveVector = (endPos - objectMove.transform.position).normalized * 0.05f;
        while (Vector3.Distance(objectMove.transform.position, endPos) > 0.1f)
        {
            yield return new WaitForSeconds(0.02f);
            objectMove.transform.Translate(moveVector);
            Camera.main.transform.Translate(moveVector);
        }
        objectMove.transform.position = endPos;
        ActivateAction();
    }

    private IEnumerator CameraCrop(float crop)
    {
        int multiplayer = crop-Camera.main.orthographicSize < 0 ? -1 : 1;
        while(Mathf.Abs(Camera.main.orthographicSize-crop) > 0.1)
        {
            Camera.main.orthographicSize += 0.05f * multiplayer;
            yield return new WaitForSeconds(0.02f);
        }
        Camera.main.orthographicSize = crop;
        ActivateAction();
    }
    #endregion
}

[Serializable]
public struct GroupAction
{
    public ActionType actionType;
    public List<GameObject> group;
    //TODO MOVE POSITION
    //CAMERA SCALE
    //ANIMATION
}

public enum ActionType
{
    playAnimation,
    walk,
    talk,
    wait,
    moveWithCamera,
    cameraCrop,
    rotate,
    someAction,
    activateMiniGame,
    completeScene
}

