using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbility : Ability
{
    public override int DoTheTurnStuff(Entity owner, int currentEffectGroup, List<(Vector2Int, Map)> targetsList)
    {
        throw new System.NotImplementedException();
    }
}
