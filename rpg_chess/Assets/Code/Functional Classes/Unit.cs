using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public UnitStateEnum state { get; set; }
    public Unit (Cell cell)
    {
        currentCell = cell;
        state = UnitStateEnum.Free;
    }
}
