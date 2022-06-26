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





    public static bool resourcesInitialized { get; private set; } = false;
    public static bool cellsInitialized { get; private set; } = false;

    public static bool damageTypesInitialized { get; private set; } = false;
    public static bool healTypesInitialized { get; private set; } = false;
    public static bool defenceTypesInitialized { get; private set; } = false;
    public static bool abilitiesInitialized { get; private set; } = false;
    public static bool itemsInitialized { get; private set; } = false;
    public static bool entitiesInitialized { get; private set; } = false;

    public static int AddResourceId()
    {
        if (resourcesInitialized)
        {
            throw new System.Exception("Ресурсы уже инициализированы, добавление новых невозможно!");
        }
        currentLastResourceId++;
        return currentLastResourceId;
    }

    public static void AddResourceInitInfo(ResourceInitInfo info)
    {
        if (resourcesInitialized)
        {
            throw new System.Exception("Ресурсы уже инициализированы, добавление новых невозможно!");
        }
        resourceInitInfo[info.id] = info;
    }

    public static void ResourceInit()
    {
        resourcesInitialized = true;
    }

    public static Resource CreateResource(int newResourceId, int count)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return new Resource(resourceInitInfo[newResourceId], count);
    }

    public static int AddCellId()
    {
        if (cellsInitialized)
        {
            throw new System.Exception("Ячейки уже инициализированы, добавление новых невозможно!");
        }
        currentLastCellId++;
        return currentLastCellId;
    }

    public static void AddCellInitInfo(CellInitInfo info)
    {
        if (cellsInitialized)
        {
            throw new System.Exception("Ресурсы уже инициализированы, добавление новых невозможно!");
        }
        cellsInitInfo[info.typeId] = info;
    }

    public static void CellsInit()
    {
        cellsInitialized = true;
    }

    public static void CreateCell(int newCellTypeId, Vector2Int coords, Map map)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }

        map.AddCell(new Cell(cellsInitInfo[newCellTypeId], coords, map));
    }


    public static bool IsInitialized()
    {
        return resourcesInitialized &&
            cellsInitialized &&
            damageTypesInitialized &&
            healTypesInitialized &&
            defenceTypesInitialized &&
            abilitiesInitialized &&
            itemsInitialized &&
            entitiesInitialized;
    }



    public static void AbilitiesInit(Dictionary<int, ActiveAbility> activeAbilities)
    {
        abilitiesInitialized = true;
        Fabricator.activeAbilities = activeAbilities;
    }

    public static void EntitiesInit(Dictionary<int, EntityInitInfo> entityInitInfo)
    {
        entitiesInitialized = true;
        Fabricator.entitiesInitInfo = entityInitInfo;
    }

    public static void ItemsInit()
    {
        itemsInitialized = true;
        Fabricator.itemsInitInfo = new Dictionary<int, ItemInitInfo>();
    }

    public static void AddItemInfo(ItemInitInfo info)
    {
        if (!itemsInitialized)
        {
            throw new System.Exception("Предметы ещё не инициализированы!");
        }
        else
        {
            itemsInitInfo.Add(info.itemId, info);
        }
    }

    public static bool ChekAbilityExistence(int id)
    {
        if (!abilitiesInitialized)
        {
            throw new System.Exception("Способности ещё не инициализированы!");
        }
        return activeAbilities.ContainsKey(id);
    }

    public static Item CreateItem(int newItemId)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return new Item(itemsInitInfo[newItemId]);
    }

    

    public static void CreateEntity(int newEntityId, Player owner, Cell cell)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }

        if (!entitiesInitInfo.ContainsKey(newEntityId))
        {
            throw new System.Exception("Произведена попытка создать неизвестную сущность!");
        }

        if (entitiesInitInfo[newEntityId] is UnitInitInfo)
        {
            if (cell.unitAtCell != null)
            {
                throw new System.Exception("Невозможно создать существо на уже занятой ячейке!");
            }
            owner.AddEntity(new Unit((UnitInitInfo)entitiesInitInfo[newEntityId], cell, owner));
        }
    }

    public static int UseAbility(int id, List<(Vector2Int, Map)> targetsList, Entity owner)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return activeAbilities[id].UseAbility(targetsList, owner);
    }

    public static int ContinueUseAbility(int id, Entity owner, int currentEffectGroup, List<(Vector2Int, Map)> targetsList)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return activeAbilities[id].DoTheTurnStuff(owner, currentEffectGroup, targetsList);
    }

    public static double GetAbilityCooldown(int id)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return activeAbilities[id].maxCooldown;
    }

    public static double GetAbilityDelay(int id, int effectGroup)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        return activeAbilities[id].effects[effectGroup].delay;
    }




}
