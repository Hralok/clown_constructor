using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawer
{
    private struct TilemapGroup
    {
        public Tilemap groundTilemap;
        public Tilemap onGroundTilemap;
        public Tilemap resourcesTilemap;

        public TilemapGroup(Tilemap groungTilemap, Tilemap onGroundTilemap, Tilemap resourcesTilemap)
        {
            this.groundTilemap = groungTilemap;
            this.onGroundTilemap = onGroundTilemap;
            this.resourcesTilemap = resourcesTilemap;
        }
    }

    private Grid grid;
    private GameObject mapPrefab;
    private GraphicSupporter graphicSupport;
    private TileBase groundDebug;
    private TileBase resourceDebug;
    List<Map> maps = new List<Map>();
    private Dictionary<Map, TilemapGroup> mapTilemaps;


    public Drawer(Grid getGrid, GameObject prefab, GraphicSupporter supporter, List<Map> getMaps)
    {
        grid = getGrid;
        mapPrefab = prefab;
        graphicSupport = supporter;
        maps = getMaps;
        groundDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_0");
        resourceDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_1");

        foreach (Map map in maps)
        {
            if (!mapTilemaps.ContainsKey(map))
            {
                CreateMapGameObject(map);
            }
        }
    }

    public void CreateMapGameObject(Map map)
    {
        GameObject newMap = Object.Instantiate(mapPrefab, new Vector3Int(0, 0, 0), Quaternion.identity, grid.gameObject.transform);
        newMap.SetActive(false);
        newMap.name = map.name;
        Tilemap[] tilemaps = newMap.GetComponentsInChildren<Tilemap>();
        TilemapGroup tilemapGroup = new TilemapGroup(tilemaps[0], tilemaps[2], tilemaps[3]);
        mapTilemaps.Add(map, tilemapGroup);
        DrawMap(map);
    }

    public void DrawMap(Map map)
    {
        if (!mapTilemaps.ContainsKey(map))
        {
            throw new System.Exception("”казанна€ карта не инициализирована как GameObject");
        }
        TilemapGroup tilemaps = mapTilemaps[map];
        List<Cell> cells = map.GetAllCells();

        foreach (Cell cell in cells)
        {
            TileBase groundTile;
            TileBase ongroundTile;
            (groundTile, ongroundTile) = graphicSupport.GetTileByCellType(cell.type);
            if (groundTile == null)
            {
                tilemaps.groundTilemap.SetTile((Vector3Int)cell.coords, groundDebug);
                throw new System.Exception("ћестность, указанна€ в клетке с координатами " + cell.coords + " не обнаружена");
            }
            else
            {
                tilemaps.groundTilemap.SetTile((Vector3Int)cell.coords, groundTile);
                tilemaps.onGroundTilemap.SetTile((Vector3Int)cell.coords, ongroundTile);
            }

            DrawResource(cell, tilemaps);
        }
    }

    private void DrawResource(Cell cell, TilemapGroup tilemaps)
    {
        if (cell.resourcesAtCell.Count > 1)
        {
            tilemaps.resourcesTilemap.SetTile((Vector3Int)cell.coords, graphicSupport.manyResourceTile);
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
                        tilemaps.resourcesTilemap.SetTile((Vector3Int)cell.coords, resourceDebug);
                        throw new System.Exception("–есурс, указанный в клетке с координатами " + cell.coords + " не обнаружен");
                    }
                    else
                    {
                        tilemaps.resourcesTilemap.SetTile((Vector3Int)cell.coords, resourcesTile);
                    }
                }
            }
        }
    }

    private void DrawUnit(Cell cell, TilemapGroup tilemaps)
    {
        //ќтдельный метод  дл€ отрисовки unit
    }

    //‘ункци€ дл€ отрисовки единичной €чейки 
    //ёниту в конструктор закинуть €чейку
    public void DrawUnitIsDying(Unit unit)
    {

    }
}
