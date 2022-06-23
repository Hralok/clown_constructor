using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class GraphicSupporter
{
    private static Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles;
    //Первый на ground2Tilemap, второй на onGroundTilemap
    private static TileBase globalFloor;
    private static TileBase globalFloorCorner;
    private static TileBase globalFloorShadow;
    //На groundTilemap
    private static Dictionary<ResourceTypeEnum, TileBase> resourceTiles;
    private static TileBase manyResourceTile;

    private static bool initialized = false;

    public static void Init(
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles,
        TileBase globalFloor,
        TileBase globalFloorCorner,
        TileBase globalFloorShadow,
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles,
        TileBase manyResourceTile)
    {
        initialized = true;

        GraphicSupporter.globalFloor = globalFloor;
        GraphicSupporter.cellTiles = cellTiles;
        GraphicSupporter.resourceTiles = resourceTiles;
        GraphicSupporter.manyResourceTile = manyResourceTile;
	GraphicSupporter.globalFloorCorner = globalFloorCorner;
        GraphicSupporter.globalFloorShadow = globalFloorShadow;
    }
    public static (TileBase, TileBase) GetTileByCellType(CellTypeEnum type)
    {
	if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return cellTiles.ContainsKey(type) ? cellTiles[type] : (null, null);
    }

    public static TileBase GetTileByResourceType(ResourceTypeEnum type)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return resourceTiles.ContainsKey(type) ? resourceTiles[type] : null;
    }

    public static TileBase GetManyResourceTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return manyResourceTile;
    }

    public static TileBase GetGlobalFloor()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return globalFloor;
    }

    public static TileBase GetGlobalFloorCorner()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return globalFloorCorner;
    }

    public static TileBase GetGlobalFloorShadow()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return globalFloorShadow;
    }

    public static GameObject GetAttackUnitAnimation()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeAttackPrefab");
    }

    public static GameObject GetDeadUnitAnimation()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeDyingPrefab");
    }

    public static TileBase GetAttackingUnitAnimatedTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_attacking");
    }

    public static TileBase GetStayingUnitAnimatedTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_staying");
    }

    public static TileBase GetDeadUnitTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/spr_mob_boss_19");
    }
}
