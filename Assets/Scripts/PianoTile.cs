using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTile : MonoBehaviour
{
    [SerializeField] private float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
}
