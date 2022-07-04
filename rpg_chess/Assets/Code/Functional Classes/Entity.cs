using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Entity
{
    readonly public int id;
    public Cell currentCell { get; protected set; }

    public double healthPoints { get; protected set; }
    public double mana { get; protected set; }
    public double energy { get; protected set; }

    public double maximalHealthPoints { get; protected set; }
    public double maximalMana { get; protected set; }
    public double maximalEnergy { get; protected set; }

    public Player player { get; protected set; }

    // Множество собственных типов сущности
    public HashSet<EntityTypeEnum> selfTypes { get; protected set; }

    // Список приобретённых типов существа с показателем количества удерживающих эффектов
    // Отложено до момента реализации временных эффектов
    //public List<(int, EntityTypeEnum)> acquiredTypes { get; private set; }

    // Усиление Умений лечения и атаки
    public double damageBonusAmplification { get; protected set; }
    public double damageMultiplerAmplification { get; protected set; }
    public double healBonusAmplification { get; protected set; }
    public double healMultiplerAmplification { get; protected set; }
    public Dictionary<DamageTypeEnum, double> damageElementBonusAmplification { get; protected set; }
    public Dictionary<DamageTypeEnum, double> damageElementMultiplerAmplification { get; protected set; }
    public Dictionary<HealTypeEnum, double> healElementBonusAmplification { get; protected set; }
    public Dictionary<HealTypeEnum, double> healElementMultiplerAmplification { get; protected set; }
    public Dictionary<AttackTypeEnum, double> attackTypeBonusAmplification { get; protected set; }
    public Dictionary<AttackTypeEnum, double> attackTypeMultiplerAmplification { get; protected set; }

    public double expToKiller { get; protected set; }




    public DefenseTypeEnum defenseType { get; protected set; }

    // Переменные отвечают за использование продолжительных способностей
    public bool busy { get; private set; }
    public int currentAbilityInListIndx { get; private set; }
    private int currentEffectGroup;
    public double currentDelay { get; private set; }
    private List<(Vector2Int, Map)> targetsList;

    // Необходимо вынести способности из сущностей и предметов, заменив на id способностей
    // Подумать над смешением активных и пассивных способностей
    public List<ActiveAbilityInSomewhere> abilities { get; protected set; }

    public Item[] inventory { get; protected set; }
    public int inventorySize { get; protected set; }

    public Entity(EntityInitInfo info, Cell currentCell, Player player)
    {
        id = info.id;

        currentCell.AddEntity(this);
        this.currentCell = currentCell;

        maximalEnergy = info.maximalEnergy;
        maximalHealthPoints = info.maximalHealthPoints;
        maximalMana = info.maximalMana;

        energy = maximalEnergy;
        healthPoints = maximalHealthPoints;
        mana = maximalMana;

        this.player = player;
        selfTypes = info.selfTypes;
        damageBonusAmplification = info.damageBonusAmplification;
        damageMultiplerAmplification = info.damageMultiplerAmplification;
        healBonusAmplification = info.healBonusAmplification;
        healMultiplerAmplification = info.healMultiplerAmplification;
        damageElementBonusAmplification = new Dictionary<DamageTypeEnum, double>(info.damageElementBonusAmplification);
        damageElementMultiplerAmplification = new Dictionary<DamageTypeEnum, double>(info.damageElementMultiplerAmplification);
        healElementBonusAmplification = new Dictionary<HealTypeEnum, double>(info.healElementBonusAmplification);
        healElementMultiplerAmplification = new Dictionary<HealTypeEnum, double>(info.healElementMultiplerAmplification);
        attackTypeBonusAmplification = new Dictionary<AttackTypeEnum, double>(info.attackTypeBonusAmplification);
        attackTypeMultiplerAmplification = new Dictionary<AttackTypeEnum, double>(info.attackTypeMultiplerAmplification);
        expToKiller = info.expToKiller;
        defenseType = info.defenseType;
        busy = false;
        abilities = info.abilities.Clone();
        inventorySize = info.inventorySize;

        inventory = new Item[inventorySize];
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

    public virtual void DoTheTurnStuff()
    {
        foreach (var ability in abilities)
        {
            if (ability.curentCooldown > 0)
            {
                ability.curentCooldown -= 1;
            }
        }

        if (busy)
        {
            currentDelay -= 1;
            if (currentDelay <= 0)
            {
                var result = Fabricator.ContinueUseAbility(abilities[currentAbilityInListIndx].abilityId, this, currentEffectGroup, targetsList);

                if (result == -1)
                {
                    busy = false;
                }
                else
                {
                    currentEffectGroup = result;
                    currentDelay = Fabricator.GetAbilityDelay(abilities[currentAbilityInListIndx].abilityId, currentEffectGroup);
                }
            }
        }
        else
        {
            energy = maximalEnergy;
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

    public bool GetItem(Item item)
    {
        bool getted = false;


        var slotIndx = FindFirstEmptySlot();

        if (slotIndx > -1)
        {
            inventory[slotIndx] = item;
            getted = true;
            CheckCraftsForItem(slotIndx);
        }

        return getted;
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

    public Item ExpelItemFromIndx(int indx)
    {
        Item item = null;

        if (indx < inventory.Length)
        {
            item = inventory[indx];
            inventory[indx] = null;
        }

        return item;
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
                    if (realItemsCount.ContainsKey(item.id))
                    {
                        realItemsCount[item.id]++;
                    }
                    else
                    {
                        realItemsCount[item.id] = 1;
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
                                inventory[inventory.First(x => x.id == key && x.сombinable).id] = null;
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

    public void UseAbility(int inListIndx, List<(Vector2Int, Map)> targetsList)
    {
        var result = Fabricator.UseAbility(abilities[inListIndx].abilityId, targetsList, this);

        if (result == -1)
        {
            abilities[inListIndx].curentCooldown = Fabricator.GetAbilityCooldown(abilities[inListIndx].abilityId);
        }
        else
        {
            busy = true;
            currentAbilityInListIndx = inListIndx;
            currentEffectGroup = result;
            currentDelay = Fabricator.GetAbilityDelay(abilities[currentAbilityInListIndx].abilityId, currentEffectGroup);
            this.targetsList = targetsList;
        }
    }

    public void SetNewPlayer(Player newPlayer)
    {
        player = newPlayer;
    }



}
