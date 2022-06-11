using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAE : AbilityEffect
{
    public bool onlyUnits { get; private set; }
    public List<Vector2Int> fromArea { get; private set; }
    public List<Vector2Int> toArea { get; private set; }
    public bool fromIsFlexible { get; private set; }
    public bool toIsFlexible { get; private set; }
    public bool needSecondTarget { get; private set; }
    public Vector2Int offset { get; private set; }

    public MoveAE(
        Ability ability,
        bool onlyUnits,
        List<(Vector2Int, Vector2Int)> moves,
        bool fromIsFlexible,
        bool toIsFlexible,
        bool needSecondTarget,
        Vector2Int offset)
        : base(ability, null)
    {
        this.fromArea = new List<Vector2Int>();
        this.toArea = new List<Vector2Int>();

        this.onlyUnits = onlyUnits;
        this.fromIsFlexible = fromIsFlexible;
        this.toIsFlexible = toIsFlexible;
        this.needSecondTarget = needSecondTarget;
        this.offset = offset;

        for (int i = 0; i < moves.Count; i++)
        {
            fromArea.Add(moves[i].Item1);
            toArea.Add(moves[i].Item2);
        }
    }

    public override void DoTheStuff(List<(Vector2Int, Map)> targets)
    {
        if (needSecondTarget && targets.Count != 2 || !needSecondTarget && targets.Count != 1)
        {
            throw new System.Exception("Количество целей не соответствует необходимому!");
        }

        List<Vector2Int> realFromArea;
        List<Vector2Int> realToArea;
        Vector2Int realToPoint;
        Map realToMap;


        if (fromIsFlexible)
        {
            realFromArea = WorldController.FlexArea(fromArea, targets[0].Item1 - ability.owner.currentCell.coords);
        }
        else
        {
            realFromArea = fromArea;
        }

        if (needSecondTarget)
        {
            realToPoint = targets[1].Item1;
            realToMap = targets[1].Item2;
            if (toIsFlexible)
            {
                realToArea = WorldController.FlexArea(toArea, targets[1].Item1 - targets[0].Item1);
            }
            {
                realToArea = toArea;
            }
        }
        else
        {
            realToPoint = targets[0].Item1 + offset;
            realToMap = targets[0].Item2;
            if (toIsFlexible)
            {
                realToArea = WorldController.FlexArea(toArea, targets[0].Item1 - ability.owner.currentCell.coords);
            }
            else
            {
                realToArea = toArea;
            }
        }

        Cell currentCell;

        for (int i = 0; i < realFromArea.Count; i++)
        {
            currentCell = targets[0].Item2.GetCell(realFromArea[i] + targets[0].Item1);

            if (currentCell != null)
            {
                if (currentCell.unitAtCell != null)
                {
                    WorldController.MakeMoveDecision((currentCell.coords, realToArea[i] + realToPoint), currentCell.unitAtCell, realToMap);
                }

                if (!onlyUnits && currentCell.structureAtCell != null)
                {
                    WorldController.MakeMoveDecision((currentCell.coords, realToArea[i] + realToPoint), currentCell.structureAtCell, realToMap);
                }
            }
        }
    }
}
