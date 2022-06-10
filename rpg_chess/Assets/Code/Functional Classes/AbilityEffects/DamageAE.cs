using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAE : AbilityEffect
{
    public double baseDamage { get; private set; }
    public DamageTypeEnum damageType { get; private set; }
    public AttackTypeEnum attackType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double damageBonusPerCharPoint { get; private set; }
    public double damageMultiplerPerCharPoint { get; private set; }


    public DamageAE(
        HashSet<Vector2Int> affectedArea,
        Ability ability,
        bool isAbsolute,
        bool isFlexible,
        double baseDamage,
        DamageTypeEnum damageType,
        AttackTypeEnum attackType,
        MainCharacteristicTypeEnum amplificationChar,
        double damageBonusPerCharPoint,
        double damageMultiplerPerCharPoint
        )
        : base(affectedArea, ability, isAbsolute, isFlexible)
    {
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.attackType = attackType;
        this.amplificationChar = amplificationChar;
        this.damageBonusPerCharPoint = damageBonusPerCharPoint;
        this.damageMultiplerPerCharPoint = damageMultiplerPerCharPoint;
    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {
        HashSet<Cell> targetCells;
        Damage attack;

        // ќпределение количества урона который будет нанесЄн

        double calculatedBaseDamage;
        double calculatedMultipler;

        calculatedBaseDamage =
            baseDamage +
            ability.owner.damageBonusAmplification +
            ability.owner.damageElementBonusAmplification.GetValueOrDefault(damageType, 0) +
            ability.owner.attackTypeBonusAmplification.GetValueOrDefault(attackType, 0);

        calculatedMultipler =
            (1 + ability.owner.damageMultiplerAmplification) *
            (1 + ability.owner.damageElementMultiplerAmplification.GetValueOrDefault(damageType, 0)) *
            (1 + ability.owner.attackTypeMultiplerAmplification.GetValueOrDefault(attackType, 0));

        if (ability.owner is Unit)
        {
            calculatedBaseDamage += ((Unit)ability.owner).mainChars[amplificationChar] * damageBonusPerCharPoint;
            calculatedMultipler *= (1 + ((Unit)ability.owner).mainChars[amplificationChar] * damageMultiplerPerCharPoint);
        }

        attack = new Damage(calculatedBaseDamage * calculatedMultipler, damageType, attackType);

        if (affectedArea.Count > 0)
        {
            var realTargetsCoords = new HashSet<Vector2Int>();
            HashSet<Vector2Int> realAffectedArea;

            // ќпределение координаты точки применени€
            Vector2Int realTarget;
            if (isAbsolute)
            {
                realTarget = target;
            }
            else
            {
                realTarget = target + ability.owner.currentCell.coords;
            }

            // ќтражение в случае необходимости области применени€ в сторону применени€ способности
            if (isFlexible)
            {
                realAffectedArea = WorldController.FlexArea(affectedArea, realTarget - ability.owner.currentCell.coords);
            }
            else
            {
                realAffectedArea = affectedArea;
            }

            // ќпределение координат попадающих под удар €чеек
            foreach (var affectedCoord in realAffectedArea)
            {
                realTargetsCoords.Add(affectedCoord + realTarget);
            }

            // ѕолучение попадающих под удар €чеек
            targetCells = map.GetCells(realTargetsCoords);
        }
        else
        {
            targetCells = map.GetAllCells();
        }

        foreach (var cell in targetCells)
        {
            cell.AttackCell(attack, ability.owner);
        }

    }
}
