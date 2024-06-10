using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSlot : MonoBehaviour
{
    [SerializeField]
    private Image petImage;
    [SerializeField]
    private Sprite petSprite;
    [SerializeField]
    private GameObject offStand;
    [SerializeField]
    private GameObject onStand;
    //IDK use it or not
    [SerializeField]
    private GameObject greenLight;
    [SerializeField]
    private GameObject particle;
    //end idk
    [SerializeField]
    private GameObject buyMenu;
    [SerializeField] private Button bigButton; 

    [SerializeField]
    private int id;
    // Start is called before the first frame update
    void Awake()
    {
        petImage.sprite = petSprite;
        bigButton.onClick.AddListener(OnButtonClick);
        if (PlayerData.currentPetId == id)
        {
            PlayerData.SetCurrentPet(this);
            SelectCurrentPet();
        }
        else
        {
            DeselectCurrentPet();
        }
        if (PlayerData.PetIsUnlocked(id))
        {
            buyMenu.SetActive(false);
        }
    }
    
    private void OnButtonClick()
    {
        if (PlayerData.PetIsUnlocked(id))
        {
            PlayerData.SetCurrentPet(this);
        }
    }

    public void SelectCurrentPet()
    {
        particle.SetActive(true);
        greenLight.SetActive(true);
        offStand.SetActive(false);
        onStand.SetActive(true);
    }

    public void DeselectCurrentPet()
    {
        particle.SetActive(false);
        greenLight.SetActive(false);
        offStand.SetActive(true);
        onStand.SetActive(false);
    }


    public int GetPetId()
    {
        return id;
    }
}
