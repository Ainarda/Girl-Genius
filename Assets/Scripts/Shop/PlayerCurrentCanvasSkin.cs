using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentCanvasSkin : MonoBehaviour
{
    private SkeletonGraphic skeletonGraphic;
    private void Awake()
    {
        skeletonGraphic = GetComponent<SkeletonGraphic>();
        string dressId = (PlayerData.currentDressId + 1).ToString();
        if (dressId.Length < 2)
            dressId = "0" + dressId;
        skeletonGraphic.Skeleton.SetSkin("Skin" + dressId);
        skeletonGraphic.Skeleton.SetSlotsToSetupPose();
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
