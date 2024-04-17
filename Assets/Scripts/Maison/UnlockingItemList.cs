using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingItemList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> roomUnlockingList;
    [SerializeField]
    private Vector2 startPos;
    [SerializeField]
    private Vector2 step;
    // Start is called before the first frame update
    void Awake()
    {
        
        startPos = roomUnlockingList[0].GetComponent<RectTransform>().localPosition;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveUnlockingItem(GameObject item)
    {
        item.SetActive(false);
        roomUnlockingList.Remove(item);
        for (int i = 0; i < 3; i++)
        {
            if (PlayerData.RoomIsOpen(roomUnlockingList[i].GetComponent<UnlockingEnvironment>().GetRoomNumber()))
            {
                Debug.Log(startPos + step * i);
                //roomUnlockingList[i].GetComponent<RectTransform>().localPosition = startPos + step * i;
                roomUnlockingList[i].transform.localPosition = startPos + step * i;
                Debug.Log(roomUnlockingList[i].GetComponent<RectTransform>().localPosition);
            }
        }
        //roomUnlockingList[1].transform.localPosition = startPos + step;
        //roomUnlockingList[2].transform.localPosition = startPos + step * 2;
    }

    public void LoadEnvironment()
    {
        List<bool[]> rooms = PlayerData.environmentIntoRooms;
        List<GameObject> loadedEnvi = new List<GameObject>();
        UnlockingEnvironment unlockEnvi;
        foreach(GameObject item in roomUnlockingList)
        {
            unlockEnvi = item.GetComponent<UnlockingEnvironment>();
            if (rooms[unlockEnvi.GetRoomNumber()-1][unlockEnvi.GetEnvironmentId()-1])
                loadedEnvi.Add(item);
        }
        foreach(GameObject item in loadedEnvi)
        {
            item.GetComponent<UnlockingEnvironment>().ActivateObject();
        }    
    }
}
