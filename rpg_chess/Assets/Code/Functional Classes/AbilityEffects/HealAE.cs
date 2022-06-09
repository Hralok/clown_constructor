using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAE : AbilityEffect
{
    public Heal heal { get; private set; }

    public HealAE(
        HashSet<Vector2Int> affectedArea,
        Ability ability,
        Heal heal,
        bool isAbsolute,
        bool isFlexible)
        : base(affectedArea, ability, isAbsolute, isFlexible)
    {
        this.heal = heal;
    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {

        HashSet<Cell> targetCells;
        if (affectedArea.Count > 0)
        {
            var realTargetsCoords = new HashSet<Vector2Int>();

            foreach (var affectedCoord in affectedArea)
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
            if (cell.unitAtCell != null)
            {
                cell.unitAtCell.TakeHeal(heal, ability.owner);
            }

            if (cell.structureAtCell != null)
            {
                cell.structureAtCell.TakeHeal(heal, ability.owner);
            }
        }

    }
}
