using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DressSlot : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer dressGameObject;
    [SerializeField]
    private Sprite dressSprite;
    [SerializeField]
    private GameObject offStand;
    [SerializeField]
    private GameObject onStand;
    [SerializeField]
    private GameObject greenLight;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private GameObject buyMenu;
    [SerializeField]
    private int id;
    // Start is called before the first frame update
    private void Awake()
    {
        dressGameObject.sprite = dressSprite;
        if (PlayerData.currentDressId == id)
        {
            PlayerData.SetCurrentDress(this);
            SelectCurrentDress();
        }
        else
        {
            DeselectCurrentDress();
        }
        if(PlayerData.DressIsUnlocked(id))
        {
            buyMenu.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    public void SelectCurrentDress()
    {
        particle.Play();
        greenLight.SetActive(true);
        offStand.SetActive(false);
        onStand.SetActive(true);
    }

    public void DeselectCurrentDress()
    {
        particle.Stop();
        greenLight.SetActive(false);
        offStand.SetActive(true);
        onStand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0) && PlayerData.DressIsUnlocked(id))
        {
            PlayerData.SetCurrentDress(this);
            //isActive = !isActive;
            //if (isActive)
            //    SelectCurrentDress();
            //else
            //    DeselectCurrentDress();
        }
    }

    public int GetDressId()
    {
        return id;
    }
}
