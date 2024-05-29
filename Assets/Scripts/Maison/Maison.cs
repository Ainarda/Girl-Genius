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

    [SerializeField]
    private Vector2 dragRange;

    private List<bool> roomLockState;

    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _resetCamera;

    private bool drag = false;


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

    private void Start()
    {
        _resetCamera = Camera.main.transform.position;
    }

    private float dragX = 0;

    //Mouse movment
    private void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if(!drag)
            {
                drag = true;
                _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        dragX = _origin.x - _difference.x;
        if (drag)
        {
            if(!(dragX< dragRange.x || dragX> dragRange.y))
                Camera.main.transform.position = new Vector3(_origin.x - _difference.x, -0.6f, _origin.z);
        }

    }
}
