using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Cell currentCell { get; protected set; }

    public double healthPoints { get; private set; }
    public double mana { get; private set; }
    public double energy { get; private set; }

    public double maximalHealthPoints { get; private set; }
    public double maximalMana { get; private set; }
    public double maximalEnergy { get; private set; }

    public Player player { get; protected set; }

    // Множество собственных типов сущности
    public HashSet<EntityTypeEnum> selfTypes { get; private set; }

    // Список приобретённых типов существа с показателем количества удерживающих эффектов
    // Отложено до момента реализации временных эффектов
    //public List<(int, EntityTypeEnum)> acquiredTypes { get; private set; }

    // Усиление Умений лечения и атаки
    public double damageBonusAmplification { get; private set; }
    public double damageMultiplerAmplification { get; private set; }
    public double healBonusAmplification { get; private set; }
    public double healMultiplerAmplification { get; private set; }
    public Dictionary<DamageTypeEnum, double> damageElementBonusAmplification { get; private set; }
    public Dictionary<DamageTypeEnum, double> damageElementMultiplerAmplification { get; private set; }
    public Dictionary<HealTypeEnum, double> healElementBonusAmplification { get; private set; }
    public Dictionary<HealTypeEnum, double> healElementMultiplerAmplification { get; private set; }
    public Dictionary<AttackTypeEnum, double> attackTypeBonusAmplification { get; private set; }
    public Dictionary<AttackTypeEnum, double> attackTypeMultiplerAmplification { get; private set; }

    public DefenseTypeEnum defenseType { get; private set; }
    
    // Переменные отвечают за использование продолжительных способностей
    public bool busy { get; private set; }
    public ActiveAbility currentAbility { get; private set; }

    public List<Ability> abilities { get; private set; }

    public Item[] inventory { get; private set; }
    public int inventorySize { get; private set; }

    public Entity()
    {

    }
    public void MoveToCell(Cell targetCell)
    {
        currentCell = targetCell;
    }

    public void TakeDamage(double count)
    {
        healthPoints -= count;

        if (healthPoints <= 0)
        {
            WorldController.KillEntity(this);
        }
    }

    public void TakeHeal(double count)
    {
        healthPoints += count;
    }

    public bool GetItemFromCurrentCell()
    {
        bool pickedUp = false;

        if (currentCell.itemAtCell != null)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = currentCell.itemAtCell;
                    pickedUp = true;
                    currentCell.ExpelItem();
                    break;
                }
            }
        }

        return pickedUp;
    }

    public void MoveItemInInventory(int from, int to)
    {
        if (from < inventory.Length && inventory[from] != null && to != from && to < inventory.Length)
        {
            if (inventory[to] == null)
            {
                inventory[to] = inventory[from];
                inventory[from] = null;
            }
            else
            {
                var intermediate = inventory[to];
                inventory[to] = inventory[from];
                inventory[from] = intermediate;
            }
        }
    }

    public void CheckCraftsForItem(int itemInInventoryIndex)
    {
        foreach (var itemId in inventory[itemInInventoryIndex].craftableItemsIds)
        {

        }

        var neededItems = CraftController.GetCraftableItemsIds(itemInInventoryIndex);
    }

}
