using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject hint;

    [SerializeField]
    private List<ActionType> failTypeActionList;
    [SerializeField]
    private List<Group> failGroup;
    [SerializeField]
    private List<NPC_Animation> failObjectAnimationName;
    [SerializeField]
    private List<WalkPosition> failWalkPosition;
    [SerializeField]
    private List<TalkText> failTalkText;
    [SerializeField]
    private List<float> failWaitTime;
    [SerializeField]
    private List<float> failCropSize;
    [SerializeField]
    private List<GameObject> failHideObject;
    [SerializeField]
    private List<GameObject> failActiveObject;  




    private int animationNameNumber, walkPositionNumber, talkTextNumber, waitTimeNumber, cropSizeNumber, audioClipNumber,
        rotationObjectNumber, animationObjectNumber, groupNumber, miniGameNumber, hideObjectNumber, activeObjectNumber, sizeChangeNumber;

    private int failAnimationNameNumber, failWalkPositionNumber, failTalkTextNumber, failWaitTimeNumber, failCropSizeNumber, failAudioClipNumber,
        failRotationObjectNumber, failAnimationObjectNumber, failGroupNumber, failMiniGameNumber, failHideObjectNumber, failActiveObjectNumber, failSizeChangeNumber;

    private bool stageIsActive = false;

    private GameObject playerMessage, otherMessage;
    private Text playerField, otherField;

    private Observer observer;
    private List<DoAction> activateAction;
    private List<DoAction> failActivateAction;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
        //hint = GameObject.FindGameObjectWithTag("HintHand");
        CloseHint();
        activateAction = new List<DoAction>();
        failActivateAction = new List<DoAction>();
        InitAction(typeActionList, activateAction);
        InitAction(failTypeActionList, failActivateAction);
        ActivateAction();
    }

    private int currentAction = 0;
    private int failCurrentAction = 0;
    // Update is called once per frame
    void Update()
    {
        /*if(activateStage)
        {
            activateStage = false;
            activateAction[currentAction++]();
        } */  
    }

    public void SetTextField(GameObject playerM, GameObject otherM)
    {
        playerMessage = playerM;
        otherMessage = otherM;
        playerField = playerMessage.transform.GetChild(0).GetComponent<Text>();
        otherField = otherMessage.transform.GetChild(0).GetComponent<Text>();
    }

    public void GetAudioSource()
    {

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
        if (!PlayerData.isLvlFail)
        {
            if (currentAction < activateAction.Count)
                activateAction[currentAction++]();
            else
                Debug.LogWarning("EndScene");
        }
        else
        {
            if(failCurrentAction < failActivateAction.Count)
            {
                failActivateAction[failCurrentAction++]();
            }
            else
            {
                observer.OpenLose();
            }
        }
    }

    private void InitAction(List<ActionType> inputActionType, List<DoAction> setDoAction)
    {
        foreach(var action in inputActionType)
        {
            switch(action)
            {
                case ActionType.playAnimation:
                    setDoAction.Add(StartAnimation);
                    break;
                case ActionType.walk:
                    setDoAction.Add(StartWalk);
                    break;
                case ActionType.talk:
                    setDoAction.Add(StartTalk);
                    break;
                case ActionType.wait:
                    setDoAction.Add(StartWait);
                    break;
                case ActionType.moveWithCamera:
                    setDoAction.Add(StartMoveWithCamera);
                    break;
                case ActionType.cameraCrop:
                    setDoAction.Add(StartCameraCrop);
                    break;
                case ActionType.activateMiniGame:
                    setDoAction.Add(StartMinigame);
                    break;
                case ActionType.completeScene:
                    setDoAction.Add(StartCompleteScene);
                    break;
                case ActionType.someAction:
                    setDoAction.Add(StartSomeAction);
                    break;
                case ActionType.rotate:
                    setDoAction.Add(StartRotate);
                    break;
                case ActionType.playMusic:
                    setDoAction.Add(StartAudioPlay);
                    break;
                case ActionType.hideObject:
                    setDoAction.Add(HideObject);
                    break;
                case ActionType.activeObject:
                    setDoAction.Add(ActiveObject);
                    break;
                case ActionType.changeSize:
                    setDoAction.Add(StartChangeSize);
                    break;
                default:
                    break;
            }
        }
    }

    #region Start some action region
    private void StartAnimation()
    {
        if (!PlayerData.isLvlFail)
        {
            Debug.Log("Start animation " + objectAnimationName[animationNameNumber].animationName);
            if (objectAnimationName[animationNameNumber].isGroup)
            {
                foreach (GameObject elem in group[objectAnimationName[animationNameNumber].groupId].group)
                {
                    TrackEntry entry = elem.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, objectAnimationName[animationNameNumber].animationName, !objectAnimationName[animationNameNumber].isLoop);
                }
                animationNameNumber++;
            }
            else
            {
                //Add true or false loop animation
                TrackEntry entry = animationObject[animationObjectNumber++].GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, objectAnimationName[animationNameNumber++].animationName, !objectAnimationName[animationNameNumber].isLoop);
            }
        }
        else
        {
            foreach(GameObject elem in failGroup[failObjectAnimationName[failAnimationNameNumber].groupId].group)
            {
                TrackEntry entry = elem.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, failObjectAnimationName[failAnimationNameNumber].animationName, !failObjectAnimationName[failAnimationNameNumber].isLoop);
            }
            failAnimationNameNumber++;
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
        if (!PlayerData.isLvlFail)
        {
            Debug.Log("+");
            StartCoroutine(Walk(walkPosition[walkPositionNumber].position.position, group[walkPosition[walkPositionNumber].groupId].group, walkPosition[walkPositionNumber].speed));
            walkPositionNumber++;
        }
        else
        {
            StartCoroutine(Walk(failWalkPosition[failWalkPositionNumber].position.position, failGroup[failWalkPosition[failWalkPositionNumber].groupId].group, failWalkPosition[failWalkPositionNumber].speed));
            failWalkPositionNumber++;
        }
    }

    private void StartTalk()
    {
        stageIsActive = false;
        if (!PlayerData.isLvlFail)
        {
            
            //TODO show current message
            StartCoroutine(Talk(talkText[talkTextNumber++]));
        }
        else
        {
            StartCoroutine(Talk(failTalkText[failTalkTextNumber++]));
        }
    }
    
    private void StartWait()
    {
        if (!PlayerData.isLvlFail)
        {
            StartCoroutine(Wait(waitTime[waitTimeNumber++]));
        }
        else
        {
            StartCoroutine(Wait(failWaitTime[failWaitTimeNumber++]));
        }
    }

    private void StartMoveWithCamera()
    {
        if (!PlayerData.isLvlFail)
        {
            StartCoroutine(MoveWithCamera(walkPosition[walkPositionNumber].position.position, group[walkPosition[walkPositionNumber].groupId].group, walkPosition[walkPositionNumber].speed));
            walkPositionNumber++;
        }
        else
        {
            StartCoroutine(MoveWithCamera(failWalkPosition[failWalkPositionNumber].position.position, failGroup[failWalkPosition[failWalkPositionNumber].groupId].group, failWalkPosition[failWalkPositionNumber].speed));
            failWalkPositionNumber++;
        }
    }

    private void StartCameraCrop()
    {
        if (!PlayerData.isLvlFail)
            StartCoroutine(CameraCrop(cropSize[cropSizeNumber++]));
        else
        {
            StartCoroutine(CameraCrop(failCropSize[failCropSizeNumber++]));
        }
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
        if (hint != null)
        {
            if (hint.GetComponent<HelperScript>().GetShowState() || PlayerData.lvlHints)
                hint.SetActive(true);
        }
        PlayerData.minigameIsActive = true;
        miniGame[miniGameNumber++].SetActive(true);
    }

    private void StartCompleteScene()
    {
        observer.OpenWinScreen();
    }

    private void HideObject()
    {
        if(!PlayerData.isLvlFail)
            hideObject[hideObjectNumber++].SetActive(false);
        else
        {
            failHideObject[failHideObjectNumber++].SetActive(false);
        }
        ActivateAction();
    }

    private void ActiveObject()
    {
        if(!PlayerData.isLvlFail)
            activeObject[activeObjectNumber++].SetActive(true);
        else
        {
            failActiveObject[failActiveObjectNumber++].SetActive(true);
        }
        ActivateAction();
    }

    private void StartChangeSize()
    {
        StartCoroutine(SizeChange(sizebleObject[sizeChangeNumber], objectSize[sizeChangeNumber]));
        sizeChangeNumber++;
    }

    #endregion

    #region IEnumerator action region
    private IEnumerator Wait(float time)
    {
        Debug.Log("Start wait");
        yield return new WaitForSeconds(time);
        Debug.Log("End wait");
        ActivateAction();
    }

    private IEnumerator Talk(TalkText currentTalkText)
    {
        string text;
        if (PlayerData.localText == "ru")
        {
            text = currentTalkText.textRu;
        }
        else
        {
            text = currentTalkText.textEng;
        }
        
        Text textCloud;
        RectTransform cloudImage;
        float cloudTextSize = 80.25f;
        if(!currentTalkText.side)
        {
            textCloud = playerField;
            playerMessage.SetActive(true);
            cloudImage = playerMessage.GetComponent<RectTransform>();
        }
        else
        {
            textCloud = otherField;
            otherMessage.SetActive(true);
            cloudImage = otherMessage.GetComponent<RectTransform>();
        }

        #region text size
        // Getting best font size
        textCloud.text = text;
        /*textCloud.resizeTextForBestFit = true;
        Color color = textCloud.color;
        textCloud.color = new Color(0, 0, 0, 0);

        yield return null;
        
        textCloud.color = color;
        int fontSize = textCloud.cachedTextGenerator.fontSizeUsedForBestFit;

        // Fixing pixelated font
        if (fontSize is 12 or 13)
            fontSize = 11;
        else if (fontSize is 15 or 16 or 17)
            fontSize = 14;

       // textCloud.fontSize = fontSize;
       // textCloud.resizeTextForBestFit = false;
        */
        #endregion


        textCloud.text = "";

        foreach (char c in text)
        {
            yield return new WaitForSeconds(0.075f);
            textCloud.text += c;
            if(textCloud.GetComponent<RectTransform>().rect.height > cloudTextSize)
            {
                cloudTextSize = textCloud.GetComponent<RectTransform>().rect.height;
                cloudImage.sizeDelta = new Vector2(cloudImage.sizeDelta.x, cloudImage.sizeDelta.y+ 40);
            }
        }
        yield return new WaitForSeconds(2.5f);
        otherMessage.SetActive(false);
        playerMessage.SetActive(false);
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

    public void CloseHint()
    {
        Debug.LogError("CloseHint");
        if(hint != null)
            hint.SetActive(false);
    }
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

public enum MessageSide
{
    leftLeft,
    leftRight,
    rightLeft,
    rightRight,
}

[Serializable]
public struct TalkText
{
    public bool side; //left = true, right = false
    public string textRu;
    public string textEng;
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

