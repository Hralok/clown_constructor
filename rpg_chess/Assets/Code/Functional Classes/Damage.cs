using System.Collections;
using System.Collections.Generic;

public class Damage
{
    public double damage { get; private set; }
    public DamageTypeEnum damageType { get; private set; }
    public AttackTypeEnum attackType { get; private set; }

    public Damage(double damage, DamageTypeEnum damageType, AttackTypeEnum attackType)
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
    }

}
