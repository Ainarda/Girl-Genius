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

    private void Start()
    {
        LoadUpgradeIcon();
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

    public void LoadUpgradeIcon()
    {
        int number = 0;
        foreach(GameObject item in roomUnlockingList)
        {
            if(!PlayerData.unlockingRoom[item.GetComponent<UnlockingEnvironment>().GetRoomNumber()-1])
            {
                item.transform.localPosition = new Vector3(-1000000, -100000);
            }
            else
            {
                if(number < 3)
                {
                    item.transform.localPosition = startPos + step * number;
                    number++;
                }
                else
                {
                    item.transform.localPosition = new Vector3(-1000000, -100000);
                }
            }
        }
    }
}
