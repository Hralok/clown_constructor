using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public Entity owner { get; private set; }
    public HashSet<Vector2Int> targets { get; private set; }
    // Указываются координаты точки применения относительно применяющего.
    // Пустое множество означает что выбрать целью можно любую точку карты.
    // Указание координаты (0,0) равносильно применению на себя,
    // если позволяют условия способности.


    public Ability(Entity owner)
    {
        this.owner = owner;
    }

}
