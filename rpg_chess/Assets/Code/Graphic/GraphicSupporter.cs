using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class GraphicSupporter
{
    private static Dictionary<int, (TileBase, TileBase)> cellTiles;
    //������ �� ground2Tilemap, ������ �� onGroundTilemap
    private static TileBase globalFloor;
    private static TileBase globalFloorCorner;
    private static TileBase globalFloorShadow;
    //�� groundTilemap
    private static Dictionary<int, (TileBase, Sprite)> resourceTiles;
    private static TileBase manyResourceTile;

    private static bool initialized = false;

    private static Dictionary<int, (GameObject, TileBase, GameObject, TileBase, Sprite)> unitGraphic;

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
        unitGraphic = new Dictionary<int, (GameObject, TileBase, GameObject, TileBase, Sprite)>();

        GraphicSupporter.manyResourceTile = manyResourceTile;
        GraphicSupporter.globalFloor = globalFloor;
        GraphicSupporter.globalFloorCorner = globalFloorCorner;
        GraphicSupporter.globalFloorShadow = globalFloorShadow;
    }


    //Cell
    public static (TileBase, TileBase) GetTileByCellTypeId(int typeId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return cellTiles.ContainsKey(typeId) ? cellTiles[typeId] : (null, null);
    }

    public static void AddCellTile(int cellTypeId, TileBase tile, TileBase tile2)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        if (Fabricator.cellsInitialized)
        {
            throw new System.Exception("������ ��� ����������������, ���������� ����� ����������!");
        }

        cellTiles[cellTypeId] = (tile, tile2);
        //
        // ����� ���������� ���������� tile � tile2 ����� ����������� ��������������!
        //
    }


    //Resource
    public static TileBase GetTileByResourceId(int resourceId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return resourceTiles.ContainsKey(resourceId) ? resourceTiles[resourceId].Item1 : null;
    }

    public static Sprite GetSpriteByResourceId(int resourceId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return resourceTiles.ContainsKey(resourceId) ? resourceTiles[resourceId].Item2 : null;
    }

    public static void AddResourceGraphic(int resourceId, TileBase tile, Sprite sprite)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        if (Fabricator.resourcesInitialized)
        {
            throw new System.Exception("������� ��� ����������������, ���������� ����� ����������!");
        }
        resourceTiles[resourceId] = (tile, sprite);
    }

    public static TileBase GetManyResourceTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return manyResourceTile;
    }


    //���������� ���
    public static TileBase GetGlobalFloor()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return globalFloor;
    }

    public static TileBase GetGlobalFloorCorner()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return globalFloorCorner;
    }

    public static TileBase GetGlobalFloorShadow()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return globalFloorShadow;
    }


    //Unit
    public static GameObject GetAttackUnitAnimation(int unitId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return unitGraphic[unitId].Item1;
    }
    public static TileBase GetAttackingUnitAnimatedTile(int unitId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return unitGraphic[unitId].Item2;
    }

    public static GameObject GetDeadUnitAnimation(int unitId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return unitGraphic[unitId].Item3;
    }

    public static TileBase GetStayingUnitAnimatedTile(int unitId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return unitGraphic[unitId].Item4;
    }

    public static Sprite GetUnitPortrait(int unitId)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return unitGraphic[unitId].Item5;
    }

    public static void AddUnitGraphic(int unitId, GameObject attack, TileBase attacking, GameObject dying, TileBase staying, Sprite portrait)
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        //if (Fabricator.resourcesInitialized)
        //{
        //    throw new System.Exception("������� ��� ����������������, ���������� ����� ����������!");
        //}
        unitGraphic[unitId] = (attack, attacking, dying, staying, portrait);
    }


    //Corpse
    public static TileBase GetDeadUnitTile()
    {
        if (!initialized)
        {
            throw new System.Exception("Drawer �� ��������������� ����� ��������������!");
        }
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/spr_mob_boss_19");
    }


    //Ability
    public static GameObject GetAbilityAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Abilities/AttackAbility");
    }
}
