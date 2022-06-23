using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilityInitInfo
{
    public List<TargetArea> targetAreas { get; private set; }
    public List<EffectGroup> effects { get; private set; } 
    public bool interruptible { get; private set; }
    public double maxCooldown { get; private set; }
    public int descriptionTextIndex { get; private set; }

    public ActiveAbilityInitInfo(
        )
    {

    }





}
