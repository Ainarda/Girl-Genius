using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    [SerializeField]
    private Vector2 forceVector;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>().AddAction(Action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        rb.simulated = true;
        rb.AddForce(forceVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.simulated = false;
        }    
    }
}
