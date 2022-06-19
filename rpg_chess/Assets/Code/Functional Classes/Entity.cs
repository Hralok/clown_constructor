using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public double expToKiller { get; private set; }
    public double currentExp { get; private set; }
    public double expToNextLvl { get; private set; } // Временная переменная, необходимо заменить 
    public int currentLvl { get; private set; }



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

    public void MoveToCell(Cell targetCell)
    {
        currentCell = targetCell;
    }

    public void ChangeHP(double count, Entity source)
    {
        healthPoints += count;

        if (healthPoints <= 0)
        {
            WorldController.KillEntity(this, source);
        }
    }

    public void ChangeMana(double count)
    {
        mana += count;

        if (mana < 0)
        {
            mana = 0;
        }
    }

    public void ChangeEnergy(double count)
    {
        energy += count;

        if (energy < 0)
        {
            energy = 0;
        }
    }

    public void DoTheTurnStuff()
    {
        foreach (var ability in abilities)
        {
            ability.DoTheTurnStuff(this);
        }
    }

    public bool GetItemFromCurrentCell()
    {
        bool pickedUp = false;

        if (currentCell.itemAtCell != null)
        {
            var slotIndx = FindFirstEmptySlot();

            if (slotIndx != -1)
            {
                inventory[slotIndx] = currentCell.itemAtCell;
                pickedUp = true;
                currentCell.ExpelItem();
                CheckCraftsForItem(slotIndx);
            }
        }

        return pickedUp;
    }

    protected int FindFirstEmptySlot()
    {
        int indx = -1;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                indx = i;
                break;
            }
        }

        return indx;
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

    public void DropItemFromIndx(int indx)
    {
        if (indx < inventory.Length)
        {
            inventory[indx] = null;
        }
    }

    public double Die()
    {

        // Будущий код, связанный с использованием посмертных способностей и способностей предметов

        return expToKiller;
    }


    public void CheckCraftsForItem(int itemInInventoryIndex)
    {
        Dictionary<int, int> realItemsCount;
        if (inventory[itemInInventoryIndex].craftableItemsIds.Count != 0)
        {
            realItemsCount = new Dictionary<int, int>();

            foreach (var item in inventory)
            {
                if (item.сombinable)
                {
                    if (realItemsCount.ContainsKey(item.itemId))
                    {
                        realItemsCount[item.itemId]++;
                    }
                    else
                    {
                        realItemsCount[item.itemId] = 1;
                    }
                }

            }

            foreach (var craftableItemId in inventory[itemInInventoryIndex].craftableItemsIds)
            {
                var recipesForItem = CraftController.GetCraftableItemsIds(craftableItemId, itemInInventoryIndex);

                foreach (var recipe in recipesForItem)
                {
                    bool canCraft = true;

                    foreach (var key in recipe.Keys)
                    {
                        if (!realItemsCount.ContainsKey(key) && recipe[key] > realItemsCount[key])
                        {
                            canCraft = false;
                        }
                    }

                    if (canCraft)
                    {

                        foreach (var key in realItemsCount.Keys)
                        {
                            while (realItemsCount[key] != 0)
                            {
                                inventory[inventory.First(x => x.itemId == key && x.сombinable).itemId] = null;
                                realItemsCount[key] -= 1;
                            }
                        }

                        var indx = FindFirstEmptySlot();

                        inventory[indx] = Fabricator.CreateItem(craftableItemId);
                        return;
                    }
                }
            }
        }
    }

}
