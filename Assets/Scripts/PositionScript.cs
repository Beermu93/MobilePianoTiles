using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    public float width = 1f;
    public float height = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
