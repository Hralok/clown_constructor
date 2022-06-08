using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAE : AbilityEffect
{
    Damage damage;

    public DamageAE(HashSet<Vector2Int> targets, HashSet<Vector2Int> affectedArea, Damage damage) : base(targets, affectedArea)
    {
        this.damage = damage;
    }

    public override void DoTheStuff(Map map)
    {
        var targetCells = map.GetCells(targets);

        foreach (var cell in targetCells)
        {
            if (cell.unitAtCell != null)
            {
                cell.unitAtCell.TakeDamage(damage);
            }
        }




    }
}
