using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class GraphicSupporter
{
    private static Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles;
    //Первый на ground2Tilemap, второй на onGroundTilemap
    private static TileBase globalFloor;
    //На groundTilemap
    private static Dictionary<ResourceTypeEnum, TileBase> resourceTiles;
    private static TileBase manyResourceTile;

    private static bool initialized = false;

    public static void Init(
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles,
        TileBase globalFloor,
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles,
        TileBase manyResourceTile)
    {
        initialized = true;

        GraphicSupporter.globalFloor = globalFloor;
        GraphicSupporter.cellTiles = cellTiles;
        GraphicSupporter.resourceTiles = resourceTiles;
        GraphicSupporter.manyResourceTile = manyResourceTile;
    }

    public static (TileBase, TileBase, TileBase) GetTileByCellType(CellTypeEnum type)
    {
        return cellTiles.ContainsKey(type) ? (globalFloor, cellTiles[type].Item1, cellTiles[type].Item2) : (null, null, null);
    }

    public static TileBase GetTileByResourceType(ResourceTypeEnum type)
    {
        return resourceTiles.ContainsKey(type) ? resourceTiles[type] : null;
    }

    public static TileBase GetManyResourceTile()
    {
        return manyResourceTile;
    }

    public static GameObject GetAttackUnitAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeAttackPrefab");
    }

    public static GameObject GetDeadUnitAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeDyingPrefab");
    }

    public static TileBase GetAttackingUnitAnimatedTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_attacking");
    }

    public static TileBase GetStayingUnitAnimatedTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_staying");
    }

    public static TileBase GetDeadUnitTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/spr_mob_boss_19");
    }
}
