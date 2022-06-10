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

        if (ability.owner is Unit)
        {
            var attacker = (Unit)ability.owner;
            attack = new Damage(
                (baseDamage + attacker.mainChars[amplificationChar] * damageBonusPerCharPoint) *
                (1 + attacker.mainChars[amplificationChar] * damageMultiplerPerCharPoint),
                damageType,
                attackType);
        }
        else
        {
            attack = new Damage(baseDamage, damageType, attackType);
        }

        if (affectedArea.Count > 0)
        {
            var realTargetsCoords = new HashSet<Vector2Int>();
            HashSet<Vector2Int> realAffectedArea;

            if (isFlexible)
            {
                realAffectedArea = WorldController.FlexArea(affectedArea, target);
            }
            else
            {
                realAffectedArea = affectedArea;
            }

            foreach (var affectedCoord in realAffectedArea)
            {
                realTargetsCoords.Add(affectedCoord + target + ability.owner.currentCell.coords);
            }

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
