using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text _text;
    public static int scorePoints;
    public int currentScore;

    private void Start()
    {
        scorePoints = 0;
    }

    public void ScoreUpdate(int score)
    {
        currentScore += score;
        scorePoints = currentScore;
        _text.text = currentScore.ToString("0");
    }

}
