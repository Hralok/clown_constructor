using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawer
{
    public struct TilemapGroup
    {
        public Tilemap groundShadowTilemap;
        public Tilemap groundTilemap;
        public Tilemap ground2Tilemap;
        public Tilemap roadTilemap;
        public Tilemap onGroundTilemap;
        public Tilemap resourcesTilemap;
        public Tilemap itemsTilemap;
        public Tilemap structuresTilemap;
        public Tilemap deadBodiesTilemap;
        public Tilemap creaturesTilemap;

        public TilemapGroup(Tilemap groundShadowTilemap, Tilemap groundTilemap, Tilemap ground2Tilemap, Tilemap roadTilemap, Tilemap onGroundTilemap,
            Tilemap resourcesTilemap, Tilemap itemsTilemap, Tilemap structuresTilemap,
            Tilemap deadBodiesTilemap, Tilemap creaturesTilemap)
        {
            this.groundShadowTilemap = groundShadowTilemap;
            this.groundTilemap = groundTilemap;
            this.ground2Tilemap = ground2Tilemap;
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
    private TileBase groundDebug;
    private TileBase resourceDebug;
    private TileBase unitDebug;
    List<Map> maps = new List<Map>();
    private Dictionary<Map, TilemapGroup> mapTilemaps;

    public Drawer(Grid getGrid, GameObject prefab, List<Map> getMaps)
    {
        grid = getGrid;
        mapPrefab = prefab;
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
        newMap.name = map.name;
        Tilemap[] tilemaps = newMap.GetComponentsInChildren<Tilemap>();
        TilemapGroup tilemapGroup = new TilemapGroup(tilemaps[0], tilemaps[1], tilemaps[2], tilemaps[3], tilemaps[4], tilemaps[5], tilemaps[6], tilemaps[7], tilemaps[8], tilemaps[9]);
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
        TileBase ground2Tile;
        TileBase ongroundTile;
        (ground2Tile, ongroundTile) = GraphicSupporter.GetTileByCellType(cell.type);
        if (ground2Tile == null)
        {
            tilemaps.groundTilemap.SetTile((Vector3Int)cell.coords, groundDebug);
            throw new System.Exception("Местность, указанная в клетке с координатами " + cell.coords + " не обнаружена");
        }
        else
        {
            bool downEmptyCheck = false;

            if (!cell.relatedMap.DoesCellExist(new Vector2Int(cell.coords.x, cell.coords.y - 1)))
            {
                downEmptyCheck = true;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tilemaps.groundTilemap.SetTile(new Vector3Int(cell.coords.x * 4 + i, cell.coords.y * 4 + j, 0), GraphicSupporter.GetGlobalFloor());
                    tilemaps.ground2Tilemap.SetTile(new Vector3Int(cell.coords.x * 4 + i, cell.coords.y * 4 + j, 0), ground2Tile);
                }
            }

            if (!cell.relatedMap.DoesCellExist(new Vector2Int(cell.coords.x + 1, cell.coords.y))) //клетка справа
            {
                var start = 0;
                var n = 4;
                if (!cell.relatedMap.DoesCellExist(new Vector2Int(cell.coords.x, cell.coords.y + 1))) //клетка сверху
                {
                    n = 3;
                }
                if (downEmptyCheck)
                {
                    start = -1;
                }

                for (int j = start; j < n; j++)
                {

                    tilemaps.groundShadowTilemap.SetTile(new Vector3Int(cell.coords.x * 4 + 4, cell.coords.y * 4 + j, 0), GraphicSupporter.GetGlobalFloorShadow());
                }
            }

            if (downEmptyCheck)
            {
                TileBase floorCorner = GraphicSupporter.GetGlobalFloorCorner();
                for (int i = 0; i < 4; i++)
                {
                    tilemaps.ground2Tilemap.SetTile(new Vector3Int(cell.coords.x * 4 + i, cell.coords.y * 4 - 1, 0), floorCorner);
                }

                //наличие нижних диагональных углов
                if (cell.relatedMap.DoesCellExist(new Vector2Int(cell.coords.x - 1, cell.coords.y - 1)))
                {
                    tilemaps.ground2Tilemap.SetTile(new Vector3Int(cell.coords.x * 4, cell.coords.y * 4 - 2, 0), floorCorner);
                }
                if (cell.relatedMap.DoesCellExist(new Vector2Int(cell.coords.x + 1, cell.coords.y - 1)))
                {
                    tilemaps.ground2Tilemap.SetTile(new Vector3Int(cell.coords.x * 4 + 3, cell.coords.y * 4 - 2, 0), floorCorner);
                }
            }
            tilemaps.onGroundTilemap.SetTile(new Vector3Int(cell.coords.x, cell.coords.y, 0), ongroundTile);
            downEmptyCheck = false;
        }
    }

    public void DrawResource(Cell cell, TilemapGroup tilemaps)
    {
        if (cell.resourcesAtCell.Count > 1)
        {
            tilemaps.resourcesTilemap.SetTile((Vector3Int)cell.coords, GraphicSupporter.GetManyResourceTile());
        }
        else
        {
            if (cell.resourcesAtCell.Count == 1)
            {
                foreach (Resource resource in cell.resourcesAtCell)
                {
                    TileBase resourcesTile;
                    resourcesTile = GraphicSupporter.GetTileByResourceType(resource.type);
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
            unitTile = GraphicSupporter.GetStayingUnitAnimatedTile();

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
        unitTile = GraphicSupporter.GetAttackingUnitAnimatedTile();

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
        AttackAnimation = GraphicSupporter.GetAttackUnitAnimation();

        if (AttackAnimation == null)
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitDebug);
            throw new System.Exception("Юнит, указанный в клетке с координатами " + unit.currentCell.coords + " не обнаружен");
        }
        else
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, null);
            GameObject UnitAttackHelper = Object.Instantiate(AttackAnimation, (Vector3Int)unit.currentCell.coords, Quaternion.identity, tilemapGroup.creaturesTilemap.transform);
            var UnitAttack = UnitAttackHelper.transform.GetChild(0).gameObject;
            var UnitScript = UnitAttack.GetComponent<UnitAfterAnimationSupporter>();
            UnitScript.coords = (Vector3Int)unit.currentCell.coords;
            UnitScript.targetTilemap = tilemapGroup.creaturesTilemap;
            UnitScript.replacementTile = GraphicSupporter.GetStayingUnitAnimatedTile();
        }
    }

    public void DrawUnitIsDying(Unit unit)
    {
        TilemapGroup tilemapGroup;
        tilemapGroup = mapTilemaps[unit.currentCell.relatedMap];

        GameObject dyingAnimation;
        dyingAnimation = GraphicSupporter.GetDeadUnitAnimation();
        if (dyingAnimation == null)
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, unitDebug);
            throw new System.Exception("Юнит, указанный в клетке с координатами " + unit.currentCell.coords + " не обнаружен");
        }
        else
        {
            tilemapGroup.creaturesTilemap.SetTile((Vector3Int)unit.currentCell.coords, null);
            GameObject UnitDieHelper = Object.Instantiate(dyingAnimation, (Vector3Int)unit.currentCell.coords, Quaternion.identity, tilemapGroup.creaturesTilemap.transform);
            var UnitDie = UnitDieHelper.transform.GetChild(0).gameObject;
            var UnitScript = UnitDie.GetComponent<UnitAfterAnimationSupporter>();
            UnitScript.replacementTile = GraphicSupporter.GetDeadUnitTile();
            UnitScript.coords = (Vector3Int)unit.currentCell.coords;
            UnitScript.targetTilemap = tilemapGroup.deadBodiesTilemap;
        }
    }

    public void DrawAbility(Map map, Vector2Int coords)
    {
        TilemapGroup tilemapGroup;
        tilemapGroup = mapTilemaps[map];

        GameObject abilityAnimation;
        abilityAnimation = GraphicSupporter.GetAbilityAnimation();

        if (abilityAnimation == null)
        {
            throw new System.Exception("Способность, направленная на клетку с координатами " + coords + " не обнаружена");
        }
        else
        {
            Object.Instantiate(abilityAnimation, (Vector3Int)coords, Quaternion.identity, tilemapGroup.creaturesTilemap.transform);
        }
    }

}
