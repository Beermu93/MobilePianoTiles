using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAction : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private AudioClip touchSound;
    public bool isClicked { get; private set; } = false;

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    public void OnTouch()
    {
        if (isClicked) return;

        isClicked = true;

        if (touchSound != null)
        {
            AudioSource.PlayClipAtPoint(touchSound, transform.position);
            FindObjectOfType<Score>().ScoreUpdate(scoreValue);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
