using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CraftController
{
    static private Dictionary<int, List<Dictionary<int, int>>> craftingCatalog;

    static public void Init()
    {
        
    }

    static public List<Dictionary<int, int>> GetCraftableItemsIds(int itemToCraftId, int componentItemId)
    {
        List<Dictionary<int, int>> recipes = new List<Dictionary<int, int>>();

        foreach(var recipe in craftingCatalog[itemToCraftId])
        {
            if (recipe.ContainsKey(componentItemId))
            {
                recipes.Add(recipe);
            }
        }

        return recipes;
    }
}
