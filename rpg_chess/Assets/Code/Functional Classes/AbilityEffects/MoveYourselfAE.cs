using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYourselfAE : MoveAE
{
    public MoveYourselfAE(
        HashSet<Vector2Int> targets, 
        Map targetMap, 
        Ability ability) 
        : base(targets, targetMap, ability)
    {

    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {
        // ѕредполагаетс€ что указанна€ точка дл€ перемещени€ а) существует б) не зан€та
        if (targets.Contains(target) && ability.owner is Unit)
        {
            var realTargetCoords = target + ability.owner.currentCell.coords;

            if (targetMap == null)
            {
                
            }    
        }
    }
}
