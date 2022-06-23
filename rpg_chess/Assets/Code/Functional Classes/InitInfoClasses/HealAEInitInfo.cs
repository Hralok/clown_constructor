using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAEInitInfo : AbilityEffectInitInfo
{
    public double baseHeal { get; private set; }
    public HealTypeEnum healType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double healBonusPerCharPoint { get; private set; }
    public double healMultiplerPerCharPoint { get; private set; }

    public HealAEInitInfo(
        List<(HashSet<Vector2Int>, bool)> areas,
        double baseHeal,
        HealTypeEnum healType,
        MainCharacteristicTypeEnum amplificationChar,
        double healBonusPerCharPoint,
        double healMultiplerPerCharPoint) : base(areas)
    {
        if (baseHeal < 0)
        {
            throw new System.Exception("baseHeal �� ����� ���� �������������!");
        }
        this.baseHeal = baseHeal;
        this.healType = healType;
        this.amplificationChar = amplificationChar;

        if (healBonusPerCharPoint < 0)
        {
            throw new System.Exception("healBonusPerCharPoint �� ����� ���� �������������!");
        }
        this.healBonusPerCharPoint = healBonusPerCharPoint;

        if (healMultiplerPerCharPoint < 0)
        {
            throw new System.Exception("healMultiplerPerCharPoint �� ����� ���� �������������!");
        }
        this.healMultiplerPerCharPoint = healMultiplerPerCharPoint;
    }
}
