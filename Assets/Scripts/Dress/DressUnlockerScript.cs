using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressUnlockerScript : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> dress;
    [SerializeField]
    private Image dressImage;
    [SerializeField]
    private Image thankForRewardImage;
    // Start is called before the first frame update
    private void Awake()
    {
        int spriteId = PlayerData.GetNextUnlockDressId();
        if(spriteId < 0)
            gameObject.SetActive(false);
        dressImage.sprite = dress[spriteId];
        thankForRewardImage.sprite = dress[spriteId];
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
