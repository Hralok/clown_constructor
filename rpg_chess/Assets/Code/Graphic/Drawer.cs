using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawer
{
    public struct TilemapGroup
    {
        public Tilemap groundTilemap;
        public Tilemap roadTilemap;
        public Tilemap onGroundTilemap;
        public Tilemap resourcesTilemap;
        public Tilemap itemsTilemap;
        public Tilemap structuresTilemap;
        public Tilemap deadBodiesTilemap;
        public Tilemap creaturesTilemap;

        public TilemapGroup(Tilemap groundTilemap, Tilemap roadTilemap, Tilemap onGroundTilemap,
            Tilemap resourcesTilemap, Tilemap itemsTilemap, Tilemap structuresTilemap,
            Tilemap deadBodiesTilemap, Tilemap creaturesTilemap)
        {
            this.groundTilemap = groundTilemap;
            this.roadTilemap = roadTilemap;
            this.onGroundTilemap = onGroundTilemap;
            this.resourcesTilemap = resourcesTilemap;
            this.itemsTilemap = itemsTilemap;
            this.structuresTilemap = structuresTilemap;
            this.deadBodiesTilemap = deadBodiesTilemap;
            this.creaturesTilemap = creaturesTilemap;
        }
    }

    private Grid grid;
    private GameObject mapPrefab;
    private GraphicSupporter graphicSupport;
    private TileBase groundDebug;
    private TileBase resourceDebug;
    private TileBase unitDebug;
    List<Map> maps = new List<Map>();
    private Dictionary<Map, TilemapGroup> mapTilemaps;

    public Drawer(Grid getGrid, GameObject prefab, GraphicSupporter supporter, List<Map> getMaps)
    {
        grid = getGrid;
        mapPrefab = prefab;
        graphicSupport = supporter;
        maps = getMaps;
        mapTilemaps = new Dictionary<Map, TilemapGroup>();
        groundDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_0");
        resourceDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_1");
        unitDebug = Resources.Load<TileBase>("Tiles/Debug/spr_debug_2");

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
        //newMap.SetActive(false);
        newMap.name = map.name;
        Tilemap[] tilemaps = newMap.GetComponentsInChildren<Tilemap>();
        TilemapGroup tilemapGroup = new TilemapGroup(tilemaps[0], tilemaps[1], tilemaps[2], tilemaps[3], tilemaps[4], tilemaps[5], tilemaps[6], tilemaps[7]);
        mapTilemaps.Add(map, tilemapGroup);
        DrawMap(map);
    }

    public void DrawMap(Map map)
    {
        if (!mapTilemaps.ContainsKey(map))
        {
            throw new System.Exception("Указанная карта не инициализирована как GameObject");
        }
        TilemapGroup tilemaps = mapTilemaps[map];
        HashSet<Cell> cells = map.GetAllCells();

        foreach (Cell cell in cells)
        {
            DrawCell(cell, tilemaps);
            DrawResource(cell, tilemaps);
            DrawUnit(cell, tilemaps);
        }
    }

    public void DrawCell(Cell cell, TilemapGroup tilemaps)
    {
        TileBase groundTile;
        TileBase ongroundTile;
        (groundTile, ongroundTile) = graphicSupport.GetTileByCellType(cell.type);
        if (groundTile == null)
        {
            tilemaps.groundTilemap.SetTile((Vector3Int)cell.coords, groundDebug);
            throw new System.Exception("Местность, указанная в клетке с координатами " + cell.coords + " не обнаружена");
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tilemaps.groundTilemap.SetTile(new Vector3Int(cell.coords.x * 4 + i, cell.coords.y * 4 + j, 0), groundTile);
                    tilemaps.onGroundTilemap.SetTile(new Vector3Int(cell.coords.x * 4 + i, cell.coords.y * 4 + j, 0), ongroundTile);
                }
            }
        }
    }

    public void DrawResource(Cell cell, TilemapGroup tilemaps)
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
                        throw new System.Exception("Ресурс, указанный в клетке с координатами " + cell.coords + " не обнаружен");
                    }
                    else
                    {
                        tilemaps.resourcesTilemap.SetTile((Vector3Int)cell.coords, resourcesTile);
                    }
                }
            }
        }
    }

    public void DrawUnit(Cell cell, TilemapGroup tilemaps)
    {
        if (cell.unitAtCell != null)
        {
            TileBase unitTile;
            unitTile = graphicSupport.GetStayingUnitAnimatedTile();

            if (unitTile == null)
            {
                tilemaps.creaturesTilemap.SetTile((Vector3Int)cell.coords, unitDebug);
                throw new System.Exception("Юнит, указанный в клетке с координатами " + cell.coords + " не обнаружен");
            }
            else
            {
                tilemaps.creaturesTilemap.SetTile((Vector3Int)cell.coords, unitTile);
            }
        }
    }

    public void DrawUnitIsBusyAttacking(Unit unit)
    {
        TilemapGroup tilemapGroup;
        tilemapGroup = mapTilemaps[unit.currentCell.relatedMap];

        TileBase unitTile;
        unitTile = graphicSupport.GetAttackingUnitAnimatedTile();

        if (unitTile == null)
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitDebug);
            throw new System.Exception("Юнит, указанный в клетке с координатами " + unit.currentCell.coords + " не обнаружен");
        }
        else
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, null);
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitTile);
        }
    }

    public void DrawUnitIsOnceAttacking(Unit unit)
    {
        TilemapGroup tilemapGroup;
        tilemapGroup = mapTilemaps[unit.currentCell.relatedMap];

        GameObject AttackAnimation;
        AttackAnimation = graphicSupport.GetAttackUnitAnimation();

        if (AttackAnimation == null)
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitDebug);
            throw new System.Exception("Юнит, указанный в клетке с координатами " + unit.currentCell.coords + " не обнаружен");
        }
        else
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, null);
            GameObject UnitAttackHelper = Object.Instantiate(AttackAnimation, (Vector3Int)unit.currentCell.coords, Quaternion.identity, grid.gameObject.transform);
            var UnitAttack = UnitAttackHelper.transform.GetChild(0).gameObject;
            var UnitScript = UnitAttack.GetComponent<UnitAfterAnimationSupporter>();
            UnitScript.coords = (Vector3Int)unit.currentCell.coords;
            UnitScript.targetTilemap = tilemapGroup.creaturesTilemap;
            UnitScript.replacementTile = graphicSupport.GetStayingUnitAnimatedTile();
        }
    }

    public void DrawUnitIsDying(Unit unit)
    {
        TilemapGroup tilemapGroup;
        tilemapGroup = mapTilemaps[unit.currentCell.relatedMap];

        GameObject dyingAnimation;
        dyingAnimation = graphicSupport.GetDeadUnitAnimation();
        if (dyingAnimation == null)
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitDebug);
            throw new System.Exception("Юнит, указанный в клетке с координатами " + unit.currentCell.coords + " не обнаружен");
        }
        else
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, null);
            GameObject UnitDieHelper = Object.Instantiate(dyingAnimation, (Vector3Int)unit.currentCell.coords, Quaternion.identity, grid.gameObject.transform);
            var UnitDie = UnitDieHelper.transform.GetChild(0).gameObject;
            var UnitScript = UnitDie.GetComponent<UnitAfterAnimationSupporter>();
            UnitScript.replacementTile = graphicSupport.GetDeadUnitTile();
            UnitScript.coords = (Vector3Int)unit.currentCell.coords;
            UnitScript.targetTilemap = tilemapGroup.deadBodiesTilemap;
        }
    }
}
