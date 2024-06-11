using Kimicu.YandexGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CostUpdater : MonoBehaviour
{
    [SerializeField]
    private TMP_Text bigPack;
    [SerializeField]
    private TMP_Text smallPack;
    [SerializeField]
    private RawImage bigPackImage;
    [SerializeField]
    private RawImage smallPackImage;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        var purchaces = Billing.CatalogProducts;
        foreach(var item in purchaces)
        {
            if(item.id == "noAds")
            {
                smallPack.text = item.priceValue;
                StartCoroutine(LoadImageFromServer(item.imageURI, smallPackImage));

            }
            else if(item.id == "bigPack")
            {
                bigPack.text = item.priceValue;
                StartCoroutine(LoadImageFromServer(item.imageURI, bigPackImage));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadImageFromServer(string url, RawImage insertImage)
    {
        Debug.Log("Start load image");
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.LogWarning(request.error);
        else
            insertImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

    }
}
