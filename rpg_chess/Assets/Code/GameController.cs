using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class GameController : MonoBehaviour
{
    public void Start()
    {
        HashSet<int> test = new HashSet<int>() { 1, 2, 3, 4 };

        Debug.Log(test.Remove(1));
        Debug.Log(test.Remove(0));
        Debug.Log(test.Add(2));
    }
}
