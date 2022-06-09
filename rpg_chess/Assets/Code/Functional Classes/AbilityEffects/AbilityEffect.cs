using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    protected Ability ability;
    public bool isFlexible { get; private set; }
    public bool isAbsolute { get; private set; }
    public HashSet<Vector2Int> affectedArea { get; private set; }
    // ”казывает на какие координаты относительно точки применени€ будет применЄн эффект способности.
    // ѕустое множество означает что умение будет применено ко всем €чейкам карты.


    public AbilityEffect(
        HashSet<Vector2Int> affectedArea, 
        Ability ability,
        bool isAbsolute,
        bool isFlexible
        )
    {
        this.ability = ability;
        this.isFlexible = isFlexible;
        this.isAbsolute = isAbsolute;

        if (affectedArea == null)
        {

        }
        else if (affectedArea.Count == 0)
        {
            affectedArea = new HashSet<Vector2Int>();
            affectedArea.Add(new Vector2Int(0, 0));
        }
        else
        {
            this.affectedArea = affectedArea;
        }
    }

    //protected HashSet<Vector2Int> FlexAffectedArea()
    //{

    //}

    public abstract void DoTheStuff(Map map, Vector2Int target);
}
