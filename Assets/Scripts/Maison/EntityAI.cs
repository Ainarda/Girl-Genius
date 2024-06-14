using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EntityAI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> point;
    [SerializeField, Description("0 - walk, 1 - walk forward, 2 - stay, 3 - sit (no need)")]
    private List<string> entityAnimation;

    private Transform targetPoint;
    private int roomId;
    private SkeletonAnimation skeletonAnimation;

    private void Awake()
    {
        targetPoint = transform;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private IEnumerator Walk()
    {
        Debug.LogWarning("Start walk!");
        SetNextTargetPoint();
        float speed = targetPoint.position.x - transform.position.x;
        Vector3 translateVector = new Vector3(speed, 0) * Time.deltaTime;
        if(speed < 0)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, entityAnimation[1], true);
        }
        else
        {
            skeletonAnimation.AnimationState.SetAnimation(0, entityAnimation[0], true);
        }
        while(Vector2.Distance(transform.position,targetPoint.position) > 0.5f)
        {
            transform.position+= translateVector;
            yield return new WaitForSeconds(0.01f);
        }
        Debug.LogWarning("End walk!");
        SelectNextAction();
    }

    private IEnumerator Stay()
    {
        Debug.LogWarning("Start Stay!");
        skeletonAnimation.AnimationState.SetAnimation(0, entityAnimation[2], true);
        yield return new WaitForSeconds(3);
        SelectNextAction();
    }

    private IEnumerator Sit()
    {
        Debug.LogWarning("Start sit!");
        skeletonAnimation.AnimationState.SetAnimation(0, entityAnimation[3], true);
        yield return new WaitForSeconds(3);
        SelectNextAction();
    }

    public void SelectNextAction()
    {
        Debug.LogError("Action");
        /*int randomAction = Random.Range(0, 3);
        switch (randomAction)
        {
            case 0:
                StartCoroutine(Walk());
                break;
            case 1:
                StartCoroutine(Sit());
                break;
            default:
                StartCoroutine(Stay());
                break;
        }*/
    }

    private void SetNextTargetPoint()
    {
        int randomPosition = Random.Range(0, point.Count-1);
        if (targetPoint != point[randomPosition])
        {
            targetPoint = point[randomPosition];
        }
        else
        {
            targetPoint = point[randomPosition + 1 < point.Count ? randomPosition + 1 : 0];
        }
    }
}

public enum EntityAction
{
    walk,
    stay,
    sit
}
