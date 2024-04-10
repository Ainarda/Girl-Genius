using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingText : MonoBehaviour
{
    [SerializeField]
    private Text textCloud;
    [SerializeField]
    private List<string> text;
    [SerializeField]
    private float textSpeed = 0.05f;

    private int currentTextNumber = 0;
    public bool write = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(write)
        {
            write = false;
            WriteNext();
        }
    }

    public void WriteNext()
    {
        StartCoroutine(SlowWrite(text[currentTextNumber++]));
    }

    private IEnumerator SlowWrite(string text)
    {
        foreach(char c in text)
        {
            yield return new WaitForSeconds(textSpeed);
            textCloud.text += c;
        }
    }
}
