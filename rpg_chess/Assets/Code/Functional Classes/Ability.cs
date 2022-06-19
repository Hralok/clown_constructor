using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    public HashSet<Vector2Int> targets { get; private set; }



    public abstract void DoTheTurnStuff(Entity owner);
        

}
