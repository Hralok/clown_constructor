using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "VinTools/Custom Tiles/Variable Tile")]
public class VariableTile : TileBase
{
    private int counter;
    public VariableTile(Sprite[] standSprites, Sprite[] attackSprites)
    {
        this.attackSprites = attackSprites;
        this.standSprites = standSprites;

        counter = 0;

        currentSprites = attackSprites;
    }



    public Sprite[] standSprites;

    public Sprite[] attackSprites;

    private Sprite[] currentSprites;

    public float m_MinSpeed = 4f;

    public float m_MaxSpeed = 4f;

    public float m_AnimationStartTime;

    public int m_AnimationStartFrame;

    public Tile.ColliderType m_TileColliderType;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        counter++;
        Debug.Log(counter);

        tileData.transform = Matrix4x4.identity;
        tileData.color = Color.white;

        if (counter == 1)
        {
            tileData.sprite = currentSprites[currentSprites.Length - 1];
            tileData.colliderType = m_TileColliderType;
        }
        else if (counter == 2)
        {
            currentSprites = standSprites;
            tileData.sprite = currentSprites[currentSprites.Length - 1];
            tileData.colliderType = m_TileColliderType;
        }
    }

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        if (standSprites.Length != 0)
        {
            tileAnimationData.animatedSprites = currentSprites;
            tileAnimationData.animationSpeed = Random.Range(m_MinSpeed, m_MaxSpeed);
            tileAnimationData.animationStartTime = m_AnimationStartTime;
            if (0 < m_AnimationStartFrame && m_AnimationStartFrame <= currentSprites.Length)
            {
                Tilemap component = tilemap.GetComponent<Tilemap>();
                if (component != null && component.animationFrameRate > 0f)
                {
                    tileAnimationData.animationStartTime = (float)(m_AnimationStartFrame - 1) / component.animationFrameRate;
                }
            }

            return true;
        }

        return false;
    }


    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {

        base.RefreshTile(position, tilemap);
    }
}