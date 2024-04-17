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
    private Vector2 vectorMove;
    [SerializeField]
    private float cameraSpeed = 1;
    [SerializeField]
    private Vector2 pulseRange;
    [SerializeField]
    private Text pulsedText;
    [SerializeField]
    private int textGrowSpeed = 1;

    [SerializeField]
    private Button loadLevel;
    [SerializeField]
    private Button Renter;
    [SerializeField]
    private Button manison;
    [SerializeField]
    private Button skin;

    [SerializeField]
    private GameObject manisonUI;
    private GameObject mainMenuUI;
    bool canMove = true;
    private void Awake()
    {
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
        loadLevel.onClick.AddListener(LoadLevel);
        manison.onClick.AddListener(EnterToManison);
        skin.onClick.AddListener(OpenSkinWardrobe);
        StartCoroutine(TextGrow());
    }
    float x;
    // Update is called once per frame
    void Update()
    {
        if (mainMenuUI.active)
        {
            x = Camera.main.transform.position.x;
            if (x < distance.y && x > distance.x)
            {
                Camera.main.transform.Translate(vectorMove * cameraSpeed * Time.deltaTime);
            }
            else
            {
                vectorMove *= -1;
            }
        }
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + PlayerData.CurrentLvl);
    }

    public void EnterToManison()
    {
        manisonUI.SetActive(true);
        mainMenuUI.SetActive(false);
        StopCoroutine(TextGrow());
    }

    public void OpenSkinWardrobe()
    {

    }
    
    public void OpenMainMenu()
    {
        manisonUI.SetActive(false);
        mainMenuUI.SetActive(true);
        StartCoroutine(TextGrow());
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
