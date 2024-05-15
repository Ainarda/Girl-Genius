using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoomStorage
{
    // Start is called before the first frame update
    public static List<Room> roomData;
}

[Serializable]
public struct Room
{
    public int id;
    public List<Sprite> environmentSprites;
    public List<int> cost;
}
