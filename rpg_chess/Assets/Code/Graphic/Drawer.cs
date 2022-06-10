using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawer
{
    //Получать объект grid
    private Grid grid;
    private GameObject mapPrefab;

    private GraphicSupporter graphicSupport;
    public Drawer(Grid getGrid, GameObject prefab)
    {
        grid = getGrid;
        mapPrefab = prefab;
        Object.Instantiate(mapPrefab, new Vector3Int(0, 0, 0), Quaternion.identity, grid.gameObject.transform);
    }

    public void DrawMap()
    {

        /*        foreach (Cell cell in cells)
                {
                    TileBase groundTile;
                    TileBase ongroundTile;
                    (groundTile, ongroundTile) = graphicSupport.GetTileByCellType(cell.type);
                    if (groundTile == null)
                    {
                        groundTilemap.SetTile((Vector3Int)cell.coords, Resources.Load<TileBase>("Tiles/Debug/spr_debug_0"));
                        throw new System.Exception("Местность, указанная в клетке с координатами" + cell.coords + "не обнаружена");
                        //Отрисовать тут в клетке что нет такого
                    }
                    else
                    {
                        groundTilemap.SetTile((Vector3Int)cell.coords, groundTile);
                        ongroundTilemap.SetTile((Vector3Int)cell.coords, ongroundTile);
                    }


                    if (cell.resourcesAtCell.Count > 1)
                    {
                        resourcesTilemap.SetTile((Vector3Int)cell.coords, manyResourceTile);
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
                                    resourcesTilemap.SetTile((Vector3Int)cell.coords, Resources.Load<TileBase>("Tiles/Debug/spr_debug_1"));
                                    throw new System.Exception("Ресурс, указанный в клетке с координатами" + cell.coords + "не обнаружен");
                                }
                                else
                                {
                                    resourcesTilemap.SetTile((Vector3Int)cell.coords, resourcesTile);
                                }
                            }
                        }
                        //hashset взять ресурс и отрисовать его
                    }
                }*/
    }
}
