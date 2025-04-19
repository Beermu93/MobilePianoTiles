using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //public static Action OnPianoDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tile = collision.gameObject.GetComponent<PianoTile>();
        if (tile)
        {
            //OnPianoDestroyed?.Invoke();
            Destroy(tile.gameObject);
        }
    }
}
