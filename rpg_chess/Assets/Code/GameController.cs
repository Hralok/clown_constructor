using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Grid grid;
    [SerializeField]
    GameObject mapPrefab;

    Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles = new Dictionary<CellTypeEnum, (TileBase, TileBase)>();
    Dictionary<ResourceTypeEnum, TileBase> resourceTiles = new Dictionary<ResourceTypeEnum, TileBase>();
    [SerializeField]
    TileBase manyResourceTile;
    private List<Cell> cells;
    GraphicSupporter graphicSupport;
    public void Start()
    {
        resourceTiles[ResourceTypeEnum.Gold] = Resources.Load<TileBase>("Tiles/Resources/spr_resource_0");
        resourceTiles[ResourceTypeEnum.Tree] = Resources.Load<TileBase>("Tiles/Resources/spr_resource_2");
        resourceTiles[ResourceTypeEnum.Stone] = Resources.Load<TileBase>("Tiles/Resources/spr_resource_1");

        cellTiles[CellTypeEnum.Desert] = (Resources.Load<TileBase>("Tiles/Ground/spr_secter_142"), null);
        cellTiles[CellTypeEnum.Plain] = (Resources.Load<TileBase>("Tiles/Ground/spr_secter_210"), null);
        cellTiles[CellTypeEnum.Mountain] = (Resources.Load<TileBase>("Tiles/Ground/spr_secter_76"), Resources.Load<TileBase>("Tiles/Obstacles/spr_obstacles_33"));

        graphicSupport = new GraphicSupporter(cellTiles, resourceTiles, manyResourceTile);
        Drawer drawer = new Drawer(grid, mapPrefab);




    }

}
