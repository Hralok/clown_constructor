using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TestScript : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;

    public int counter = 1;

    void Start()
    {
        
    }

    public void ReplaseMe(Vector3Int coords, TileBase tile)
    {
        Debug.Log(tile);
        tilemap.SetTile(coords + new Vector3Int(1,0,0), tile);
    }

    void Update()
    {
        counter++;

        if (counter % 200 == 0)
        {
            tilemap.RefreshAllTiles();
        }



    }
}
