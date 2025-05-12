using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    [SerializeField] private float width = 4.15f;
    [SerializeField] private float height = 2.6f;
    [SerializeField] private GameObject pianoTile;
    private float tileDelay = 0.5f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 8f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnUntil();
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
        float randomNumber = Random.Range(minY, maxY);
        Vector3 tileOffset = new Vector3( 0, randomNumber, 0);
        if (position)
        {
            GameObject tile = Instantiate(pianoTile, position.transform.position + tileOffset, Quaternion.identity);
            tile.transform.parent = position;
        }

        if (FreePosition()) 
        { 
            Invoke("SpawnUntil", tileDelay);
        }
    }

     bool CheckForEmpty()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 1)
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
}
