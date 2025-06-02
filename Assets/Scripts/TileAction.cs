using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAction : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int scoreValue = 1;
    public bool isClicked { get; private set; } = false;

    void Update()
    {
        transform.Translate(Vector2.down * (Speed + 0.3f * Score.scorePoints) * Time.deltaTime);
    }

    public void OnTouch()
    {
        if (isClicked) return;
        isClicked = true;
        AudioManager.Instance.PlayNote();
        FindObjectOfType<Score>().ScoreUpdate(scoreValue);
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
