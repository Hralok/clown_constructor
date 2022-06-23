using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicSupporter
{
    protected Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles;
    //Первый на ground2Tilemap, второй на onGroundTilemap
    public TileBase globalFloor { get; private set; }
    public TileBase globalFloorCorner { get; private set; }
    public TileBase globalFloorShadow { get; private set; }
    //На groundTilemap
    protected Dictionary<ResourceTypeEnum, TileBase> resourceTiles;
    public TileBase manyResourceTile { get; private set; }

    public GraphicSupporter(
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles,
        TileBase globalFloor,
        TileBase globalFloorCorner,
        TileBase globalFloorShadow,
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles,
        TileBase manyResourceTile)
    {
        this.cellTiles = cellTiles;
        this.globalFloor = globalFloor;
        this.globalFloorCorner = globalFloorCorner;
        this.globalFloorShadow = globalFloorShadow;
        this.resourceTiles = resourceTiles;
        this.manyResourceTile = manyResourceTile;
    }

    public (TileBase, TileBase) GetTileByCellType(CellTypeEnum type)
    {
        return cellTiles.ContainsKey(type) ? cellTiles[type] : (null, null);
    }

    public TileBase GetTileByResourceType(ResourceTypeEnum type)
    {
        return resourceTiles.ContainsKey(type) ? resourceTiles[type] : null;
    }

    public GameObject GetAttackUnitAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeAttackPrefab");
    }

    public GameObject GetDeadUnitAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeDyingPrefab");
    }

    public TileBase GetAttackingUnitAnimatedTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_attacking");
    }

    public TileBase GetStayingUnitAnimatedTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_staying");
    }

    public TileBase GetDeadUnitTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/spr_mob_boss_19");
    }
}
