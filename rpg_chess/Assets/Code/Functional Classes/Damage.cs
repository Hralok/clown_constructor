using System.Collections;
using System.Collections.Generic;

public class Damage
{
    public double damage { get; private set; }
    public DamageTypeEnum damageType { get; private set; }
    public AttackTypeEnum attackType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double damageBonusPerCharPoint { get; private set; }
    public double damageMultiplerPerCharPoint { get; private set; }

    public Damage(
        double damage, 
        DamageTypeEnum damageType, 
        AttackTypeEnum attackType, 
        MainCharacteristicTypeEnum amplificationChar,
        double damageBonusPerCharPoint,
        double damageMultiplerPerCharPoint)
    {
        if (damage < 0)
        {
            this.damage = 0;
        }
        else
        {
            this.damage = damage;
        }

        this.damageType = damageType;
        this.attackType = attackType;
        this.amplificationChar = amplificationChar;
        this.damageBonusPerCharPoint = damageBonusPerCharPoint;
        this.damageMultiplerPerCharPoint = damageMultiplerPerCharPoint;
    }

}
