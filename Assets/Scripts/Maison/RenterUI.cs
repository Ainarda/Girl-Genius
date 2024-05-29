using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenterUI : MonoBehaviour
{
    [SerializeField]
    private Button noThanksButton;
    [SerializeField]
    private GameObject baseCanvas;
    // Start is called before the first frame update
    [SerializeField]
    private List<Renter> renters;

    [SerializeField]
    private Sprite blue;
    [SerializeField] 
    private Sprite gold;
    [SerializeField]
    private RenterPage firstRenterPage;
    [SerializeField]
    private RenterPage secondRenterPage;

    private GameObject observer;
    public void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        noThanksButton.onClick.AddListener(CloseRenterWindow);
        if (PlayerData.openRenterCanvas)
        {
            gameObject.SetActive(true);
            baseCanvas.SetActive(false);
            InitiateRenters();
            PlayerData.openRenterCanvas = false;
            PlayerData.currentRenter += 2;
        }
        else
        {
            CloseRenterWindow();
        }
    }

    public void InitiateRenters()
    {
        if (PlayerData.canSelectRenter)
        {
            InitRenterPage(firstRenterPage, renters[PlayerData.currentRenter], PlayerData.currentRenter);
            InitRenterPage(secondRenterPage, renters[PlayerData.currentRenter + 1], PlayerData.currentRenter + 1);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void InitRenterPage(RenterPage page, Renter renter, int id)
    {
        page.AdsButton.GetComponent<Button>().onClick.AddListener(delegate { SelectRenterWithAds(id); });
        page.FreeButton.GetComponent<Button>().onClick.AddListener(delegate { SelectRenterWithAds(id); });
        if (renter.WithAds)
        {
            page.Background.sprite = gold;
            page.AdsButton.SetActive(true);
            page.FreeButton.SetActive(false);
        }
        else
        {
            page.Background.sprite = blue;
            page.AdsButton.SetActive(false);
            page.FreeButton.SetActive(true);
        }
        if(PlayerData.localText == "ru")
        {
            page.DescriptionText.text = renter.Description.ruText;
            page.NameText.text = renter.Name.ruText;
        }
        else
        {
            page.DescriptionText.text = renter.Description.enText;
            page.NameText.text = renter.Name.enText;
        }
        page.PayTextFree.text = renter.Payments.ToString();
        page.PayTextAds.text = renter.Payments.ToString();
        page.RenterImage.sprite = renter.Icon;
        page.CurrentRenterId = id;
    }

    public void LoadRenters()
    {
        for(int i = 0; i < renters.Count; i++)
        {
            if (PlayerData.renterState[i])
            {
                renters[i].RenterGameObject.SetActive(true);
                //TODO mayber initiate renter Action
            }
        }
    }

    void Start()
    {

    }

    public void ActivateButton()
    {
        Invoke("ActivateButtonWithDelay", 2f);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateButtonWithDelay()
    {
        noThanksButton.gameObject.SetActive(true);
    }

    private void CloseRenterWindow()
    {
        noThanksButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        baseCanvas.SetActive(true);
    }

    private void SelectRenterWithAds(int id)
    {
        //
        observer.GetComponent<YdLoader>().LoadAdsWithReward(() => { Debug.Log("VideoReward"); });
        SelectRenter(id);
    }

    private void SelectRenter(int id)
    {
        PlayerData.canSelectRenter = false;
        renters[id].RenterGameObject.SetActive(true);
        renters[id].RenterGameObject.GetComponent<EntityAI>().SelectNextAction();
        PlayerData.renterState[id] = true;
        PlayerData.AddCoin(renters[id].Payments);
        /*if(number == 0)
        {
            
        }
        else
        {
            PlayerData.AddCoin(renters[secondRenterPage.CurrentRenterId].Payments);
        }*/
        PlayerData.UpdateCoinCount();
        CloseRenterWindow();
    }
}

[Serializable]
public struct Renter
{
    public PhoneText Name;
    public PhoneText Description;
    public int Payments;
    public Sprite Icon;
    public Sprite Background;
    public bool WithAds;
    public bool State;
    public GameObject RenterGameObject;
}

[Serializable]
public struct RenterPage
{
    public Image Background;
    public GameObject FreeButton;
    public GameObject AdsButton;
    public Text NameText;
    public Text DescriptionText;
    public Text PayTextFree;
    public Text PayTextAds;
    public Image RenterImage;
    public int CurrentRenterId;
}
