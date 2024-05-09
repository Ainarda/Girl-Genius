using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionVariant : MonoBehaviour
{
    [SerializeField]
    private string groupName;
    [SerializeField]
    private List<Group> group;
    [SerializeField]
    private List<ActionType> typeActionList;
    [SerializeField]
    private List<NPC_Animation> objectAnimationName;
    [SerializeField]
    private List<GameObject> animationObject;
    [SerializeField]
    private List<GameObject> rotationObject;
    [SerializeField]
    private List<WalkPosition> walkPosition;
    [SerializeField]
    private List<TalkText> talkText;
    [SerializeField]
    private List<float> waitTime;
    [SerializeField]
    private List<float> cropSize;
    [SerializeField]
    private List<AudioClip> audioClips;
    [SerializeField]
    private List<GameObject> miniGame;
    [SerializeField]
    private List<GameObject> hideObject;
    [SerializeField]
    private List<GameObject> activeObject;
    [SerializeField]
    private List<float> objectSize;
    [SerializeField]
    private List<GameObject> sizebleObject;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private bool activateStage = false;

    private int animationNameNumber, walkPositionNumber, talkTextNumber, waitTimeNumber, cropSizeNumber, audioClipNumber,
        rotationObjectNumber, animationObjectNumber, groupNumber, miniGameNumber, hideObjectNumber, activeObjectNumber, sizeChangeNumber;

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

    public void SetAudioSource(AudioSource source)
    {
        audioSource = source;
    }

    public void NextAction()
    {
        ActivateAction();
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
                case ActionType.playMusic:
                    activateAction.Add(StartAudioPlay);
                    break;
                case ActionType.hideObject:
                    activateAction.Add(HideObject);
                    break;
                case ActionType.activeObject:
                    activateAction.Add(ActiveObject);
                    break;
                case ActionType.changeSize:
                    activateAction.Add(StartChangeSize);
                    break;
                default:
                    break;
            }
        }
    }

    #region Start some action region
    private void StartAnimation()
    {
        Debug.Log("Start animation " + objectAnimationName[animationNameNumber].animationName);
        if (objectAnimationName[animationNameNumber].isGroup)
        {
            foreach(GameObject elem in group[objectAnimationName[animationNameNumber].groupId].group)
            {
                TrackEntry entry = elem.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(1, objectAnimationName[animationNameNumber].animationName, !objectAnimationName[animationNameNumber].isLoop);
            }
            animationNameNumber++;
        }
        else
        {
            //Add true or false loop animation
            TrackEntry entry = animationObject[animationObjectNumber++].GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(1, objectAnimationName[animationNameNumber++].animationName, !objectAnimationName[animationNameNumber].isLoop);
        }
        ActivateAction();
    }

    private void StartWalk()
    {
        //добавить IEnumerable
        /*foreach (GameObject elem in group)
        {
            elem.transform.position = walkPosition[walkPositionNumber].position;
        }*/
        Debug.Log("+");
        StartCoroutine(Walk(walkPosition[walkPositionNumber].position.position, group[walkPosition[walkPositionNumber].groupId].group, walkPosition[walkPositionNumber].speed));
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
        StartCoroutine(MoveWithCamera(walkPosition[walkPositionNumber].position.position, group[walkPosition[walkPositionNumber].groupId].group, walkPosition[walkPositionNumber].speed));
        walkPositionNumber++;
    }

    private void StartCameraCrop()
    {
        StartCoroutine(CameraCrop(cropSize[cropSizeNumber++]));
    }

    private void StartAudioPlay()
    {
        audioSource.clip = audioClips[audioClipNumber++];
        audioSource.Play();
        ActivateAction();
    }

    private void StartRotate()
    {
        //TODO rotate
        rotationObject[rotationObjectNumber++].transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        ActivateAction();
    }

    private void StartSomeAction()
    {

    }

    private void StartMinigame()
    {
        miniGame[miniGameNumber++].SetActive(true);
    }

    private void StartCompleteScene()
    {
        observer.OpenWinScreen();
    }

    private void HideObject()
    {
        hideObject[hideObjectNumber++].SetActive(false);
        ActivateAction();
    }

    private void ActiveObject()
    {
        activeObject[activeObjectNumber++].SetActive(true);
        ActivateAction();
    }

    private void StartChangeSize()
    {
        StartCoroutine(SizeChange(sizebleObject[sizeChangeNumber], objectSize[sizeChangeNumber]));
        sizeChangeNumber++;
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
        Debug.Log(talkText[talkTextNumber++].text);
        yield return new WaitForSeconds(1);
        ActivateAction();
    }

    private IEnumerator Walk(Vector3 endPos, List<GameObject> objectMove, float speed)
    {
        if (speed <= 0)
            speed = 1;
        Vector3 moveVector = (endPos - objectMove[0].transform.position).normalized*0.05f;
        Debug.Log(moveVector);
        while (Vector3.Distance(objectMove[0].transform.position, endPos) > 0.1f)
        {
            yield return new WaitForSeconds(0.02f);
            foreach (GameObject obj in objectMove)
            {
                obj.transform.Translate(moveVector*speed);
            }
        }
        objectMove[0].transform.position = endPos;
        stageIsActive = false;
        ActivateAction();
    }

    private IEnumerator MoveWithCamera(Vector3 endPos, List<GameObject> objectMove, float speed)
    {
        if (speed <= 0)
            speed = 1;
        Vector3 moveVector = (endPos - objectMove[0].transform.position).normalized * 0.05f;
        while (Vector3.Distance(objectMove[0].transform.position, endPos) > 0.1f)
        {
            yield return new WaitForSeconds(0.02f);
            foreach (GameObject obj in objectMove)
            {
                obj.transform.Translate(moveVector*speed);
            }
            
            Camera.main.transform.Translate(moveVector*speed);
        }
        objectMove[0].transform.position = endPos;
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

    private IEnumerator SizeChange(GameObject sizebleObject, float size)
    {
        int multiplayer = size - sizebleObject.transform.localScale.x < 0 ? -1 : 1;
        while (Mathf.Abs(sizebleObject.transform.localScale.x - size) > 0.1)
        {
            sizebleObject.transform.localScale += new Vector3(0.01f, 0.01f) * multiplayer;
            yield return new WaitForSeconds(0.02f);
        }
        sizebleObject.transform.localScale = new Vector3(size, size);
        ActivateAction();
    }
    #endregion
}

[Serializable]
public struct Group
{
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
    playMusic,
    someAction,
    activateMiniGame,
    completeScene,
    hideObject,
    activeObject,
    changeSize,
}

[Serializable]
public struct TalkText
{
    public bool side; //left = true, right = false
    public string text;
}

[Serializable]
public struct NPC_Animation
{
    public string animationName;
    public bool isGroup;
    public int groupId;
    public bool isLoop;
}

[Serializable]
public struct WalkPosition
{
    public Transform position;
    public int groupId;
    public float speed;
}

//TODO Add move camera

