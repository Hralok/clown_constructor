using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public Dictionary<MainCharacteristicTypeEnum, double> mainChars { get; private set; }
    public double currentExp { get; private set; }
    public double expToNextLvl { get; private set; } // Временная переменная, необходимо заменить 
    public int currentLvl { get; private set; }
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
        if (indx < inventory.Length && inventory[indx] != null)
        {
            inventory[indx].UseItemActiveAbility(targetsList, this);
        }
    }

    public void GetExp(double count)
    {
        if (count >= 0)
        {
            currentExp += count;

            while (currentExp >= expToNextLvl)
            {
                currentLvl++;
                currentExp -= expToNextLvl;
            }
        }
    }
}
