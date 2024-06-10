using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class DressSlot : MonoBehaviour
{
    [SerializeField]
    private Image dressImage;
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
    [SerializeField]
    private Button buyButton;
    [SerializeField] private Button bigButton;
    [SerializeField]
    private int cost;
    [SerializeField]
    private TMP_Text costText;
    // Start is called before the first frame update

    //TODO fix particle system
    private void Awake()
    {
        costText.text = cost.ToString();
        buyButton.onClick.AddListener(BuyDress);
        dressImage.sprite = dressSprite;
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

    private void OnEnable()
    {
        bigButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        bigButton.onClick.RemoveListener(OnButtonClick);
    }
    
    private void OnButtonClick()
    {
        PlayerData.SetCurrentDress(this);
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

    private void BuyDress()
    {
        if(PlayerData.CanSpendCoin(cost))
        {
            PlayerData.AddCoin(-cost);
            PlayerData.UnlockCustom(id);
        }
    }

    public int GetDressId()
    {
        return id;
    }
}
