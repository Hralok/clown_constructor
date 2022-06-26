using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceInitInfo
{
    public int id { get; private set; }
    public int nameId { get; private set; }
    public int descriptionId { get; private set; }

    public ResourceInitInfo(
        int nameId,
        int descriptionId,
        TileBase tile,
        Sprite sprite
        )
    {
        id = Fabricator.AddResourceId();
        this.nameId = nameId;
        this.descriptionId = descriptionId;

        GraphicSupporter.AddResourceGraphic(id, tile, sprite);
        Fabricator.AddResourceInitInfo(this);
    }
}
