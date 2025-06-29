using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public TMP_Text _text;
    public TMP_Text highScoreText;
    public int finalScore = 0;
    public int highScore = 0;

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        LoadScoreAsync();
        finalScore = Score.scorePoints;
        _text.text = finalScore.ToString();
    }
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.unscaledDeltaTime, _img.uvRect.size);
    }
    private async void SaveScoreAsync() { await CloudSaveSystem.SaveScoreAsync(highScore); }

    private async void LoadScoreAsync() 
    { 
        highScore = await  CloudSaveSystem.LoadHighScoreAsync();
        if (highScore < finalScore)
        {
            highScore = finalScore;
            SaveScoreAsync();
        }
        highScoreText.text = highScore.ToString();
    }
}
