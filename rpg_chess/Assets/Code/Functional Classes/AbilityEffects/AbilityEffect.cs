using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    protected Ability ability;
    public List<(HashSet<Vector2Int>, bool)> areas { get; private set; }

    // ѕервый параметр кортежа указывает на какие координаты относительно точки применени€ будет применЄн эффект способности.
    // ѕустое множество означает что умение будет применено ко всем €чейкам карты.
    // ¬торой параметр кортежа указывает необходимо ли повернуть область применени€ в сторону применени€

    public AbilityEffect(
        Ability ability,
        List<(HashSet<Vector2Int>, bool)> areas
        )
    {
        this.ability = ability;
        this.areas = areas;

        foreach (var area in areas)
        {
            if (area.Item1 == null)
            {
                throw new System.Exception("ќбласть пременени€ способности не может быть null!");
            }
        }
    }

    public abstract void DoTheStuff(List<(Vector2Int, Map)> targets);
}
