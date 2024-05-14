using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenderImage : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImage(Sprite inputSprite)
    {
        icon.sprite = inputSprite;
    }
}
