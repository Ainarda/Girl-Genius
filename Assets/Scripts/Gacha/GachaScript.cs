using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject openedCap;
    [SerializeField]
    private GameObject closedCap;
    [SerializeField]
    private Image petImage;

    [SerializeField]
    private Sprite[] petImageList;

    private int petId;
    private GachaCreater _creator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPetId(int inputPetId, GachaCreater creator)
    {
        petId = inputPetId;
        _creator = creator;
        petImage.sprite = petImageList[petId];
    }

    public void OpenReward()
    {
        openedCap.SetActive(true);
        closedCap.SetActive(false);
        petImage.gameObject.SetActive(true);
        Invoke("ShowReward",0.1f);
    }

    public void ShowReward()
    {
        _creator.ShowReward(petId);
    }
}
