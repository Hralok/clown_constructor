using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitInitInfo : EntityInitInfo
{
    public Dictionary<MainCharacteristicTypeEnum, double> mainChars { get; private set; }
    public double expToNextLvl { get; private set; } 
    public int currentLvl { get; private set; }

    public UnitInitInfo(
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
        int currentLvl,
        GameObject attackAnimationObject,
        TileBase attackingAnimationTile,
        GameObject dyingAnimationObject,
        TileBase stayingAnimationTile,
        Sprite portrait
        ) :
        base(maximalHealthPoints, maximalMana, maximalEnergy, selfTypes, damageBonusAmplification, damageMultiplerAmplification, healBonusAmplification, healMultiplerAmplification, damageElementBonusAmplification, damageElementMultiplerAmplification, healElementBonusAmplification, healElementMultiplerAmplification, attackTypeBonusAmplification, attackTypeMultiplerAmplification, expToKiller, defenseType, abilities, inventorySize)
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

        if (currentLvl < 0)
        {
            throw new System.Exception("currentLvl должно быть неотрицательным числом!");
        }
        this.currentLvl = currentLvl;


        GraphicSupporter.AddUnitGraphic(id, attackAnimationObject, attackingAnimationTile, dyingAnimationObject, stayingAnimationTile, portrait);

    }
}
