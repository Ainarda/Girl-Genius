using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStorageLoader : MonoBehaviour
{
    [SerializeField]
    private List<Room> rooms;
    void Awake()
    {
        RoomStorage.roomData = new List<Room>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
