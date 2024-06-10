using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockingEnvironment : MonoBehaviour
{
    [SerializeField]
    public GameObject unlockingObject;
    [SerializeField]
    public GameObject hideObject;
    [SerializeField]
    public int cost;
    [SerializeField]
    private TMP_Text costDisplay;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Button adsButton;
    [SerializeField]
    public int roomNumber;
    [SerializeField]
    public int environmentId;
    [SerializeField]
    private GameObject locker;
    [SerializeField]
    private bool withAds = false;
    [SerializeField]
    private Image displayImage;
    [SerializeField]
    public Sprite displayedSprite;

    GameObject observer;
    
    // Start is called before the first frame update
    void Awake()
    {
        displayImage.sprite = displayedSprite;
        observer = GameObject.FindGameObjectWithTag("Observer");
        buyButton.gameObject.SetActive(!withAds);
        adsButton.gameObject.SetActive(withAds);
        locker.SetActive(!PlayerData.RoomIsOpen(roomNumber));
        costDisplay.text = "<sprite index=0> "+cost.ToString();
        buyButton.onClick.AddListener(BuyEnvironment);
        adsButton.onClick.AddListener(BuyEnvironmentWithAds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void BuyEnvironment()
    {
        PlayerData.SpendCoin(cost,roomNumber-1 ,environmentId-1, ActivateObject);
    }

    private void BuyEnvironmentWithAds()
    {
        observer.GetComponent<YdLoader>().LoadAdsWithReward(ActivateObject);
    }

    public void ActivateObject()
    {
        if(hideObject != null)
            hideObject.SetActive(false);
        unlockingObject.SetActive(true);
        Debug.Log("Room id " + roomNumber + " envi id " + environmentId);
        GameObject.FindGameObjectWithTag("MainisonUI").GetComponent<UnlockingItemList>().RemoveUnlockingItem(this.gameObject);
    }

    public int GetRoomNumber()
    {
        return roomNumber;
    }

    public int GetEnvironmentId()
    { return environmentId;}
}
