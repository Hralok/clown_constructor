using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicSupport
{
    protected Dictionary<CellTypeEnum, Tile> cellTiles;
    protected Dictionary<ResourceTypeEnum, Tile> resourceTiles;
    public Tile manyResourceTile { get; private set; }

    public GraphicSupport(
        Dictionary<CellTypeEnum, Tile> cellTiles, 
        Dictionary<ResourceTypeEnum, Tile> resourceTiles,
        Tile manyResourceTile)
    {
        this.cellTiles = cellTiles;
        this.resourceTiles = resourceTiles;
        this.manyResourceTile = manyResourceTile;
    }

    public Tile GetTileByCellType(CellTypeEnum type)
    {
        return cellTiles.ContainsKey(type) ? cellTiles[type] : null;
    }

    public Tile GetTileByResourceType(ResourceTypeEnum type)
    {
        return resourceTiles.ContainsKey(type) ? resourceTiles[type] : null;
    }

}
