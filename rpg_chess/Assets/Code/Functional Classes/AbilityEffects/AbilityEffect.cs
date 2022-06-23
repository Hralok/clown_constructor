using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    public List<(HashSet<Vector2Int>, bool)> areas { get; private set; }

    // ѕервый параметр кортежа указывает на какие координаты относительно точки применени€ будет применЄн эффект способности.
    // ѕустое множество означает что умение будет применено ко всем €чейкам карты.
    // ¬торой параметр кортежа указывает необходимо ли повернуть область применени€ в сторону применени€

    public AbilityEffect(AbilityEffectInitInfo info)
    {
        areas = info.areas;
    }

    public abstract void DoTheStuff(List<(Vector2Int, Map)> targets, Entity owner);
}
