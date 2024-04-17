using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockingEnvironment : MonoBehaviour
{
    [SerializeField]
    private GameObject unlockingObject;
    [SerializeField]
    private int cost;
    [SerializeField]
    private Text costDisplay;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private int roomNumber;
    [SerializeField]
    private int environmentId;
    // Start is called before the first frame update
    void Awake()
    {
        costDisplay.text = cost.ToString();
        buyButton.onClick.AddListener(BuyEnvironment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void BuyEnvironment()
    {
        PlayerData.SpendCoin(cost,roomNumber ,environmentId, ActivateObject);
    }

    public void ActivateObject()
    {
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
