using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebButton : MonoBehaviour
{
	[SerializeField] private string url;
	
	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() => Application.OpenURL(url));
	}
}
