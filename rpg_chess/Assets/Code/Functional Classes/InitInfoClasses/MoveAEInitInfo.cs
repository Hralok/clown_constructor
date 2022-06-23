using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAEInitInfo : AbilityEffectInitInfo
{
    public bool onlyUnits { get; private set; }
    public List<Vector2Int> fromArea { get; private set; }
    public List<Vector2Int> toArea { get; private set; }
    public bool fromIsFlexible { get; private set; }
    public bool toIsFlexible { get; private set; }
    public bool needSecondTarget { get; private set; }
    public Vector2Int offset { get; private set; }


    public MoveAEInitInfo(bool onlyUnits,
        List<(Vector2Int, Vector2Int)> moves,
        bool fromIsFlexible,
        bool toIsFlexible,
        bool needSecondTarget,
        Vector2Int offset) : base(null)
    {
        fromArea = new List<Vector2Int>();
        toArea = new List<Vector2Int>();

        this.onlyUnits = onlyUnits;
        this.fromIsFlexible = fromIsFlexible;
        this.toIsFlexible = toIsFlexible;
        this.needSecondTarget = needSecondTarget;
        if (needSecondTarget && offset == null)
        {
            throw new System.Exception("offset не может быть null!");
        }
        this.offset = offset;

        for (int i = 0; i < moves.Count; i++)
        {
            if (moves[i].Item1 == null)
            {
                throw new System.Exception(" оордината премещени€ не может быть null!");
            }
            fromArea.Add(moves[i].Item1);

            if (moves[i].Item2 == null)
            {
                throw new System.Exception(" оордината дл€ премещени€ не может быть null!");
            }
            toArea.Add(moves[i].Item2);
        }
    }
}
