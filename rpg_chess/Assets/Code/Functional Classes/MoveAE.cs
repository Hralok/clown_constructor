using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYourselfAE : AbilityEffect
{
    public Map targetMap { get; private set; }

    public MoveYourselfAE(
        HashSet<Vector2Int> targets, 
        Map targetMap, 
        Ability ability) 
        : base(targets, null, ability)
    {
        this.targetMap = targetMap;
    }

    public override void DoTheStuff(Map map)
    {
        if (ability.owner is Unit)
        {






        }
    }
}
