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


    public HealAE(HealAEInitInfo info)
        : base(info)
    {
        this.baseHeal = info.baseHeal;
        this.healType = info.healType;
        this.amplificationChar = info.amplificationChar;
        this.healBonusPerCharPoint = info.healBonusPerCharPoint;
        this.healMultiplerPerCharPoint = info.healMultiplerPerCharPoint;
    }

    public override void DoTheStuff(List<(Vector2Int, Map)> targets, Entity owner)
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
            owner.healBonusAmplification +
            owner.healElementBonusAmplification.GetValueOrDefault(healType, 0);

        calculatedMultipler =
            (1 + owner.healMultiplerAmplification) *
            (1 + owner.healElementMultiplerAmplification.GetValueOrDefault(healType, 0));

        if (owner is Unit)
        {
            calculatedBaseHeal += ((Unit)owner).mainChars[amplificationChar] * healBonusPerCharPoint;
            calculatedMultipler *= (1 + ((Unit)owner).mainChars[amplificationChar] * healMultiplerPerCharPoint);
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

                targetCells = map.GetCells(realTargetsCoords);
            }
            else
            {
                targetCells = map.GetAllCells();
            }

            foreach (var cell in targetCells)
            {
                cell.HealCell(heal, owner);
            }
        }
    }
}
