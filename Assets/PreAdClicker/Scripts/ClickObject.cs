using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour, IPointerClickHandler
{
    [Header("Скорость в процентах высоты экрана в секунду")]
    [SerializeField] private float moveSpeed;
    
    private RectTransform rt;
    private RectTransform parentRt;
    
    private void Awake()
    {
        rt = transform as RectTransform;
        parentRt = transform.parent as RectTransform;
    }

    private void Update()
    {
        rt.anchoredPosition += Vector2.up * (parentRt.rect.height * (moveSpeed / 100) * Time.unscaledDeltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PreAdClicker.AddScore.Invoke();
        Destroy(gameObject);
    }
}
