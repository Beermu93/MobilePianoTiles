using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    public float width = 4.15f;
    public float height = 2.6f;
    public GameObject pianoTile;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTiles();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTiles()
    {
        foreach (Transform child in transform)
        {
            GameObject tile = Instantiate(pianoTile, child.position, Quaternion.identity);
            tile.transform.parent = child;
        }
    }
}
