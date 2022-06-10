using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    protected Ability ability;
    public List<(HashSet<Vector2Int>, bool)> areas { get; private set; }

    // ������ �������� ������� ��������� �� ����� ���������� ������������ ����� ���������� ����� ������� ������ �����������.
    // ������ ��������� �������� ��� ������ ����� ��������� �� ���� ������� �����.
    // ������ �������� ������� ��������� ���������� �� ��������� ������� ���������� � ������� ����������

    public AbilityEffect(
        Ability ability,
        List<(HashSet<Vector2Int>, bool)> areas
        )
    {
        this.ability = ability;
        this.areas = areas;

        foreach (var area in areas)
        {
            if (area.Item1 == null)
            {
                throw new System.Exception("������� ���������� ����������� �� ����� ���� null!");
            }
        }
    }

    public abstract void DoTheStuff(List<(Vector2Int, Map)> targets);
}
