using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class GameController : MonoBehaviour
{
    public void Start()
    {
        Dictionary<int, int> test = new Dictionary<int, int>();

        test[0] = 1;
        test[1] = 5;


        Debug.Log(test.Sum(x => x.Value));
    }
}
