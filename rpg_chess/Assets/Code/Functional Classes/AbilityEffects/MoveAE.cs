using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class MoveAE : AbilityEffect
{
    public Map targetMap { get; private set; }
    
    public bool onlyUnits { get; private set; }
    public MoveAE(
        Map targetMap, 
        Ability ability,
        bool isAbsolute,
        bool onlyUnits,
        bool isFlexible)
        : base(null, ability, isAbsolute, isFlexible)
    {
        this.targetMap = targetMap;
        this.onlyUnits = onlyUnits;
    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {
         





        if (ability.owner is Unit)
        {
            Vector2Int realTargetCoords;
            if (isAbsolute)
            {
                realTargetCoords = target;
            }
            else
            {
                realTargetCoords = target + ability.owner.currentCell.coords;
            }



            Map curMap;
            if (targetMap == null)
            {
                curMap = map;
            }
            else
            {
                curMap = targetMap;
            }

            Cell targetCell = curMap.GetCell(realTargetCoords);

            targetCell.AddEntity(ability.owner);
            ability.owner.currentCell.ExpelUnit();
            ability.owner.MoveToCell(targetCell);
        }
    }

}
