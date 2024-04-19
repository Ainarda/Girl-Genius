using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressUnlockerScreen : MonoBehaviour
{
    [SerializeField]
    private Button keepButton;
    [SerializeField]
    private Button loseItButton;
    [SerializeField]
    private SpriteRenderer renderer;

    //TODO sprite list
    private Sprite sprite;
    // Start is called before the first frame update
    void Awake()
    {
        loseItButton.onClick.AddListener(LoseIt);
        keepButton.onClick.AddListener(KeepIt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoseIt()
    {
        this.gameObject.SetActive(false);
    }

    private void KeepIt()
    {
        PlayerData.UnlockCustom(PlayerData.currentDressId);
        LoseIt();
    }
}
