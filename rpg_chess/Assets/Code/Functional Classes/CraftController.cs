using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CraftController
{
    static private Dictionary<int, List<List<int>>> craftingCatalog;

    static public void Init(Dictionary<int, List<List<int>>> craftingCatalog)
    {
        CraftController.craftingCatalog = craftingCatalog;
    }

    static public List<int> GetCraftableItemsIds(int itemId)
    {
        List<int> items = new List<int>();

        foreach (var craftableItem in craftingCatalog.Keys)
        {
            foreach (var recipe in craftingCatalog[craftableItem])
            {
                if (recipe.Contains(itemId))
                {
                    items.Add(craftableItem);
                    break;
                }
            }
            
        }

        return items;
    }
}
