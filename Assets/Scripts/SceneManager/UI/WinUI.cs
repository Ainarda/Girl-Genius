using Kimicu.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button getRewardButton;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button getDressButton;
    [SerializeField]
    private Button skipDressButton;
    [SerializeField]
    private Image greenDress;
    [SerializeField]
    private Text dressProgressText;
    [SerializeField]
    private GameObject unlockDressScreen;
    [SerializeField]
    private Button payReward;
    [SerializeField]
    private GameObject roulete;
    [SerializeField]
    private GameObject waiter;

    private GameObject observer;

    private bool canActivateRoulete = true;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        getDressButton.onClick.AddListener(GetDress);
        skipDressButton.onClick.AddListener(SkipDress);
        payReward.onClick.AddListener(RewardPayButton);
        getRewardButton.onClick.AddListener(GetCoinRouleteReward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool dressScreenIsOpen = false;

    public void SetDressScale()
    {
        float value = PlayerData.dressProgress / 4f;
        greenDress.fillAmount = value;
        string text;
        if (PlayerData.localText == "ru")
            text = "ÕŒ¬€… — »Õ: ";
        else
            text = "NEW SKIN: ";
        dressProgressText.text = text+ ((int)(value*100)) +"%";
        Debug.LogError("Dress progress "+value);
        if (PlayerData.dressProgress == 4)
        {
            dressScreenIsOpen = true;
            OpenDressScreen();
        }
    }

    /// <summary>
    /// Set Action to button
    /// </summary>
    /// <param name="number"> 0 - home, 1 - get reward, 2 - retry, 3 - next</param>
    /// <param name="action">Button click action</param>
    public void SetButtonAction(int number, DoAction action)
    {
        Debug.Log("Set button action " + number);
        switch(number)
        {
            case 0:
                homeButton.onClick.AddListener(action.Invoke);
                break;
            case 1:
                getRewardButton.onClick.AddListener(action.Invoke);
                break;
            case 2:
                retryButton.gameObject.name += "+";
                retryButton.onClick.AddListener(action.Invoke);
                break;
            case 3:
                nextButton.gameObject.name += "+";
                nextButton.onClick.AddListener(action.Invoke);
                break;
            default:
                break;
        }
    }

    private void GetCoinRouleteReward()
    {
        int coin = roulete.GetComponent<RewardSlingshot>().StopArrow();
        if(PlayerData.isFirstRullet)
        {
            PlayerData.AddCoin(coin);
            PlayerData.isFirstRullet = false;
            PlayerData.UpdateCoinCount();
        }
        else
            observer.GetComponent<YdLoader>().LoadAdsWithReward(() => { PlayerData.AddCoin(coin); PlayerData.UpdateCoinCount(); });
    }

    public void SkipDress()
    {
        unlockDressScreen.SetActive(false);
        dressScreenIsOpen = false;
        PlayerData.dressProgress = 0;
        ShowBottomButtons();
    }

    public void GetDress()
    {
        observer.GetComponent<YdLoader>().LoadAdsWithReward(() => { PlayerData.UnlockCustom(); unlockDressScreen.SetActive(false); PlayerData.dressProgress = 0; });
        Debug.Log("Get dress");
        unlockDressScreen.SetActive(false);
        dressScreenIsOpen = false;
        ShowBottomButtons();
    }

    public void OpenDressScreen()
    {
        PlayerData.dressProgress = 0;
        unlockDressScreen.SetActive(true);
        Invoke("ShowLoseButton",2f);
    }

    private void ShowLoseButton()
    {
        skipDressButton.gameObject.SetActive(true);
    }

    public void ShowBottomButtons()
    {
        Invoke("ShowButtons", 2f);
    }

    private void ShowButtons()
    {
        if (!dressScreenIsOpen)
        {
            retryButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
            /*if (!Advertisement.AdvertisementIsAvailable)
            {
                nextButton.interactable = false;
                waiter.SetActive(true);
                StartCoroutine(WaitTimer());
            }*/

        }
    }

    private IEnumerator WaitTimer()
    {
        for(int i = 0; i <= 30; i++)
        {
            waiter.GetComponent<WaiterText>().SetTime(30-i);
            yield return new WaitForSeconds(1);
            if(i == 30 && !Advertisement.AdvertisementIsAvailable)
            {
                i -= 10;
            }
        }
        nextButton.interactable=true;
        waiter.SetActive(false);
    }

    public void RewardPayButton()
    {

    }
}
