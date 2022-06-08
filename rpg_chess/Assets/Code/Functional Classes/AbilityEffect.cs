using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    public HashSet<Vector2Int> targets { get; private set; }
    // ����������� ���������� ������������ ������������.
    // ������ ��������� �������� ���������� �� ��� �����.
    // �������� ���������� (0,0) ����������� ���������� �� ����,
    // ���� ��������� ������� �����������.

    public HashSet<Vector2Int> affectedArea { get; private set; }

    public AbilityEffect(HashSet<Vector2Int> targets, HashSet<Vector2Int> affectedArea)
    {
        this.targets = targets;

        if (affectedArea.Count == 0)
        {
            affectedArea = new HashSet<Vector2Int>();
            affectedArea.Add(new Vector2Int(0, 0));
        }
        else
        {
            this.affectedArea = affectedArea;
        }
    }

    public abstract void DoTheStuff(Map map);
}