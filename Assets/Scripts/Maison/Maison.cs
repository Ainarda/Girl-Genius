using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{
    [SerializeField]
    private string RoomName;
    [SerializeField]
    private List<GameObject> roomObject;
    [SerializeField]
    private List<Vector2> roomObjectPosition;

    private List<bool> roomLockState;

    public void LoadRoomState(List<bool> state)
    {
        roomLockState = state;
    }

    public void UnlockRoom(int roomObjectId)
    {
        roomLockState[roomObjectId] = true;
        roomObject[roomObjectId].transform.position = roomObjectPosition[roomObjectId];
        //Save room
    }
}
