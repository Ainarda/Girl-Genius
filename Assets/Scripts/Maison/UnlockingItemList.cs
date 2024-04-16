using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingItemList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> unlockingList;
    [SerializeField]
    private Vector2 startPos;
    [SerializeField]
    private Vector2 step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveUnlockingItem(GameObject item)
    {
        item.SetActive(false);
        unlockingList.Remove(item);
        unlockingList[0].transform.localPosition = startPos;
        unlockingList[1].transform.localPosition = startPos + step;
        unlockingList[2].transform.localPosition = startPos + step * 2;
    }
}
