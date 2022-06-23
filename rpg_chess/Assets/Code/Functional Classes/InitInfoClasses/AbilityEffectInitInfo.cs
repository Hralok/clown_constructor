using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEffectInitInfo
{
    public List<(HashSet<Vector2Int>, bool)> areas { get; private set; }

    public AbilityEffectInitInfo(List<(HashSet<Vector2Int>, bool)> areas)
    {
        foreach (var area in areas)
        {
            if (area.Item1 == null)
            {
                throw new System.Exception("������� ���������� ����������� �� ����� ���� null!");
            }
        }

        this.areas = areas;
    }
}
