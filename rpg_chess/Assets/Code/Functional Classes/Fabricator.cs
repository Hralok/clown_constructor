using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabricator
{
    private static Dictionary<int, ActiveAbility> activeAbilities;
    public static HashSet<ResourceTypeEnum> allowedResources { get; private set; }

    private static Dictionary<int, EntityInitInfo> entityInitInfo;

    public static bool resourcesInitialized { get; private set; } = false;
    public static bool damageTypesInitialized { get; private set; } = false;
    public static bool healTypesInitialized { get; private set; } = false;
    public static bool defenceTypesInitialized { get; private set; } = false;
    public static bool abilitiesInitialized { get; private set; } = false;
    public static bool itemsInitialized { get; private set; } = false;

    public static bool entitiesInitialized { get; private set; } = false;

    public static bool IsInitialized()
    {
        return resourcesInitialized &&
            damageTypesInitialized &&
            healTypesInitialized &&
            defenceTypesInitialized &&
            abilitiesInitialized &&
            itemsInitialized &&
            entitiesInitialized;
    }

    public static void ResourceInit(HashSet<ResourceTypeEnum> allowedResources)
    {
        if (allowedResources == null)
        {
            throw new System.Exception("allowedResources не может быть null!");
        }
        resourcesInitialized = true;
        Fabricator.allowedResources = allowedResources;
    }

    public static void AbilitiesInit(Dictionary<int, ActiveAbility> activeAbilities)
    {
        abilitiesInitialized = true;
        Fabricator.activeAbilities = activeAbilities;
    }

    public static void EntitiesInit(Dictionary<int, EntityInitInfo> entityInitInfo)
    {
        entitiesInitialized = true;
        Fabricator.entityInitInfo = entityInitInfo;
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
        throw new System.NotImplementedException();
    }

    public static void CreateEntity(int newEntityId, Player owner, Cell cell)
    {
        if (IsInitialized())
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }

        if(!entityInitInfo.ContainsKey(newEntityId))
        {
            throw new System.Exception("Произведена попытка создать неизвестную сущность!");
        }

        if (entityInitInfo[newEntityId] is UnitInitInfo)
        {
            if (cell.unitAtCell!=null)
            {
                throw new System.Exception("Невозможно создать существо на уже занятой ячейке!");
            }
            owner.AddEntity(new Unit((UnitInitInfo)entityInitInfo[newEntityId], cell, owner));
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
