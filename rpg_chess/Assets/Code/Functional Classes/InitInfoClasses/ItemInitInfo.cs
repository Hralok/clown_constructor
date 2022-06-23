using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInitInfo
{
    public int itemId { get; private set; }
    public List<HashSet<Resource>> cost { get; private set; }
    public int activeAbilitiyId { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }
    public List<int> craftableItemsIds { get; private set; }
    public bool hasCharges { get; private set; }
    public int charges { get; private set; }
    public bool consumable { get; private set; }
    public int replacementItemId { get; private set; }

    public double currentCooldown { get; private set; }
    public double maximalCooldown { get; private set; }

    public ItemInitInfo(
        int itemId, 
        List<HashSet<Resource>> cost, 
        int activeAbilitiyId, 
        int nameId, 
        int descriptionId, 
        List<int> craftableItemsIds, 
        bool hasCharges, 
        int charges, 
        bool consumable, 
        int replacementItemId)
    {
        this.itemId = itemId;
        this.cost = cost;
        this.activeAbilitiyId = activeAbilitiyId;
        this.nameId = nameId;
        this.descriptionId = descriptionId;
        this.craftableItemsIds = craftableItemsIds;
        this.hasCharges = hasCharges;
        this.charges = charges;
        this.consumable = consumable;
        this.replacementItemId = replacementItemId;
    }



}
