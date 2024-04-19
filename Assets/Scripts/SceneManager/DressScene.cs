using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> dressObject;


    private void Awake()
    {
        /*List<Dress> id = PlayerData.dress;
        for(int i = 0; i < id.Count; i++)
        {
            if (id[i].GetState())
            {
                dressObject[i].GetComponent<DressObject>().ActiveUnlockedImage();
            }
            else
            {
                dressObject[i].GetComponent<DressObject>().ActiveLocked();
            }
        }*/
    }
}
