using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private bool stage = true; //true - dress || false - pet
    // Start is called before the first frame update
    void Awake()
    {
        dressButton.onClick.AddListener(SetDressScroll);
        petButton.onClick.AddListener(SetPetScroll);
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
}
