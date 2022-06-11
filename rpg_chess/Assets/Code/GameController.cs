using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;


    public Sprite[] standSprites;

    public Sprite[] attackSprites;

    public void Start()
    {








        var test2 = new VariableTile(standSprites, attackSprites);

        tilemap.SetTile(new Vector3Int(0, 0, 0), test2);
        
    }
}
