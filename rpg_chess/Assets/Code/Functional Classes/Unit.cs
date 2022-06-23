using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public Dictionary<MainCharacteristicTypeEnum, double> mainChars { get; private set; }
    public double currentExp { get; private set; }
    public double expToNextLvl { get; private set; } // Временная переменная, необходимо заменить 
    public int currentLvl { get; private set; }

    public bool busyWithItem { get; private set; }
    public int currentItemAbilityId { get; private set; }
    private int currentEffectGroup;
    public double currentItemAbilityDelay { get; private set; }
    private List<(Vector2Int, Map)> targetsList;


    public Unit(UnitInitInfo info, Cell currentCell, Player player) : base(info, currentCell, player)
    {
        mainChars = new Dictionary<MainCharacteristicTypeEnum, double>(info.mainChars);
        currentExp = 0;
        expToNextLvl = info.expToNextLvl;
        currentLvl = info.currentLvl;
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

    public override void DoTheTurnStuff()
    {
        foreach (var item in inventory)
        {
            if (item != null)
            {
                item.DoTheTurnStuff();
            }
        }

        if (busyWithItem)
        {
            currentItemAbilityDelay -= 1;
            if (currentItemAbilityDelay <= 0)
            {
                var result = Fabricator.ContinueUseAbility(currentItemAbilityId, this, currentEffectGroup, targetsList);

                if (result == -1)
                {
                    busyWithItem = false;
                }
                else
                {
                    currentEffectGroup = result;
                    currentItemAbilityDelay = Fabricator.GetAbilityDelay(currentItemAbilityId, currentEffectGroup);
                }
            }
        }
        
        base.DoTheTurnStuff();
    }





    public void UseItem(int indx, List<(Vector2Int, Map)> targetsList)
    {
        if (indx < inventory.Length && indx >0 && inventory[indx] != null && inventory[indx].activeAbilitiyId != -1 && (inventory[indx].hasCharges && inventory[indx].charges > 0))
        {
            currentEffectGroup = inventory[indx].UseItemActiveAbility(targetsList, this);

            if (currentEffectGroup != -1)
            {
                busyWithItem = true;
                currentItemAbilityId = inventory[indx].activeAbilitiyId;
                currentItemAbilityDelay = Fabricator.GetAbilityDelay(inventory[indx].activeAbilitiyId, currentEffectGroup);
                this.targetsList = targetsList;
            }
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
