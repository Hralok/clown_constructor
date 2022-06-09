using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] obj;

    
    void Start()
    {
        HashSet<Vector2Int> area = new HashSet<Vector2Int>() { 
            new Vector2Int (0,1),
            new Vector2Int (0,2),
            new Vector2Int (0,3),
            new Vector2Int (0,4),
            new Vector2Int (1,3),
            new Vector2Int (-1,3),
        };

        Vector2Int point = new Vector2Int (0, -1);

        area = WorldController.FlexArea(area, point);

        int i = 0;
        foreach (Vector2Int newPoint in area)
        {
            obj[i].transform.position = (Vector3Int)newPoint;
            i++;
        }





    }

    
}
