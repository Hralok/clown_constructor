using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAE : AbilityEffect
{
    public double baseHeal { get; private set; }
    public HealTypeEnum healType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double healBonusPerCharPoint { get; private set; }
    public double healMultiplerPerCharPoint { get; private set; }


    public HealAE(
        HashSet<Vector2Int> affectedArea,
        Ability ability,
        bool isAbsolute,
        bool isFlexible,
        double baseHeal,
        HealTypeEnum healType,
        MainCharacteristicTypeEnum amplificationChar,
        double healBonusPerCharPoint,
        double healMultiplerPerCharPoint)
        : base(affectedArea, ability, isAbsolute, isFlexible)
    {
        this.baseHeal = baseHeal;
        this.healType = healType;
        this.amplificationChar = amplificationChar;
        this.healBonusPerCharPoint = healBonusPerCharPoint;
        this.healMultiplerPerCharPoint = healMultiplerPerCharPoint;
    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {

        HashSet<Cell> targetCells;
        Heal heal;

        if (ability.owner is Unit)
        {
            var healer = (Unit)ability.owner;
            heal = new Heal(
                (baseHeal + healer.mainChars[amplificationChar] * healBonusPerCharPoint) *
                (1 + healer.mainChars[amplificationChar] * healMultiplerPerCharPoint),
                healType);
        }
        else
        {
            heal = new Heal(baseHeal, healType);
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
            cell.HealCell(heal, ability.owner);
        }

    }
}
