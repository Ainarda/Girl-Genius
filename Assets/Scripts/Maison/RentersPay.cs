using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RentersPay : MonoBehaviour
{
    [SerializeField]
    private List<PaymentMember> payments;
    [SerializeField]
    private Button getRent;
    [SerializeField]
    private Button noThanks;

    private GameObject observer;
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        getRent.onClick.AddListener(GetRent);   
        noThanks.onClick.AddListener(NoThanks);
        payments[PlayerData.currentRenterSelected / 2].camera.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetRent()
    {
        observer.GetComponent<YdLoader>().LoadAdsWithReward(() => { PlayerData.AddCoin(300); NoThanks(); });
    }

    private void NoThanks()
    {
        observer.GetComponent<Observer>().SavePlayerData();
        SceneManager.LoadScene("Maison");
    }
}

[Serializable]
public struct PaymentMember
{
    public GameObject camera;
    public GameObject firstRentman;
    public GameObject secondRentman;

    public void ActivateRentman(int rentmanNumber)
    {
        if (rentmanNumber % 2 == 0)
            firstRentman.SetActive(true);
        else
            secondRentman.SetActive(true);
    }
}
