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
        List<(HashSet<Vector2Int>, bool)> areas,
        double baseDamage,
        DamageTypeEnum damageType,
        AttackTypeEnum attackType,
        MainCharacteristicTypeEnum amplificationChar,
        double damageBonusPerCharPoint,
        double damageMultiplerPerCharPoint
        )
        : base(areas)
    {
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.attackType = attackType;
        this.amplificationChar = amplificationChar;
        this.damageBonusPerCharPoint = damageBonusPerCharPoint;
        this.damageMultiplerPerCharPoint = damageMultiplerPerCharPoint;
    }

    public override void DoTheStuff(List<(Vector2Int, Map)> targets, Entity owner)
    {
        if (targets.Count != areas.Count)
        {
            throw new System.Exception("Количество целей не соответствует необходимому!");
        }

        HashSet<Cell> targetCells;
        Damage attack;

        // Определение количества урона который будет нанесён

        double calculatedBaseDamage;
        double calculatedMultipler;

        calculatedBaseDamage =
            baseDamage +
            owner.damageBonusAmplification +
            owner.damageElementBonusAmplification.GetValueOrDefault(damageType, 0) +
            owner.attackTypeBonusAmplification.GetValueOrDefault(attackType, 0);

        calculatedMultipler =
            (1 + owner.damageMultiplerAmplification) *
            (1 + owner.damageElementMultiplerAmplification.GetValueOrDefault(damageType, 0)) *
            (1 + owner.attackTypeMultiplerAmplification.GetValueOrDefault(attackType, 0));

        if (owner is Unit)
        {
            calculatedBaseDamage += ((Unit)owner).mainChars[amplificationChar] * damageBonusPerCharPoint;
            calculatedMultipler *= (1 + ((Unit)owner).mainChars[amplificationChar] * damageMultiplerPerCharPoint);
        }

        attack = new Damage(calculatedBaseDamage * calculatedMultipler, damageType, attackType);

        for (int i = 0; i < targets.Count; i++)
        {
            var target = targets[i].Item1;
            var map = targets[i].Item2;
            var affectedArea = areas[i].Item1;
            var isFlexible = areas[i].Item2;

            if (affectedArea.Count > 0)
            {
                var realTargetsCoords = new HashSet<Vector2Int>();
                HashSet<Vector2Int> realAffectedArea;

                // Отражение в случае необходимости области применения в сторону применения способности
                if (isFlexible)
                {
                    realAffectedArea = WorldController.FlexArea(affectedArea, target - owner.currentCell.coords);
                }
                else
                {
                    realAffectedArea = affectedArea;
                }

                // Определение координат попадающих под удар ячеек
                foreach (var affectedCoord in realAffectedArea)
                {
                    realTargetsCoords.Add(affectedCoord + target);
                }

                // Получение попадающих под удар ячеек
                targetCells = map.GetCells(realTargetsCoords);
            }
            else
            {
                targetCells = map.GetAllCells();
            }

            foreach (var cell in targetCells)
            {
                cell.AttackCell(attack, owner);
            }
        }
    }
}
