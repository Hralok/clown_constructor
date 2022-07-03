using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class GraphicSupporter
{
    private static Dictionary<int, (TileBase, TileBase)> cellTiles;
    //Первый на ground2Tilemap, второй на onGroundTilemap
    private static TileBase globalFloor;
    private static TileBase globalFloorCorner;
    private static TileBase globalFloorShadow;
    //На groundTilemap
    private static Dictionary<int, (TileBase, Sprite)> resourceTiles;
    private static TileBase manyResourceTile;

    private static bool initialized = false;

    public static void Init(
        TileBase globalFloor,
        TileBase globalFloorCorner,
        TileBase globalFloorShadow,
        TileBase manyResourceTile
        )
    {
        initialized = true;

        cellTiles = new Dictionary<int, (TileBase, TileBase)>();
        resourceTiles = new Dictionary<int, (TileBase, Sprite)>();
        GraphicSupporter.manyResourceTile = manyResourceTile;
        GraphicSupporter.globalFloor = globalFloor;
        GraphicSupporter.globalFloorCorner = globalFloorCorner;
        GraphicSupporter.globalFloorShadow = globalFloorShadow;
    }
    public static (TileBase, TileBase) GetTileByCellTypeId(int typeId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return cellTiles.ContainsKey(typeId) ? cellTiles[typeId] : (null, null);
    }

    public static void AddCellTile(int cellTypeId, TileBase tile, TileBase tile2)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        if (Fabricator.cellsInitialized)
        {
            throw new System.Exception("Ячейки уже инициализированы, добавление новых невозможно!");
        }

        cellTiles[cellTypeId] = (tile, tile2);
        //
        // Настя переназови переменные tile и tile2 более подходящими наименованиями!
        //
    }



    public static TileBase GetTileByResourceId(int resourceId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return resourceTiles.ContainsKey(resourceId) ? resourceTiles[resourceId].Item1 : null;
    }

    public static Sprite GetSpriteByResourceId(int resourceId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return resourceTiles.ContainsKey(resourceId) ? resourceTiles[resourceId].Item2 : null;
    }

    public static void AddResourceGraphic(int resourceId, TileBase tile, Sprite sprite)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        if (Fabricator.resourcesInitialized)
        {
            throw new System.Exception("Ресурсы уже инициализированы, добавление новых невозможно!");
        }
        resourceTiles[resourceId] = (tile, sprite);
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
    public static TileBase GetAttackingUnitAnimatedTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/Snake_attacking");
    }

    public static GameObject GetDeadUnitAnimation()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer не инициализирован перед использованием!");
        }
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeDyingPrefab");
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

    public static GameObject GetAbilityAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Abilities/AttackAbility");
    }
}
