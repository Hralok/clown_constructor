using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabricator 
{
    private static Dictionary<int, ActiveAbility> abilities;
    private static bool initialized = false;

    public static void Init()
    {
        initialized = true;
        abilities = new Dictionary<int, ActiveAbility>();
    }

    public static Item CreateItem(int newItemId)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        throw new System.NotImplementedException();
    }

    public static int UseAbility(int indx, List<(Vector2Int, Map)> targetsList, Entity owner)
    {
        return abilities[indx].UseAbility(targetsList, owner);
    }

    public static double GetAbilityCooldown(int indx)
    {
        return abilities[indx].maxCooldown;
    }

}
