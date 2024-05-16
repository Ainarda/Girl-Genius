using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    [SerializeField]
    private Button back;
    [SerializeField]
    private Button green;
    [SerializeField]
    private Button yellow;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(BackButton);
        green.onClick.AddListener(GreenButton);
        yellow.onClick.AddListener(YellowButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  BackButton()
    {
        SceneManager.LoadScene("Maison");
    }

    private void GreenButton()
    {

    }

    private void YellowButton()
    {

    }
}
