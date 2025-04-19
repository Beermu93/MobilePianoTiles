using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    public float width = 4.15f;
    public float height = 2.6f;
    //private int tiles = 0;
    public GameObject pianoTile;
    private float tileDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnUntil();
        //Destroyer.OnPianoDestroyed += CheckForEmpty;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    private void Update()
    {
        if (CheckForEmpty())
        {
            SpawnUntil();
        }
    }

    void SpawnUntil()
    {
        Transform position = FreePosition();
        if (position)
        {
            GameObject tile = Instantiate(pianoTile, position.transform.position, Quaternion.identity);
            tile.transform.parent = position;
        }

        if (FreePosition()) 
        { 
            Invoke("SpawnUntil", tileDelay);
        }
    }
    void SpawnTiles()
    {
        foreach (Transform child in transform)
        {
            GameObject tile = Instantiate(pianoTile, child.position, Quaternion.identity);
            tile.transform.parent = child;
            //tiles++;
        }
    }

     bool CheckForEmpty()
    {
        //tiles--;

        //if (tiles <= 0)
        //{
        //    SpawnUntil();
        //}

        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform FreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }

    private void OnDisable()
    {
        //Destroyer.OnPianoDestroyed -= CheckForEmpty;
    }
}
