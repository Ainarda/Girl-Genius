using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangePannel : MonoBehaviour
{
    [SerializeField]
    private Button dressButton;
    [SerializeField]
    private Button petButton;
    [SerializeField]
    private Sprite activeButton;
    [SerializeField]
    private Sprite unactiveButton;
    [SerializeField]
    private GameObject dressScroll;
    [SerializeField]
    private GameObject petScroll;
    [SerializeField] private Button closeButton;
    [SerializeField]
    private GameObject player;

    private bool stage = true; //true - dress || false - pet
    // Start is called before the first frame update
    void Awake()
    {
        dressButton.onClick.AddListener(SetDressScroll);
        petButton.onClick.AddListener(SetPetScroll);
        closeButton.onClick.AddListener(OnCloseButtonClick);
    }


    private void SetPetScroll()
    {
        dressButton.gameObject.GetComponent<Image>().sprite = unactiveButton;
        petButton.gameObject.GetComponent<Image>().sprite = activeButton;
        dressScroll.SetActive(false);
        petScroll.SetActive(true);
    }

    private void SetDressScroll()
    {
        dressButton.gameObject.GetComponent<Image>().sprite = activeButton;
        petButton.gameObject.GetComponent<Image>().sprite = unactiveButton;
        dressScroll.SetActive(true);
        petScroll.SetActive(false);
    }

    private void OnCloseButtonClick()
    {
        SceneManager.LoadScene("Maison");
    }
}
