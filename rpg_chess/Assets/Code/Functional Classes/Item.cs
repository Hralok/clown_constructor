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
    private int charges;
    private bool consumable;
    private int replacementItemId;

    public Item(
        int itemId, int nameId, int descriptionId,
        List<HashSet<Resource>> cost,
        ActiveAbility activeAbilitiy, List<PassiveAbility> passiveAbilities
        )
    {
        this.itemId = itemId;
        this.nameId = nameId;
        this.descriptionId = descriptionId;
        this.cost = cost;
        //this.activeAbilitiy = activeAbilitiy;
        this.passiveAbilities = passiveAbilities;

    }

    public void SwitchCombinableStatus()
    {
        сombinable = !сombinable;
    }

    public void DoTheTurnStuff(Entity owner)
    {
        //if (activeAbilitiy != null)
        //{
        //    activeAbilitiy.DoTheTurnStuff(owner);
        //}

        //foreach (var ability in passiveAbilities)
        //{
        //    ability.DoTheTurnStuff(owner);
        //}
    }

    //public List<TargetArea> GetActiveAbilityTargetsArea()
    //{
    //    return activeAbilitiy.targetAreas;
    //}

    public void UseItemActiveAbility(List<(Vector2Int, Map)> targetsList, Unit owner)
    {
        //if (activeAbilitiy != null)
        //{
        //    if (hasCharges && charges <= 0)
        //    {
        //        return;
        //    }

        //    activeAbilitiy.UseAbility(targetsList, owner);

        //    if (hasCharges)
        //    {
        //        charges--;

        //        if (charges == 0 && consumable)
        //        {
        //            owner.ReplaceItemWith(this, replacementItemId);
        //        }
        //    }
        //}
    }
}
