using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    readonly public int itemId;
    public List<HashSet<Resource>> cost { get; private set; }
    public ActiveAbility activeAbilitiy { get; private set; }
    public List<PassiveAbility> passiveAbilities { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }
    public bool сombinable { get; private set; } = true; // Игрок может переключать состояние предмета если не хочет чтобы он участвовал в крафтах
    public List<int> craftableItemsIds { get; private set; }
    public bool isItConsumable { get; private set; }
    private int usageMargin;
    private Item replacementItem;

    public Item(
        int itemId, int nameId, int descriptionId,
        List<HashSet<Resource>> cost,
        ActiveAbility activeAbilitiy, List<PassiveAbility> passiveAbilities,
        bool consumable, int usageMargin = 1, Item replacementItem = null
        )
    {
        this.itemId = itemId;
        this.nameId = nameId;
        this.descriptionId = descriptionId;
        this.cost = cost;
        this.activeAbilitiy = activeAbilitiy;
        this.passiveAbilities = passiveAbilities;
        this.isItConsumable = consumable;
        this.usageMargin = usageMargin;
        this.replacementItem = replacementItem;

    }

    public void SwitchCombinableStatus()
    {
        сombinable = !сombinable;
    }

    public void DoTheTurnStuff(Entity owner)
    {
        if (activeAbilitiy != null)
        {
            activeAbilitiy.DoTheTurnStuff(owner);
        }

        foreach (var ability in passiveAbilities)
        {
            ability.DoTheTurnStuff(owner);
        }
    }

    public List<ActiveAbility.TargetArea> GetActiveAbilityTargetsArea()
    {
        return activeAbilitiy.targetAreas;
    }

    public void UseItemActiveAbility(List<(Vector2Int, Map)> targetsList, Unit owner)
    {
        if (activeAbilitiy != null)
        {
            activeAbilitiy.UseAbility(targetsList, owner);

            if (isItConsumable)
            {
                usageMargin--;
                if (usageMargin <= 0)
                {
                    owner.ReplaceTheItemWith(this, replacementItem);
                }
            }
        }
    }
}
