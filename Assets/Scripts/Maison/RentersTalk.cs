using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentersTalk : MonoBehaviour
{
    [SerializeField]
    private GameObject firstRenter;
    [SerializeField]
    private GameObject secondRenter;

    private void Awake()
    {
        //selected renter
        bool selectedRenter = false;
        if(selectedRenter)
            firstRenter.SetActive(false);
        else
            secondRenter.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
