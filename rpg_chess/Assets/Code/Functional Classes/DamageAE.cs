using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAE : AbilityEffect
{
    public Damage damage { get; private set; }

    public DamageAE(
        HashSet<Vector2Int> targets,
        HashSet<Vector2Int> affectedArea,
        Ability ability,
        Damage damage)
        : base(targets, affectedArea, ability)
    {
        this.damage = damage;
    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {
        if (targets.Contains(target))
        {




            var targetCells = map.GetCells(targets);

            foreach (var cell in targetCells)
            {
                if (cell.unitAtCell != null)
                {
                    cell.unitAtCell.TakeDamage(damage, ability.owner);
                }

                if (cell.structureAtCell != null)
                {
                    cell.structureAtCell.TakeDamage(damage, ability.owner);
                }
            }
        }
    }
}
