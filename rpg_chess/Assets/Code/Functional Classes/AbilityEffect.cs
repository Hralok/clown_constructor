using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    protected Ability ability;

    public HashSet<Vector2Int> targets { get; private set; }
    // ”казываютс€ координаты точки применени€ относительно примен€ющего.
    // ѕустое множество означает что выбрать целью можно любую точку карты.
    // ”казание координаты (0,0) равносильно применению на себ€,
    // если позвол€ют услови€ способности.

    public HashSet<Vector2Int> affectedArea { get; private set; }
    // ”казывает на какие координаты относительно точки применени€ будет применЄн эффект способности.
    // ѕустое множество означает что умение будет применено ко всем €чейкам карты.


    public AbilityEffect(HashSet<Vector2Int> targets, HashSet<Vector2Int> affectedArea, Ability ability)
    {
        this.targets = targets;
        this.ability = ability;

        if (affectedArea.Count == 0)
        {
            affectedArea = new HashSet<Vector2Int>();
            affectedArea.Add(new Vector2Int(0, 0));
        }
        else
        {
            this.affectedArea = affectedArea;
        }
    }

    public abstract void DoTheStuff(Map map, Vector2Int target);
}
