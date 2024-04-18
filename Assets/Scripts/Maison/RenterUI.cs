using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenterUI : MonoBehaviour
{
    [SerializeField]
    private Button noThanksButton;
    // Start is called before the first frame update

    public void Awake()
    {
        noThanksButton.onClick.AddListener(CloseRenterWindow);
    }

    void Start()
    {

    }

    public void ActivateButton()
    {
        Invoke("ActivateButtonWithDelay", 2f);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateButtonWithDelay()
    {
        noThanksButton.gameObject.SetActive(true);
    }

    private void CloseRenterWindow()
    {
        noThanksButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
