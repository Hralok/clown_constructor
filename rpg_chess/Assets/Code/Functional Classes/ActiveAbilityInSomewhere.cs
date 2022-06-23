using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilityInSomewhere
{
    public double curentCooldown;
    readonly public int abilityId;

    public ActiveAbilityInSomewhere(int abilityId)
    {
        curentCooldown = 0;
        this.abilityId = abilityId;
    }
}
