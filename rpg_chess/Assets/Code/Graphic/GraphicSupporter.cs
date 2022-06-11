using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicSupporter
{
    protected Dictionary<CellTypeEnum, (TileBase, TileBase)> cellTiles; 
    //Первый тайл на ground, второй на onground 
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

}
