using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PreAdClicker : MonoBehaviour
{
    [SerializeField] private ActiveLanguageSwitcher scoreCounter;
    [SerializeField] private float spawnDelay;
    [SerializeField] private ClickObject clickObjectPrefab;
    [SerializeField] private Transform tutorialHand;
    [SerializeField] private GameObject tutorialText;

    private List<GameObject> instantiatedObjects = new List<GameObject>();
    
    private int score;

    private bool spawning;
    
    public static UnityEvent AddScore = new UnityEvent();

    private void OnEnable()
    {
        AddScore.AddListener(OnAddScore);
    }

    private void OnDisable()
    {
        AddScore.RemoveListener(OnAddScore);
    }

    private void OnAddScore()
    {
        score++;
        scoreCounter.UpdateValue(score);
        PlayerData.AddCoin(1);
        
        if (tutorialText.activeSelf || tutorialHand.gameObject.activeSelf)
        {
            tutorialText.SetActive(false);
            tutorialHand.gameObject.SetActive(false);
        }
    }

    private void ResetField()
    {
        score = 0;
        scoreCounter.UpdateValue(score);

        foreach (var go in instantiatedObjects)
        {
            if (go)
                Destroy(go);
        }
    }

    public void StartField()
    {
        spawning = true;
        scoreCounter.UpdateValue(score);
        
        StartCoroutine(SpawnObjects());
        
        tutorialHand.gameObject.SetActive(true);
        tutorialText.gameObject.SetActive(true);
    }

    public void StopField()
    {
        spawning = false;
        ResetField();
    }

    private IEnumerator SpawnObjects()
    {
        while (spawning)
        {
            ClickObject clickObject = Instantiate(clickObjectPrefab, transform);
            
            RectTransform clickObjectRt = clickObject.transform as RectTransform;

            clickObjectRt!.anchoredPosition = new Vector2(
                Random.Range(Screen.width * 0.1f, Screen.width * 0.9f),
                Random.Range(Screen.height * 0.1f, Screen.height * 0.2f));
            instantiatedObjects.Add(clickObject.gameObject);
            
            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}
