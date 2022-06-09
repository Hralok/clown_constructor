using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldController
{
    public static HashSet<Vector2Int> FlexArea(HashSet<Vector2Int> baseArea, Vector2Int flexPoint)
    {
        HashSet<Vector2Int> result = new HashSet<Vector2Int>();

        if (Mathf.Abs(flexPoint.y) >= Mathf.Abs(flexPoint.x) && flexPoint.y >= 0)
        {
            result = baseArea;
        }
        else if (Mathf.Abs(flexPoint.y) >= Mathf.Abs(flexPoint.x) && flexPoint.y < 0)
        {
            foreach (Vector2Int point in baseArea)
            {
                result.Add(new Vector2Int(-point.x, -point.y));
            }
        }
        else if (Mathf.Abs(flexPoint.y) < Mathf.Abs(flexPoint.x) && flexPoint.x >= 0)
        {
            foreach (Vector2Int point in baseArea)
            {
                result.Add(new Vector2Int(point.y, -point.x));
            }
        }
        else
        {
            foreach (Vector2Int point in baseArea)
            {
                result.Add(new Vector2Int(-point.y, point.x));
            }
        }

        return result;
    }

    public static void MakeDamageDecision(Damage attack, Entity attacker, Entity victim)
    {

    }

}