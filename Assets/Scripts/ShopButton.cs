using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    private Button bigButton;
    [SerializeField]
    private Button adsButton;

    private GameObject observer;
    // Start is called before the first frame update
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        bigButton.onClick.AddListener(BigPurchase);
        adsButton.onClick.AddListener(AdsPurchase);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BigPurchase()
    {
        observer.GetComponent<YdLoader>().Purchase(PurchaseData.id[1]);
    }

    private void AdsPurchase()
    {
        observer.GetComponent<YdLoader>().Purchase(PurchaseData.id[0]);
    }


}
