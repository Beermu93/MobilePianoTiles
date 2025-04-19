using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileAction : MonoBehaviour
{
    public SpriteRenderer _Color;
    public int scoreValue = 1;
            
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        FindObjectOfType<Score>().ScoreUpdate(scoreValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_Color.color == UnityEngine.Color.yellow) { Debug.Log("bien ahi"); }
        else if(collision.collider.tag == "Border")
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
