using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pets : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pets;

    // Start is called before the first frame update
    void Awake()
    {
        int id = PlayerData.currentPetId;
        if (id >= 0)
        {
            pets[id].SetActive(true);
            pets[id].GetComponent<EntityAI>().SelectNextAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
