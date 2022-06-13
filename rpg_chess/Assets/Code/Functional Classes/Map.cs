using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private Dictionary<Vector2Int, Cell> cellMap;
    public string name { get; private set; }

    public Map(string name)
    {
        cellMap = new Dictionary<Vector2Int, Cell>();
        this.name = name;  
    }

    public Cell GetCell(Vector2Int coords)
    {
        if (cellMap.ContainsKey(coords))
        {
            return cellMap[coords];
        }
        else
        {
            return null;
        }
    }

    public HashSet<Cell> GetCells(HashSet<Vector2Int> coords)
    {
        HashSet<Cell> cells = new HashSet<Cell>();

        foreach (Vector2Int coord in coords)
        {
            if (!cellMap.ContainsKey(coord))
            {
                cells.Add(cellMap[coord]);
            }
        }

        return cells;
    }

    public bool DoesCellExist(Vector2Int coords)
    {
        return cellMap.ContainsKey(coords);
    }

    public Cell ExpelCell(Vector2Int coords)
    {
        if (cellMap.ContainsKey(coords))
        {
            Cell cell = cellMap[coords];
            cellMap.Remove(coords);
            return cell;
        }
        else
        {
            throw new System.Exception("Произошла попытка удалить несуществующую ячейку");
        }
    }

    public HashSet<Cell> GetAllCells()
    {
        HashSet<Cell> cells = new HashSet<Cell>();

        foreach (Cell cell in cellMap.Values)
        {
            cells.Add(cell);
        }

        return cells;
    }

    public void AddCell(Cell newCell)
    {
        if (cellMap.ContainsKey(newCell.coords))
        {
            throw new System.Exception("Произошла попытка добавить ячейку в карту на уже занятое место");
        }
        else
        {
            cellMap[newCell.coords] = newCell;
        }
    }

    public void AddCells(HashSet<Cell> newCells)
    {
        foreach (Cell newCell in newCells)
        {
            if (cellMap.ContainsKey(newCell.coords))
            {
                throw new System.Exception("Произошла попытка добавить ячейку в карту на уже занятое место");
            }
            else
            {
                cellMap[newCell.coords] = newCell;
            }
        }
    }
}
