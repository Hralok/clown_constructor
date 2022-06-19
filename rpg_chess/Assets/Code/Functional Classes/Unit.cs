using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public Dictionary<MainCharacteristicTypeEnum, double> mainChars { get; private set; }
    public Unit(Cell cell)
    {
        currentCell = cell;
    }

    public void ReplaceItemWith(Item replaceableItem, int replacementItemId)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == replaceableItem)
            {
                if (replacementItemId <= -1)
                {
                    inventory[i] = null;
                }
                else
                {
                    inventory[i] = Fabricator.CreateItem(replacementItemId);
                }
            }
        }
    }

    public void UseItem(int indx, List<(Vector2Int, Map)> targetsList)
    {
        if (indx < inventory.Length && inventory[indx] != null && inventory[indx].activeAbilitiy != null)
        {
            inventory[indx].UseItemActiveAbility(targetsList, this);
        }
    }
}
