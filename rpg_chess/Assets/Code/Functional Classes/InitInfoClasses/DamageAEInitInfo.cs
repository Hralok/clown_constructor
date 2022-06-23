using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAEInitInfo : AbilityEffectInitInfo
{
    public double baseDamage { get; private set; }
    public DamageTypeEnum damageType { get; private set; }
    public AttackTypeEnum attackType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double damageBonusPerCharPoint { get; private set; }
    public double damageMultiplerPerCharPoint { get; private set; }

    public DamageAEInitInfo(
        List<(HashSet<Vector2Int>, bool)> areas,
        double baseDamage,
        DamageTypeEnum damageType,
        AttackTypeEnum attackType,
        MainCharacteristicTypeEnum amplificationChar,
        double damageBonusPerCharPoint,
        double damageMultiplerPerCharPoint) : base(areas)
    {
        if (baseDamage < 0)
        {
            throw new System.Exception("baseDamage не может быть отрицательным!");
        }
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.attackType = attackType;
        this.amplificationChar = amplificationChar;

        if (damageBonusPerCharPoint < 0)
        {
            throw new System.Exception("damageBonusPerCharPoint не может быть отрицательным!");
        }
        this.damageBonusPerCharPoint = damageBonusPerCharPoint;

        if (damageMultiplerPerCharPoint < 0)
        {
            throw new System.Exception("damageMultiplerPerCharPoint не может быть отрицательным!");
        }
        this.damageMultiplerPerCharPoint = damageMultiplerPerCharPoint;
    }
}
