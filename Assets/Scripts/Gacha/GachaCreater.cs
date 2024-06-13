using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaCreater : MonoBehaviour
{
    [SerializeField]
    private GameObject hideText;
    
    [SerializeField]
    private List<GameObject> gachaSphere;
    [SerializeField]
    private GameObject rewardObject;
    [SerializeField]
    private Image rewardSprite;
    [SerializeField]
    private List<Sprite> pets;
    [SerializeField]
    private float textGrowSpeed = 0.1f;
    [SerializeField]
    private Vector2 pulseRange;

    private Text pulsedText;
    private int selectedPetId;
    private GameObject observer;

    private void Awake()
    {
        
        pulsedText = hideText.GetComponent<Text>();
        StartCoroutine(TextGrow());
    }
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        observer.GetComponent<Observer>().CloseMainUI();
        RandomaizeReward();
    }

    public void RandomaizeReward()
    {
        List<int> lockPetId = new List<int>();
        for(int i = 0; i < PlayerData.pet.Length;i++)
        {
            if (!PlayerData.pet[i])
                lockPetId.Add(i);
        }
        int counter = 0;
        foreach (var gacha in gachaSphere)
        {
            gacha.GetComponent<GachaScript>().SetPetId(lockPetId[counter++], this);//Random number
        }
    }

    public void ShowReward(int id)
    {
        hideText.SetActive(false);
        foreach(var gacha in gachaSphere)
        {
            gacha.SetActive(false);
        }
        rewardObject.SetActive(true);
        rewardSprite.sprite = pets[id];
        Invoke("ShowLoseButton", 2f);
    }

    private void ShowLoseButton()
    {
        GetComponent<RewardCanvas>().ShowLoseButton();
    }

    public int GetSelectedPetId()
    {
        return selectedPetId;
    }

    // Update is called once per frame
    void Update()
    {
        
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
