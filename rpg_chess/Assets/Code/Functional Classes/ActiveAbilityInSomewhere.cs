using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilityInSomewhere : ICloneable
{
    public double curentCooldown;
    readonly public int abilityId;

    public ActiveAbilityInSomewhere(int abilityId)
    {
        curentCooldown = 0;
        this.abilityId = abilityId;
    }

    public object Clone()
    {
        return new ActiveAbilityInSomewhere(abilityId);
    }
}
