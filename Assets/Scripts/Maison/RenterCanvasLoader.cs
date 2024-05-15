using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenterCanvasLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject renterCanvas;

    private void Awake()
    {
        if (PlayerData.openRenterCanvas)
        {
            renterCanvas.SetActive(true);
        }
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
