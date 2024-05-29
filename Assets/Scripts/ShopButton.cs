using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    private Button bigButton;
    [SerializeField]
    private Button adsButton;
    [SerializeField]
    private Button back;

    private GameObject observer;
    // Start is called before the first frame update
    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        bigButton.onClick.AddListener(BigPurchase);
        adsButton.onClick.AddListener(AdsPurchase);
        back.onClick.AddListener(GoToBack);
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

    private void GoToBack()
    {
        SceneManager.LoadScene("Maison");
    }


}
