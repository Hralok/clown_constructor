using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    readonly public int itemId;
    public List<HashSet<Resource>> cost { get; private set; }
    public int activeAbilitiyId { get; private set; }
    public List<PassiveAbility> passiveAbilities { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }
    public bool сombinable { get; private set; } = true; // Игрок может переключать состояние предмета если не хочет чтобы он участвовал в крафтах
    public List<int> craftableItemsIds { get; private set; }
    public bool hasCharges { get; private set; }
    public  int charges { get; private set; }
    private bool consumable;
    private int replacementItemId;

    public double currentCooldown { get; private set; }
    public double maximalCooldown { get; private set; }

    public Item(
        int itemId, int nameId, int descriptionId,
        List<HashSet<Resource>> cost,
        int activeAbilitiyId, List<PassiveAbility> passiveAbilities
        )
    {
        this.itemId = itemId;
        this.nameId = nameId;
        this.descriptionId = descriptionId;
        this.cost = cost;
        this.activeAbilitiyId = activeAbilitiyId;
        this.passiveAbilities = passiveAbilities;

    }

    public void SwitchCombinableStatus()
    {
        сombinable = !сombinable;
    }

    public void DoTheTurnStuff()
    {
        if (currentCooldown > 0)
        {
            currentCooldown--;
        }
    }


    public int UseItemActiveAbility(List<(Vector2Int, Map)> targetsList, Unit owner)
    {
        if (activeAbilitiyId == -1)
        {
            throw new System.Exception("У предмета нет способности для использования!");
        }

        if (hasCharges && charges <= 0)
        {
            throw new System.Exception("Невозможно использовать предмет так как не осталось зарядов!");
        }

        var result = Fabricator.UseAbility(activeAbilitiyId, targetsList, owner);


        currentCooldown = maximalCooldown;





        if (hasCharges)
        {
            charges--;

            if (charges == 0 && consumable)
            {
                owner.ReplaceItemWith(this, replacementItemId);
            }
        }

        return result;
    }



}
