using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAE : AbilityEffect
{
    public Map targetMap { get; private set; }

    public MoveAE(
        HashSet<Vector2Int> targets, 
        Map targetMap, 
        Ability ability) 
        : base(targets, null, ability)
    {
        this.targetMap = targetMap;
    }

    public abstract override void DoTheStuff(Map map, Vector2Int target);
    
}
