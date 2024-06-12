using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSide : MonoBehaviour
{

    [SerializeField]
    private Vector2 distance;
    [SerializeField]
    private Vector2 vectorMoveBase;
    [SerializeField]
    private float cameraSpeed = 1;
    [SerializeField]
    private Button loadLevel;
    [SerializeField]
    private Button renter;
    [SerializeField]
    private Button manison;
    [SerializeField]
    private Button skin;
    [SerializeField]
    private Button disableAds;
    [SerializeField]
    private Button shop;
    [SerializeField]
    private TMP_Text coinUI;

    [SerializeField]
    private GameObject manisonUI;
    [SerializeField]
    private GameObject renterCanvas;
    [SerializeField]
    private GameObject mainMenuUI;
    private Vector2 vectorMove;
    bool canMove = true;

    [SerializeField]
    private bool hideMineMenu = false;

    private void Awake()
    {
        PlayerData.CoinUI = coinUI;
        vectorMove = vectorMoveBase;
        manisonUI.SetActive(true);
        manisonUI.GetComponent<UnlockingItemList>().LoadEnvironment();
        manisonUI.SetActive(false);
        //mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI");
        PlayerData.UpdateCoinCount();
        //loadEnviornmentInto rooms
    }

    // Start is called before the first frame update
    void Start()
    {
        renter.onClick.AddListener(OpenRenterMenu);
        loadLevel.onClick.AddListener(LoadLevel);
        manison.onClick.AddListener(EnterToManison);
        skin.onClick.AddListener(OpenSkinWardrobe);
        disableAds.onClick.AddListener(DisableAds);
        shop.onClick.AddListener(OpenShop);
    }

    float x;
    // Update is called once per frame
    void Update()
    {
        if (hideMineMenu)
            return;
        if (mainMenuUI.active)
        {
            x = Camera.main.transform.position.x;
            if(x > distance.y)
            {
                vectorMove = -vectorMoveBase;
            }
            else if(x < distance.x)
            {
                vectorMove = vectorMoveBase;
            }
            Camera.main.transform.Translate(vectorMove * cameraSpeed * Time.deltaTime);
        }
        
    }

    public void LoadLevel()
    {
        int lvl = PlayerData.CurrentLvl;
        if (lvl <= 0)
        {
            PlayerData.CurrentLvl = 1;
            SceneManager.LoadScene("Level_1");
        }
        else if (lvl > 100)
        {
            SceneManager.LoadScene("Level_100");
        }
        else
        {
            SceneManager.LoadScene("Level_" + PlayerData.CurrentLvl);
        }
    }

    public void EnterToManison()
    {
        manisonUI.SetActive(true);
        mainMenuUI.SetActive(false);
        //StopCoroutine(TextGrow());
    }

    public void OpenSkinWardrobe()
    {
        SceneManager.LoadScene("Skin");
    }
    
    public void OpenRenterMenu()
    {
        renterCanvas.SetActive(true);
        renterCanvas.GetComponent<RenterUI>().ActivateButton();
    }

    public void OpenMainMenu()
    {
        manisonUI.SetActive(false);
        mainMenuUI.SetActive(true);
        //StartCoroutine(TextGrow());
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void DisableAds()
    {
        SceneManager.LoadScene("Shop");
        //DISABLE ADS
    }
}
