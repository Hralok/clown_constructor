using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Cell currentCell { get; private set; }
    public double healthPoints { get; private set; }
    public HashSet<EntityTypeEnum> selfTypes { get; private set; }
    public List<(int, EntityTypeEnum)> acquiredTypes { get; private set; }

    public Entity()
    {
        acquiredTypes = new List<(int, EntityTypeEnum)>();
    }

    public void LeaveCell()
    {
        currentCell = null;
    }

    public void GoToCell(Cell targetCell)
    {
        currentCell = targetCell;
    }

    public void TakeDamage(Damage damage)
    {

    }


}
