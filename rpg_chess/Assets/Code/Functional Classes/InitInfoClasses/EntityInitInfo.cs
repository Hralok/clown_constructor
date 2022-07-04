using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityInitInfo
{
    public int id;
    public double maximalHealthPoints { get; private set; }
    public double maximalMana { get; private set; }
    public double maximalEnergy { get; private set; }

    public HashSet<EntityTypeEnum> selfTypes { get; private set; }

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

    public DefenseTypeEnum defenseType { get; private set; }
    
    public List<ActiveAbilityInSomewhere> abilities { get; private set; }

    public int inventorySize { get; private set; }

    public EntityInitInfo(
        double maximalHealthPoints, 
        double maximalMana, 
        double maximalEnergy, 
        HashSet<EntityTypeEnum> selfTypes, 
        double damageBonusAmplification, 
        double damageMultiplerAmplification, 
        double healBonusAmplification, 
        double healMultiplerAmplification, 
        Dictionary<DamageTypeEnum, double> damageElementBonusAmplification, 
        Dictionary<DamageTypeEnum, double> damageElementMultiplerAmplification, 
        Dictionary<HealTypeEnum, double> healElementBonusAmplification, 
        Dictionary<HealTypeEnum, double> healElementMultiplerAmplification, 
        Dictionary<AttackTypeEnum, double> attackTypeBonusAmplification, 
        Dictionary<AttackTypeEnum, double> attackTypeMultiplerAmplification, 
        double expToKiller, DefenseTypeEnum defenseType, 
        List<ActiveAbilityInSomewhere> abilities, 
        int inventorySize)
    {
        if (!Fabricator.activeAbilitiesInitialized)
        {
            throw new System.Exception("Необходимые элементы класса Fabricator ещё не инициализированы!");
        }

        if (maximalHealthPoints <= 0)
        {
            throw new System.Exception("maximalHealthPoints должно быть положительным числом!");
        }
        this.maximalHealthPoints = maximalHealthPoints;

        if (maximalMana < 0)
        {
            throw new System.Exception("maximalMana должно быть неотрицательным числом!");
        }
        this.maximalMana = maximalMana;

        if (maximalEnergy <= 0)
        {
            throw new System.Exception("maximalEnergy должно быть положительным числом!");
        }
        this.maximalEnergy = maximalEnergy;

        if (selfTypes == null || selfTypes.Count == 0)
        {
            throw new System.Exception("У сущности должен быть хотя бы один тип!");
        }
        this.selfTypes = selfTypes;

        this.damageBonusAmplification = damageBonusAmplification;
        this.damageMultiplerAmplification = damageMultiplerAmplification;

        this.healBonusAmplification = healBonusAmplification;
        this.healMultiplerAmplification = healMultiplerAmplification;

        this.damageElementBonusAmplification = damageElementBonusAmplification;
        this.damageElementMultiplerAmplification = damageElementMultiplerAmplification;
        this.healElementBonusAmplification = healElementBonusAmplification;
        this.healElementMultiplerAmplification = healElementMultiplerAmplification;
        this.attackTypeBonusAmplification = attackTypeBonusAmplification;
        this.attackTypeMultiplerAmplification = attackTypeMultiplerAmplification;

        if (expToKiller < 0)
        {
            throw new System.Exception("expToKiller должно быть неотрицательным числом!");
        }
        this.expToKiller = expToKiller;

        this.defenseType = defenseType;

        foreach (var ability in abilities)
        {
            //if (!Fabricator.ChekAbilityExistence(ability.abilityId))
            //{
            //    throw new System.Exception("Вы пытаетесь добавить сущности несуществующую способность!");
            //}
        }
        this.abilities = abilities;
        this.inventorySize = inventorySize;

        id = Fabricator.AddEntityId();
    }


}
