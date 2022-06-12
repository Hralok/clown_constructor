using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicSupporter
{
    protected Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles; 
    protected Dictionary<ResourceTypeEnum, TileBase> resourceTiles;
    public TileBase manyResourceTile { get; private set; }

    public GraphicSupporter(
        Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles, 
        Dictionary<ResourceTypeEnum, TileBase> resourceTiles,
        TileBase manyResourceTile)
    {
        this.cellTiles = cellTiles;
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
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeAttack");
    }

    public GameObject GetDeadUnitAnimation()
    {
        return Resources.Load<GameObject>("Prefabs/Snake/SnakeDyingPrefab");
    }

    public AnimatedTile GetAttackingUnitAnimatedTile()
    {
        return Resources.Load<AnimatedTile>("Tiles/Creatures/Snake/Snake_attacking");
    }

    public AnimatedTile GetStayingUnitAnimatedTile()
    {
        return Resources.Load<AnimatedTile>("Tiles/Creatures/Snake/Snake_staying");
    }

    public TileBase GetDeadUnitTile()
    {
        return Resources.Load<TileBase>("Tiles/Creatures/Snake/spr_mob_boss_19");
    }
}
