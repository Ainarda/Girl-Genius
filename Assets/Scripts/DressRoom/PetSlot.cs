using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSlot : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer petGameObject;
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
    private ParticleSystem particle;
    //end idk
    [SerializeField]
    private GameObject buyMenu;
    [SerializeField]
    private int id;
    // Start is called before the first frame update
    void Awake()
    {
        petGameObject.sprite = petSprite;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCurrentPet()
    {
        particle.Play();
        greenLight.SetActive(true);
        offStand.SetActive(false);
        onStand.SetActive(true);
    }

    public void DeselectCurrentPet()
    {
        particle.Stop();
        greenLight.SetActive(false);
        offStand.SetActive(true);
        onStand.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && PlayerData.PetIsUnlocked(id))
        {
            PlayerData.SetCurrentPet(this);
            //isActive = !isActive;
            //if (isActive)
            //    SelectCurrentDress();
            //else
            //    DeselectCurrentDress();
        }
    }

    public int GetPetId()
    {
        return id;
    }
}
