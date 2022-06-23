using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EffectGroup
{
    readonly public List<AbilityEffect> effects;
    readonly public int delay;
    readonly public List<int> targetsIndexes;

    public EffectGroup(List<AbilityEffect> effects, int delay, List<int> targetsIndexes)
    {
        this.effects = effects;
        this.delay = delay;
        this.targetsIndexes = targetsIndexes;
    }
}

public struct TargetArea
{
    readonly public Map map;
    readonly public HashSet<Vector2Int> area;
    readonly public int targetsCount;
    readonly public HashSet<TargetRulesEnum> rules;
    readonly public bool isAbsolute;
    public TargetArea(
        Map map,
        HashSet<Vector2Int> area,
        bool isAbsolute,
        int targetsCount,
        HashSet<TargetRulesEnum> rules)
    {
        this.map = map;
        this.area = area;
        this.isAbsolute = isAbsolute;
        this.targetsCount = targetsCount;
        this.rules = rules;
    }
}



