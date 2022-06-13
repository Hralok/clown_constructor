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
        Ability ability,
        List<(HashSet<Vector2Int>, bool)> areas,
        double baseHeal,
        HealTypeEnum healType,
        MainCharacteristicTypeEnum amplificationChar,
        double healBonusPerCharPoint,
        double healMultiplerPerCharPoint)
        : base(ability, areas)
    {
        this.baseHeal = baseHeal;
        this.healType = healType;
        this.amplificationChar = amplificationChar;
        this.healBonusPerCharPoint = healBonusPerCharPoint;
        this.healMultiplerPerCharPoint = healMultiplerPerCharPoint;
    }

    public override void DoTheStuff(List<(Vector2Int, Map)> targets)
    {
        if (targets.Count != areas.Count)
        {
            throw new System.Exception("Количество целей не соответствует необходимому!");
        }

        HashSet<Cell> targetCells;
        Heal heal;

        double calculatedBaseHeal;
        double calculatedMultipler;

        calculatedBaseHeal =
            baseHeal +
            ability.owner.healBonusAmplification +
            ability.owner.healElementBonusAmplification.GetValueOrDefault(healType, 0);

        calculatedMultipler =
            (1 + ability.owner.healMultiplerAmplification) *
            (1 + ability.owner.healElementMultiplerAmplification.GetValueOrDefault(healType, 0));

        if (ability.owner is Unit)
        {
            calculatedBaseHeal += ((Unit)ability.owner).mainChars[amplificationChar] * healBonusPerCharPoint;
            calculatedMultipler *= (1 + ((Unit)ability.owner).mainChars[amplificationChar] * healMultiplerPerCharPoint);
        }

        heal = new Heal(calculatedBaseHeal * calculatedMultipler, healType);

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
                    realAffectedArea = WorldController.FlexArea(affectedArea, target - ability.owner.currentCell.coords);
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
}
