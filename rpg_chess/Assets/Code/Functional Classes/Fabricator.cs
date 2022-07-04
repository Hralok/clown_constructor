using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabricator
{

    private static Dictionary<int, ResourceInitInfo> resourceInitInfo;
    private static Dictionary<int, CellInitInfo> cellsInitInfo;

    private static Dictionary<int, ItemInitInfo> itemsInitInfo;
    private static Dictionary<int, EntityInitInfo> entitiesInitInfo;

    private static Dictionary<int, ActiveAbility> activeAbilities;









    public static int currentLastResourceId { get; private set; } = -1;
    public static int currentLastCellId { get; private set; } = -1;
    public static int currentLastItemId { get; private set; } = -1;
    public static int currentLastActiveAbilityId { get; private set; } = -1;


    public static bool initialized { get; private set; } = false;
    public static bool resourcesInitialized { get; private set; } = false;
    public static bool cellsInitialized { get; private set; } = false;
    public static bool itemsInitialized { get; private set; } = false;
    public static bool activeAbilitiesInitialized { get; private set; } = false;


    public static bool damageTypesInitialized { get; private set; } = false;
    public static bool healTypesInitialized { get; private set; } = false;
    public static bool defenceTypesInitialized { get; private set; } = false;
    public static bool entitiesInitialized { get; private set; } = false;

    public static void Init()
    {
        if (initialized)
        {
            throw new System.Exception("Fabricator ��� ���������������!");
        }
        resourceInitInfo = new Dictionary<int, ResourceInitInfo>();
        cellsInitInfo = new Dictionary<int, CellInitInfo>();
        itemsInitInfo = new Dictionary<int, ItemInitInfo>();
        entitiesInitInfo = new Dictionary<int, EntityInitInfo>();
        activeAbilities = new Dictionary<int, ActiveAbility>();
        initialized = true;
    }


    public static bool IsInitialized()
    {
        return initialized &&
            resourcesInitialized &&
            cellsInitialized &&
            damageTypesInitialized &&
            healTypesInitialized &&
            defenceTypesInitialized &&
            activeAbilitiesInitialized &&
            itemsInitialized &&
            entitiesInitialized;
    }


    // Resources
    public static int AddResourceId()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (resourcesInitialized)
        {
            throw new System.Exception("������� ��� ����������������, ���������� ����� ����������!");
        }
        currentLastResourceId++;
        return currentLastResourceId;
    }

    public static void AddResourceInitInfo(ResourceInitInfo info)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (resourcesInitialized)
        {
            throw new System.Exception("������� ��� ����������������, ���������� ����� ����������!");
        }
        resourceInitInfo[info.id] = info;
    }

    public static void ResourceInit()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (resourcesInitialized)
        {
            throw new System.Exception("������� ��� ����������������!");
        }
        resourcesInitialized = true;
    }

    public static Resource CreateResource(int newResourceId, int count)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        if (!resourceInitInfo.ContainsKey(newResourceId))
        {
            throw new System.Exception("����������� ������� ������� ������ ������������ ����!");
        }
        return new Resource(resourceInitInfo[newResourceId], count);
    }


    // Cells
    public static int AddCellId()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (cellsInitialized)
        {
            throw new System.Exception("������ ��� ����������������, ���������� ����� ����������!");
        }
        currentLastCellId++;
        return currentLastCellId;
    }

    public static void AddCellInitInfo(CellInitInfo info)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (cellsInitialized)
        {
            throw new System.Exception("������� ��� ����������������, ���������� ����� ����������!");
        }
        cellsInitInfo[info.typeId] = info;
    }

    public static void CellsInit()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (cellsInitialized)
        {
            throw new System.Exception("������ ��� ����������������!");
        }
        cellsInitialized = true;
    }

    public static void CreateCell(int newCellTypeId, Vector2Int coords, Map map)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        if (!cellsInitInfo.ContainsKey(newCellTypeId))
        {
            throw new System.Exception("����������� ������� ������� ������ ������������ ����!");
        }
        map.AddCell(new Cell(cellsInitInfo[newCellTypeId], coords, map));
    }


    // Items
    public static int AddItemId()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (itemsInitialized)
        {
            throw new System.Exception("�������� ��� ����������������, ���������� ����� ����������!");
        }
        currentLastItemId++;
        return currentLastItemId;
    }

    public static void AddItemInitInfo(ItemInitInfo info)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (itemsInitialized)
        {
            throw new System.Exception("�������� ��� ����������������, ���������� ����� ����������!");
        }
        itemsInitInfo[info.id] = info;
    }

    public static void ItemsInit()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (itemsInitialized)
        {
            throw new System.Exception("�������� ��� ����������������!");
        }
        itemsInitialized = true;
    }

    public static Item CreateItem(int newItemId)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        if (!itemsInitInfo.ContainsKey(newItemId))
        {
            throw new System.Exception("����������� ������� ������� ����������� �������!");
        }
        return new Item(itemsInitInfo[newItemId]);
    }


    // Abilities
    public static int AddActiveAbilityId()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (activeAbilitiesInitialized)
        {
            throw new System.Exception("�������� ����������� ��� ����������������, ���������� ����� ����������!");
        }
        currentLastActiveAbilityId++;
        return currentLastActiveAbilityId;
    }

    public static void AddActiveAbility(ActiveAbilityInitInfo info)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (itemsInitialized)
        {
            throw new System.Exception("�������� ��� ����������������, ���������� ����� ����������!");
        }
        if (activeAbilities.ContainsKey(info.id))
        {
            throw new System.Exception("����������� � ����� id ��� ����������!");
        }
        activeAbilities[info.id] = new ActiveAbility(info);
    }

    public static void ActiveAbilitysInit()
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator �� ���������������!");
        }
        if (activeAbilitiesInitialized)
        {
            throw new System.Exception("�������� ��� ����������������!");
        }
        activeAbilitiesInitialized = true;
    }

    public static int UseAbility(int id, List<(Vector2Int, Map)> targetsList, Entity owner)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        return activeAbilities[id].UseAbility(targetsList, owner);
    }

    public static int ContinueUseAbility(int id, Entity owner, int currentEffectGroup, List<(Vector2Int, Map)> targetsList)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        return activeAbilities[id].DoTheTurnStuff(owner, currentEffectGroup, targetsList);
    }

    public static double GetAbilityCooldown(int id)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        return activeAbilities[id].maxCooldown;
    }

    public static double GetAbilityDelay(int id, int effectGroup)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        return activeAbilities[id].effects[effectGroup].delay;
    }

    // ������ ���� �� �������� ������ �����, � �� ����� �� �������� ����������� ������ ��� ����� ����������
    // (��������� �����, �����)
    //public static bool ChekAbilityExistence(int id) 
    //{
    //    if (!abilitiesInitialized)
    //    {
    //        throw new System.Exception("����������� ��� �� ����������������!");
    //    }
    //    return activeAbilities.ContainsKey(id);
    //}


    // Entities
    public static void EntitiesInit(Dictionary<int, EntityInitInfo> entityInitInfo)
    {
        entitiesInitialized = true;
        Fabricator.entitiesInitInfo = entityInitInfo;
    }





    public static void CreateEntity(int newEntityId, Player owner, Cell cell)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator �� ��������������� ����� ��������������!");
        }
        if (!entitiesInitInfo.ContainsKey(newEntityId))
        {
            throw new System.Exception("����������� ������� ������� ����������� ��������!");
        }

        if (entitiesInitInfo[newEntityId] is UnitInitInfo)
        {
            if (cell.unitAtCell != null)
            {
                throw new System.Exception("���������� ������� �������� �� ��� ������� ������!");
            }
            owner.AddEntity(new Unit((UnitInitInfo)entitiesInitInfo[newEntityId], cell, owner));
        }
    }





}
