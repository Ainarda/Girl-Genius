using System.Collections;
using System.Collections.Generic;
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
    private Vector2 pulseRange;
    [SerializeField]
    private Text pulsedText;
    [SerializeField]
    private int textGrowSpeed = 1;


    private Vector2 vectorMove;
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
    private GameObject manisonUI;
    [SerializeField]
    private GameObject renterCanvas;
    private GameObject mainMenuUI;
    bool canMove = true;
    private void Awake()
    {
        vectorMove = vectorMoveBase;
        manisonUI.SetActive(true);
        manisonUI.GetComponent<UnlockingItemList>().LoadEnvironment();
        manisonUI.SetActive(false);
        mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI");
        PlayerData.CoinUI = GameObject.FindGameObjectWithTag("CoinUI").GetComponent<Text>();
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
        StartCoroutine(TextGrow());
    }

    float x;
    // Update is called once per frame
    void Update()
    {
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

    public IEnumerator TextGrow()
    {
        Debug.Log("+");
        float addedNumber = .01f;
        while (true)
        {
                yield return new WaitForSeconds(0.025f);
                pulsedText.transform.localScale = new Vector3(addedNumber * textGrowSpeed, addedNumber * textGrowSpeed) + pulsedText.transform.localScale;
                if (pulsedText.transform.localScale.x > pulseRange.y)
                    addedNumber *= -1;
                if (pulsedText.transform.localScale.x < pulseRange.x)
                    addedNumber *= -1;
        }
    }
}
