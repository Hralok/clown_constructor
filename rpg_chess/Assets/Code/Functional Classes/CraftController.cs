using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController
{
    // Словарь: id предмета - {id предметов для крафта}
    Dictionary<int, HashSet<int>> craftingCatalog = new Dictionary<int, HashSet<int>>()
    {

    };

    // Получить id предметов, которые могут быть созданы с помощью переданного предмета
    public HashSet<int> GetCraftableItemsIds(int itemId)
    {
        HashSet<int> items = new HashSet<int>();

        foreach (var craftableItem in craftingCatalog.Keys)
        {
            if (craftingCatalog[craftableItem].Contains(itemId))
            {
                items.Add(craftableItem);
            }
        }

        return items;
    }

}
