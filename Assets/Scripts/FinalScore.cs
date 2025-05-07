using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    public TMP_Text _text;
    public TMP_Text highScoreText;
    public static int finalScore = 0;
    public static int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //var lastScore = LoadScoreAsync();
        finalScore = Score.scorePoints;
        _text.text = finalScore.ToString("0");
        if (highScore < finalScore)
        {
            highScore = finalScore;
            highScoreText.text = highScore.ToString("0");
            SaveScoreAsync();
        }
    }
    private async void SaveScoreAsync() { await CloudSaveSystem.SaveScoreAsync(highScore); }

    private async void LoadScoreAsync() { await CloudSaveSystem.LoadHighScoreAsync(); }
}
