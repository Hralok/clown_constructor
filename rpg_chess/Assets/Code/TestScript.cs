using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    

    
    void Start()
    {
        Vector2Int a = new Vector2Int(1, 1);
        Vector2Int b = new Vector2Int(2, 2);

        Debug.Log(a - b);
        Debug.Log(b - a);

    }

    
}
