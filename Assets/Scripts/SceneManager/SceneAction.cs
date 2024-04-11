using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAction : MonoBehaviour
{
    //GroupName Time 
    [SerializeField]
    private int lvl;
    private string actionQueueText;
    private List<ActionWithTime> SceneActionList;
    private int currentAction = 0;

    private List<string> groupQueueName;
    private List<float> groupQueueTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextAction()
    {
        SceneActionList[currentAction].Action();
    }

    public void InitAction(List<ActionWithTime> action)
    {
        SceneActionList = action;
    }
}

public struct ActionWithTime
{
    public DoAction Action;
    float Time;

    public ActionWithTime(DoAction action, float time)
    {
        Action = action;
        Time = time;
    }
}
