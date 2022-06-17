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

    // Использовать ли предмет для авто-крафта
    public bool notCombinable { get; private set; } = false;

    // id предметов, которые могут быть созданы с использованием этого предмета
    private HashSet<int> craftableItemsIds;

    // Подумать над логикой после расходования (удалить/заменить/...)
    public bool isItConsumable { get; private set; }
    private int usageMargin; 

    // Предметы собираются

    public Item(
        int itemId, int nameId, int descriptionId,
        bool consumable,
        List<HashSet<Resource>> cost,
        ActiveAbility activeAbilitiy, List<PassiveAbility> passiveAbilities
        )
    {
        this.itemId = itemId;
        this.nameId = nameId;
        this.isItConsumable = consumable;
        this.descriptionId = descriptionId;
        this.cost = cost;
        this.activeAbilitiy = activeAbilitiy;
        this.passiveAbilities = passiveAbilities;

        // this.craftableItemsIds = CraftController.GetCraftableItemsIds(itemId);
    }

    public void DoItNotCombinable(bool notComb)
    {
        notCombinable = notComb;
    }

    // Проверка предметов, которые можно скрафтить из этого
    public void CheckCraftableItems(List<Item> inventory)
    {

    }

    // Получать список предметов?? в инвентаре могут быть и ресурсы
    public void ExecuteAfterAddingToInventoty(List<Item> inventory)
    {
        // Объединение с предметами того же типа

        if (!notCombinable)
        {
            CheckCraftableItems(inventory);
        }
    }

    public void UseItem()
    {
        if (isItConsumable)
        {
            usageMargin--;
            if (usageMargin <= 0)
            {
                // Действия после израсходования
            }
        }
    }
}
