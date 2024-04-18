using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnlocker : MonoBehaviour
{
    [SerializeField]
    private GameObject locker;
    [SerializeField]
    private int roomNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerData.RoomIsOpen(roomNumber))
        {
            UnlockRoom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockRoom()
    {
        locker.SetActive(false);
    }
}
