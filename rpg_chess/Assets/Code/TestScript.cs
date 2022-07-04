
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestScript : MonoBehaviour
{
    

    void Start()
    {
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles = new Dictionary<CellTypeEnum, (TileBase, TileBase)>();
        cellTiles.Add(CellTypeEnum.Plain, (Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/Stone"), null));
        Dictionary<int, TileBase> resourceTiles = new Dictionary<int, TileBase>();
        

        

        
        //cells.Add(new Cell(new Vector2Int(0, 1), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(0, 2), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(0, 3), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(0, 4), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-1, 0), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-2, 0), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-2, 1), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-2, 2), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-2, 3), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-1, 3), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-1, -1), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(1, 1), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-3, 1), CellTypeEnum.Plain, map));
        //cells.Add(new Cell(new Vector2Int(-1, 2), CellTypeEnum.Plain, map));

        
    }
}

