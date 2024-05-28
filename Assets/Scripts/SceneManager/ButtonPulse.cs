using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPulse : MonoBehaviour
{
    [SerializeField]
    private GameObject pulseObject;
    [SerializeField]
    private Vector2 pulseRange;
    [SerializeField]
    private float growSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextGrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TextGrow()
    {
        Debug.Log("+");
        float addedNumber = .01f;
        while (true)
        {
            yield return new WaitForSeconds(0.025f);
            pulseObject.transform.localScale = new Vector3(addedNumber * growSpeed, addedNumber * growSpeed) + pulseObject.transform.localScale;
            if (pulseObject.transform.localScale.x > pulseRange.y)
                addedNumber *= -1;
            if (pulseObject.transform.localScale.x < pulseRange.x)
                addedNumber *= -1;
        }
    }
}
