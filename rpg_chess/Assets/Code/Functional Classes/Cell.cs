using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Vector2 coords { get; private set; }
    public Unit unitAtCell { get; private set; }
    public Structure structureAtCell { get; private set; }
    public List<Resource> resourcesAtCell { get; private set; }
    //public HashSet

    public List<Item> itemsAtCell { get; private set; }

    public Cell(Vector2 coords)
    {
        this.coords = coords;
        unitAtCell = null;
        structureAtCell = null;
        resourcesAtCell = new List<Resource>();
        itemsAtCell = new List<Item>();
    }

    public Unit ExpelUnit()
    {
        var expeledUnit = unitAtCell;
        unitAtCell = null;
        return expeledUnit;
    }

    public Structure ExpelStructure()
    {
        var expeledStructure = structureAtCell;
        structureAtCell = null;
        return expeledStructure;
    }

    public List<Resource> ExpelResources()
    {
        var expeledResources = resourcesAtCell;
        resourcesAtCell = null;
        return expeledResources;
    }

    public void AddResources(List<Resource> newResources)
    {

    }

    public void AcceptEntity(Entity entity)
    {
        switch (entity)
        {
            case Unit unit:
                unitAtCell = unit;
                break;
            case Structure structure:
                structureAtCell = structure;
                break;
        }
    }





}
