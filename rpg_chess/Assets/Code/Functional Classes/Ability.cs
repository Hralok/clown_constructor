using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    public HashSet<Vector2Int> targets { get; private set; }



    public abstract int DoTheTurnStuff(Entity owner, int currentEffectGroup, List<(Vector2Int, Map)> targetsList);
        

}
