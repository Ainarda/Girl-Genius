using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> hide;
    [SerializeField]
    private List<GameObject> show;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        foreach (GameObject go in hide)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in show)
        {
            go.SetActive(true);
        }
    }
}
