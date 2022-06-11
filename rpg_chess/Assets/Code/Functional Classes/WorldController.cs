using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldController
{
    public static T FlexArea<T>(T baseArea, Vector2Int flexPoint) where T : ICollection<Vector2Int>, new()
    {
        T result = new T();

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

    public static void MakeHealDecision(Heal heal, Entity healer, Entity curable)
    {

    }

    public static void MakeMoveDecision((Vector2Int, Vector2Int) fromToPair, Entity movable, Map targetMap)
    {

    }
}
