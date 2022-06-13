using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitAfterAnimationSupporter : MonoBehaviour
{
    public TileBase replacementTile;
    public Tilemap targetTilemap;
    public Vector3Int coords;

    public void ReplaceTile()
    {
        targetTilemap.SetTile(coords, replacementTile);
        Destroy(gameObject);
    }
}
