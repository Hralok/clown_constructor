using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAE : AbilityEffect
{
    public bool onlyUnits { get; private set; }
    public HashSet<Vector2Int> fromArea { get; private set; }
    public HashSet<Vector2Int> toArea { get; private set; }

    public Map fromTargetMap { get; private set; }
    public bool fromIsAbsolute { get; private set; }
    public bool fromIsFlexible { get; private set; }
    public Map toTargetMap { get; private set; }
    public bool toIsAbsolute { get; private set; }
    public bool toIsFlexible { get; private set; }
    public bool needSecondTarget { get; private set; }


    public MoveAE(
        Ability ability,
        bool onlyUnits,
        Map fromTargetMap,
        bool fromIsAbsolute,
        bool fromIsFlexible,
        Map toTargetMap,
        bool toIsAbsolute,
        bool toIsFlexible,
        List<(Vector2Int, Vector2Int)> moves)
        : base(null, ability, false)
    {
        this.fromArea = new HashSet<Vector2Int>();
        this.toArea = new HashSet<Vector2Int>();

        this.onlyUnits = onlyUnits;
        this.fromTargetMap = fromTargetMap;
        this.fromIsAbsolute = fromIsAbsolute;
        this.fromIsFlexible = fromIsFlexible;
        this.toTargetMap = toTargetMap;
        this.toIsAbsolute = toIsAbsolute;
        this.toIsFlexible = toIsFlexible;

        foreach (var move in moves)
        {
            fromArea.Add(move.Item1);
            toArea.Add(move.Item2);
        }
    }

    public void DoTheStuff(Map map, Vector2Int target1, Vector2Int target2)
    {

    }

    public override void DoTheStuff(Map map, Vector2Int target)
    {

        if (ability.owner is Unit)
        {
            Vector2Int realTargetCoords;



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
