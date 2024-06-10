using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class PhoneTextLang : MonoBehaviour
{
    [SerializeField] private PhoneText text;
    [SerializeField] private Text textField;
    [SerializeField] private TMP_Text tmpTxt;
    
    private void Awake()
    {
        string textData = PlayerData.localText == "ru" ? text.ruText : text.enText;

        if (textField != null)
            textField.text = textData;
        if (tmpTxt != null)
            tmpTxt.text = textData;
    }

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (tmpTxt == null)
        {
            tmpTxt = GetComponent<TMP_Text>();
            if(tmpTxt != null)
                EditorUtility.SetDirty(this);
        }
    }
    #endif
}
