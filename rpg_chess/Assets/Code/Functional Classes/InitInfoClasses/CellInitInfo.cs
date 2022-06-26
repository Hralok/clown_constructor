using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellInitInfo
{
    public int typeId { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }
    public CellInitInfo(
        int nameId,
        int descriptionId,
        (TileBase, TileBase) tilePair
        )
    {
        typeId = Fabricator.AddCellId();
        this.nameId = nameId;
        this.descriptionId = descriptionId;

        GraphicSupporter.AddCellTile(typeId, tilePair.Item1, tilePair.Item2);
        Fabricator.AddCellInitInfo(this);
    }






}
