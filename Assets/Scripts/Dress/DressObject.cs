using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressObject : MonoBehaviour
{
    [SerializeField]
    private Sprite lockedImage;
    [SerializeField]
    private Sprite unlockedImage;
    [SerializeField]
    private int dressId;

    private SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        //unlockedImage = PlayerData.dress[dressId].GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveUnlockedImage()
    {
        image.sprite = unlockedImage;
    }

    public void ActiveLocked()
    {
        image.sprite = lockedImage;
    }
}
