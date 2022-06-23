using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInitInfo : EntityInitInfo
{
    public Dictionary<MainCharacteristicTypeEnum, double> mainChars { get; private set; }
    public double expToNextLvl { get; private set; } 
    public int currentLvl { get; private set; }

    public UnitInitInfo(
        int entityId,
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
        double expToKiller,
        DefenseTypeEnum defenseType,
        List<ActiveAbilityInSomewhere> abilities,
        int inventorySize, 
        Dictionary<MainCharacteristicTypeEnum, double> mainChars, 
        double expToNextLvl, 
        int currentLvl) :
        base(entityId, maximalHealthPoints, maximalMana, maximalEnergy, selfTypes, damageBonusAmplification, damageMultiplerAmplification, healBonusAmplification, healMultiplerAmplification, damageElementBonusAmplification, damageElementMultiplerAmplification, healElementBonusAmplification, healElementMultiplerAmplification, attackTypeBonusAmplification, attackTypeMultiplerAmplification, expToKiller, defenseType, abilities, inventorySize)
    {
        foreach (var charNum in mainChars.Values)
        {
            if (charNum < 0)
            {
                throw new System.Exception("Значение основной характеристики не может быть отрицательным числом!");
            }
        }
        this.mainChars = mainChars;

        if (expToNextLvl <= 0)
        {
            throw new System.Exception("expToNextLvl должно быть положительным числом!");
        }
        this.expToNextLvl = expToNextLvl;

        if (currentLvl <= 0)
        {
            throw new System.Exception("currentLvl должно быть положительным числом!");
        }
        this.currentLvl = currentLvl;
    }
}
