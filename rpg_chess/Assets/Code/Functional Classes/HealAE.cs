using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAE : AbilityEffect
{
    public Heal heal { get; private set; }

    public HealAE(
        HashSet<Vector2Int> targets, 
        HashSet<Vector2Int> affectedArea, 
        Ability ability,
        Heal heal) 
        : base(targets, affectedArea, ability)
    {
        this.heal = heal;
    }

    public override void DoTheStuff(Map map)
    {
        var targetCells = map.GetCells(targets);

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
