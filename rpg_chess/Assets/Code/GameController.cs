using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class GameController : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int currentPlayer;

    [SerializeField]
    Grid grid;
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    TileBase[] resourceTiles;

    [SerializeField]
    Sprite[] resourceSprites;

    [SerializeField]
    TileBase[] cellTiles1;
    [SerializeField]
    TileBase[] cellTiles2;

    [SerializeField]
    GameObject[] a;
    [SerializeField]
    TileBase[] b;
    [SerializeField]
    GameObject[] c;
    [SerializeField]
    TileBase[] d;
    [SerializeField]
    Sprite[] e;





    public void Start()
    {
        TileBase manyResourceTile = Resources.Load<TileBase>("Tiles/Special/Bonfire");
        TileBase globalFloor = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/StoneGlobal");
        TileBase globalFloorCornes = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/StoneGlobalCorner");
        TileBase globalFloorShadow = Resources.Load<TileBase>("Tiles/Special/GroundSpecialTiles/Shadow");

        var map = new Map("flyingIsland");
        GraphicSupporter.Init(globalFloor, globalFloorCornes, globalFloorShadow, manyResourceTile);
        Fabricator.Init();

        Fabricator.AddResourceInitInfo(new ResourceInitInfo(0, 0, resourceTiles[0], resourceSprites[0]));
        Fabricator.AddResourceInitInfo(new ResourceInitInfo(0, 0, resourceTiles[1], resourceSprites[1]));
        Fabricator.AddResourceInitInfo(new ResourceInitInfo(0, 0, resourceTiles[2], resourceSprites[2]));
        Fabricator.AddResourceInitInfo(new ResourceInitInfo(0, 0, resourceTiles[3], resourceSprites[3]));
        Fabricator.ResourcesInit();

        Fabricator.AddCellInitInfo(new CellInitInfo(0, 0, (cellTiles1[0], cellTiles2[0])));
        Fabricator.AddCellInitInfo(new CellInitInfo(0, 0, (cellTiles1[1], cellTiles2[1])));
        Fabricator.AddCellInitInfo(new CellInitInfo(0, 0, (cellTiles1[2], cellTiles2[2])));
        Fabricator.CellsInit();

        Fabricator.ActiveAbilitysInit();
        Fabricator.ItemsInit();

        Fabricator.AddEntityInitInfo(new UnitInitInfo(
            1,
            1,
            1,
            new HashSet<EntityTypeEnum>() { EntityTypeEnum.Leaving },
            0,
            0,
            0,
            0,
            new Dictionary<DamageTypeEnum, double>(),
            new Dictionary<DamageTypeEnum, double>(),
            new Dictionary<HealTypeEnum, double>(),
            new Dictionary<HealTypeEnum, double>(),
            new Dictionary<AttackTypeEnum, double>(),
            new Dictionary<AttackTypeEnum, double>(),
            0,
            DefenseTypeEnum.Building,
            new List<ActiveAbilityInSomewhere>(),
            0,
            new Dictionary<MainCharacteristicTypeEnum, double>(),
            5,
            0,
            a[0],
            b[0],
            c[0],
            d[0],
            e[0]
            ));

        Fabricator.EntitiesInit();

        Fabricator.CreateCell(0, new Vector2Int(0, 0), map);
        Fabricator.CreateCell(1, new Vector2Int(0, 1), map);
        Fabricator.CreateCell(2, new Vector2Int(0, 2), map);
        Fabricator.CreateCell(0, new Vector2Int(0, 3), map);
        Fabricator.CreateCell(1, new Vector2Int(1, 0), map);
        Fabricator.CreateCell(2, new Vector2Int(1, 1), map);
        Fabricator.CreateCell(0, new Vector2Int(1, 2), map);
        Fabricator.CreateCell(1, new Vector2Int(1, 3), map);
        Fabricator.CreateCell(2, new Vector2Int(2, 0), map);
        Fabricator.CreateCell(0, new Vector2Int(2, 1), map);
        Fabricator.CreateCell(1, new Vector2Int(2, 2), map);
        Fabricator.CreateCell(2, new Vector2Int(2, 3), map);
        Fabricator.CreateCell(0, new Vector2Int(3, 0), map);
        Fabricator.CreateCell(1, new Vector2Int(3, 1), map);
        Fabricator.CreateCell(2, new Vector2Int(3, 2), map);
        Fabricator.CreateCell(0, new Vector2Int(3, 3), map);

        Player test = new Player();

        Fabricator.CreateEntity(0, test, map.GetCell(new Vector2Int(1, 2)));
        Fabricator.CreateEntity(0, test, map.GetCell(new Vector2Int(3, 2)));
        Fabricator.CreateEntity(0, test, map.GetCell(new Vector2Int(0, 0)));


        List<Map> maps = new List<Map>();
        maps.Add(map);
        Drawer drawer = new Drawer(grid, prefab, maps);
    }
}
