using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    Grid grid;
    [SerializeField]
    GameObject prefab;

    public int counter = 1;

    void Start()
    {
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles = new Dictionary<CellTypeEnum, (TileBase, TileBase)>();
        cellTiles.Add(CellTypeEnum.Plain, (Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/Stone"), null));
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles = new Dictionary<ResourceTypeEnum, TileBase>();
        TileBase manyResourceTile = Resources.Load<TileBase>("Tiles/Special/Bonfire");
        TileBase globalFloor = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/StoneGlobal");
        TileBase globalFloorCornes = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/StoneGlobalCorner");
        TileBase globalFloorShadow = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/Shadow");

        var map = new Map("waw!");
        HashSet<Cell> cells = new HashSet<Cell>();

        Cell cellUn = new Cell(new Vector2Int(0, 0), CellTypeEnum.Plain, map);
        Unit unit = new Unit(cellUn);
        cellUn.AddEntity(unit);

        Cell cellUn1 = new Cell(new Vector2Int(1, 1), CellTypeEnum.Plain, map);
        Unit unit1 = new Unit(cellUn1);
        cellUn1.AddEntity(unit1);
        cells.Add(cellUn);
        cells.Add(cellUn1);
        cells.Add(new Cell(new Vector2Int(0, 1), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(-1, 1), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(-1, 0), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(-1, 4), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(0, 2), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(0, 3), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(0, 4), CellTypeEnum.Plain, map));
        cells.Add(new Cell(new Vector2Int(0, 5), CellTypeEnum.Plain, map));


        map.AddCells(cells);
        GraphicSupporter graphicSupporter = new GraphicSupporter(cellTiles, globalFloor, globalFloorCornes, globalFloorShadow, resourceTiles, manyResourceTile);
        List<Map> maps = new List<Map>();
        maps.Add(map);
        Drawer drawer = new Drawer(grid, prefab, graphicSupporter, maps);
        drawer.DrawUnitIsOnceAttacking(unit);
        drawer.DrawUnitIsDying(unit1);
    }
}
