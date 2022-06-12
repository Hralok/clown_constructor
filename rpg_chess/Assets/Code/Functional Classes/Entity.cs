using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity 
{
    public Cell currentCell { get; protected set; }

    public void LeaveCell()
    {
        currentCell = null;
    }

    public void GoToCell(Cell targetCell)
    {
        currentCell = targetCell;
    }




}
