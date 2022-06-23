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

    public MoveAE(MoveAEInitInfo info)
        : base(info)
    {
        fromArea = info.fromArea;
        toArea = info.toArea;
        onlyUnits = info.onlyUnits;
        fromIsFlexible = info.fromIsFlexible;
        toIsFlexible = info.toIsFlexible;
        needSecondTarget = info.needSecondTarget;
        offset = info.offset;
    }

    public override void DoTheStuff(List<(Vector2Int, Map)> targets, Entity owner)
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
            realFromArea = WorldController.FlexArea(fromArea, targets[0].Item1 - owner.currentCell.coords);
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
                realToArea = WorldController.FlexArea(toArea, targets[0].Item1 - owner.currentCell.coords);
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
