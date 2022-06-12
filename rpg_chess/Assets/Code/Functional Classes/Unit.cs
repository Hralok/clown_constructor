using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public Cell currentCell;
    public Unit (Cell cell)
    {
        currentCell = cell;
    }
}
