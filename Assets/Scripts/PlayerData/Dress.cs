using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dress
{
    private int Id;
    private string Name;
    private bool UnlockState;
    private Sprite DressObject;

    public Dress(int id,string name, Sprite dressObject, bool unlockState = false)
    {
        Id = id;
        Name = name;
        UnlockState = unlockState;
        DressObject = dressObject;
    }

    public void UnlockDress()
    {
        UnlockState = true;
    }

    public int GetId()
    {
        return Id;
    }

    public string GetName()
    {
        return Name;
    }

    public bool GetState()
    {
        return UnlockState;
    }

    public Sprite GetSprite()
    {
        return DressObject;
    }
}
