using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameObserver : MonoBehaviour
{
    private List<GameObject> elements = new List<GameObject>();
    private List<bool> elementsState = new List<bool>();

    private GameObject observer;

    private void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddElement(GameObject elem)
    {
        elements.Add(elem);
    }

    public void RemoveElement(GameObject elem, bool state)
    {
        elements.Remove(elem);
        elementsState.Add(state);
        if(elements.Count == 0)
        {
            foreach (bool elState in elementsState)
            {
                if (!elState)
                {
                    PlayerData.isLvlFail = true;
                    break;
                }
            }
            observer.GetComponent<ActionVariant>().NextAction();
        }
    }
}
