using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAction : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private List<AudioClip>audioClips = new List<AudioClip>();
    private AudioSource audioSource;
    public bool isClicked { get; private set; } = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    void Update()
    {
        transform.Translate(Vector2.down * (Speed + 0.4f * Score.scorePoints) * Time.deltaTime);
    }

    public void OnTouch()
    {
        if (isClicked) return;

        isClicked = true;

        if (audioSource != null)
        {
            AudioClip clip = audioClips[Random.Range(0,audioClips.Count)];
            audioSource.PlayOneShot(clip);
            FindObjectOfType<Score>().ScoreUpdate(scoreValue);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
