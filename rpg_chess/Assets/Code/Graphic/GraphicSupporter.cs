using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicSupporter
{
    protected Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles;
    //Первый на ground2Tilemap, второй на onGroundTilemap
    protected TileBase globalFloor;
    //На groundTilemap
    protected Dictionary<ResourceTypeEnum, TileBase> resourceTiles;
    public TileBase manyResourceTile { get; private set; }

    public GraphicSupporter(
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles,
        TileBase globalFloor,
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles,
        TileBase manyResourceTile)
    {
        this.globalFloor = globalFloor;
        this.cellTiles = cellTiles;
        this.resourceTiles = resourceTiles;
        this.manyResourceTile = manyResourceTile;
    }

    public (TileBase, TileBase, TileBase) GetTileByCellType(CellTypeEnum type)
    {
        return cellTiles.ContainsKey(type) ? (globalFloor, cellTiles[type].Item1, cellTiles[type].Item2) : (null, null, null);
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
