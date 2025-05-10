using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    public TMP_Text _text;
    public TMP_Text highScoreText;
    public int finalScore = 0;
    public int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadScoreAsync();
        finalScore = Score.scorePoints;
        _text.text = finalScore.ToString();
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
