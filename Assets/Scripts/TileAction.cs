using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileAction : MonoBehaviour
{
    public SpriteRenderer _Color;
    public int scoreValue = 1;
    public AudioClip touchSound;
    private bool isClicked;

    private void Start()
    {
        isClicked = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            AudioSource.PlayClipAtPoint(touchSound, transform.position);
            _Color.color = Color.yellow;
            FindObjectOfType<Score>().ScoreUpdate(scoreValue);
            isClicked = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_Color.color == Color.yellow) 
        { 
            //Debug.Log("bien ahi"); 
        }
        else if(collision.collider.tag == "Border")
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
