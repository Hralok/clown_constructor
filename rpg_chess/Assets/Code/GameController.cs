using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class GameController : MonoBehaviour
{
    public void Start()
    {
        Dictionary<AttackTypeEnum, double> test = new Dictionary<AttackTypeEnum, double>();
        test.Add(AttackTypeEnum.Range, 1);

        var test2 = new Dictionary<AttackTypeEnum, double>(test);

        test2[AttackTypeEnum.Range] = 3;

        Debug.Log(test[AttackTypeEnum.Range]);

    }
}
