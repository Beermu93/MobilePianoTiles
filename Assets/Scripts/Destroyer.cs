using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tile = collision.gameObject.GetComponent<TileAction>();
        if (tile)
        {
            if(!tile.isClicked)
            {
                LevelManager.instance.OnLevelEnded();
            }
            Destroy(tile.gameObject);
        }
    }
}
