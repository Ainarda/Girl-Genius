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
        SetNextTargetPoint();
        float speed = targetPoint.position.x - transform.position.x;
        Vector2 translateVector = new Vector2(speed, 0).normalized*0.05f;
        if(speed < 0)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, entityAnimation[0], true);
        }
        else
        {
            skeletonAnimation.AnimationState.SetAnimation(1, entityAnimation[1], true);
        }
        while(Vector2.Distance(transform.position,targetPoint.position) > 0.5f)
        {
            transform.Translate(translateVector);
            yield return new WaitForSeconds(0.25f);
        }
        SelectNextAction();
    }

    private IEnumerator Stay()
    {
        skeletonAnimation.AnimationState.SetAnimation(1, entityAnimation[2], true);
        yield return new WaitForSeconds(1);
        SelectNextAction();
    }

    private IEnumerator Sit()
    {
        skeletonAnimation.AnimationState.SetAnimation(1, entityAnimation[3], true);
        yield return new WaitForSeconds(1);
        SelectNextAction();
    }

    public void SelectNextAction()
    {
        int randomAction = Random.Range(0, 3);
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
        }
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
