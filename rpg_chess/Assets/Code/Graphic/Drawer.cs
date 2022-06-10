using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawer
{
    private Grid grid;
    private GameObject mapPrefab;
    private GraphicSupporter graphicSupport;
    private TileBase groundDebug;
    private TileBase resourceDebug;

    public Drawer(Grid getGrid, GameObject prefab, GraphicSupporter supporter)
    {
        grid = getGrid;
        mapPrefab = prefab;
        graphicSupport = supporter;
        groundDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_0");
        resourceDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_1");
    }

    public void DrawMap(Map map)
    {
        List<Cell> cells = map.GetAllCells();
        mapPrefab.name = map.name;
        GameObject newMap = Object.Instantiate(mapPrefab, new Vector3Int(0, 0, 0), Quaternion.identity, grid.gameObject.transform);
        Tilemap[] tilemaps = newMap.GetComponentsInChildren<Tilemap>();

        foreach (Cell cell in cells)
        {
            TileBase groundTile;
            TileBase ongroundTile;
            (groundTile, ongroundTile) = graphicSupport.GetTileByCellType(cell.type);
            if (groundTile == null)
            {
                tilemaps[0].SetTile((Vector3Int)cell.coords, groundDebug);
                throw new System.Exception("Местность, указанная в клетке с координатами " + cell.coords + " не обнаружена");
            }
            else
            {
                tilemaps[0].SetTile((Vector3Int)cell.coords, groundTile);
                tilemaps[2].SetTile((Vector3Int)cell.coords, ongroundTile);
            }

            if (cell.resourcesAtCell.Count > 1)
            {
                tilemaps[3].SetTile((Vector3Int)cell.coords, graphicSupport.manyResourceTile);
            }
            else
            {
                if (cell.resourcesAtCell.Count == 1)
                {
                    foreach (Resource resource in cell.resourcesAtCell)
                    {
                        TileBase resourcesTile;
                        resourcesTile = graphicSupport.GetTileByResourceType(resource.type);
                        if (resourcesTile == null)
                        {
                            tilemaps[3].SetTile((Vector3Int)cell.coords, resourceDebug);
                            throw new System.Exception("Ресурс, указанный в клетке с координатами " + cell.coords + " не обнаружен");
                        }
                        else
                        {
                            tilemaps[3].SetTile((Vector3Int)cell.coords, resourcesTile);
                        }
                    }
                }
            }
        }
    }
}
