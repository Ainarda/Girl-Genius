using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject openedCap;
    [SerializeField]
    private GameObject closedCap;

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
    }

    public void OpenReward()
    {
        openedCap.SetActive(true);
        closedCap.SetActive(false);
        Invoke("ShowReward",2);
    }

    public void ShowReward()
    {
        _creator.ShowReward(petId);
    }
}
