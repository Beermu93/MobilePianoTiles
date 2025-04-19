using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text _text;
    public static int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = Score.scorePoints;
        _text.text = finalScore.ToString("0");
    }
}
