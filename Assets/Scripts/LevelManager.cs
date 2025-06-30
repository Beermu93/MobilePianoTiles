using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private GameObject loseScreenPrefab;
    [SerializeField] private Canvas scoreCanvas;
    private GameObject loseScreenInstance;

    private void Awake()
    {
        if (instance != this && instance == null) { instance = this; }
        else { Destroy(gameObject); }
        Time.timeScale = 1.0f;
    }

    public void OnLevelEnded()
    {
        Time.timeScale = 0f;
        if (loseScreenInstance != null) { return; }
        loseScreenInstance = Instantiate(loseScreenPrefab);
        scoreCanvas.gameObject.SetActive(false);
    }
}
