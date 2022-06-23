using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect
{
    public List<(HashSet<Vector2Int>, bool)> areas { get; private set; }

    // ������ �������� ������� ��������� �� ����� ���������� ������������ ����� ���������� ����� ������� ������ �����������.
    // ������ ��������� �������� ��� ������ ����� ��������� �� ���� ������� �����.
    // ������ �������� ������� ��������� ���������� �� ��������� ������� ���������� � ������� ����������

    public AbilityEffect(AbilityEffectInitInfo info)
    {
        areas = info.areas;
    }

    public abstract void DoTheStuff(List<(Vector2Int, Map)> targets, Entity owner);
}
