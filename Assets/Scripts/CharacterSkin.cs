using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
    SkeletonAnimation skeletonAnimation;
    private void Awake()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        string dressId = (PlayerData.currentDressId+1).ToString();
            if (dressId.Length < 2)
            dressId = "0" + dressId;
        skeletonAnimation.Skeleton.SetSkin("Skin"+dressId);
        skeletonAnimation.Skeleton.SetSlotsToSetupPose();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
