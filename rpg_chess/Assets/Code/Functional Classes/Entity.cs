using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Cell currentCell { get; private set; }
    public double healthPoints { get; private set; }
    public HashSet<EntityTypeEnum> selfTypes { get; private set; }
    public List<(int, EntityTypeEnum)> acquiredTypes { get; private set; }
    public double damageBonusAmplification { get; private set; }
    public double damageMultiplerAmplification { get; private set; }
    public double healBonusAmplification { get; private set; }
    public double healMultiplerAmplification { get; private set; }
    public Dictionary<DamageTypeEnum, double> damageElementBonusAmplification { get; private set; }
    public Dictionary<DamageTypeEnum, double> damageElementMultiplerAmplification { get; private set; }
    public Dictionary<HealTypeEnum, double> healElementBonusAmplification { get; private set; }
    public Dictionary<HealTypeEnum, double> healElementMultiplerAmplification { get; private set; }
    public Dictionary<AttackTypeEnum, double> attackTypeBonusAmplification { get; private set; }
    public Dictionary<AttackTypeEnum, double> attackTypeMultiplerAmplification { get; private set; }
    public bool busy { get; private set; }
    public ActiveAbility currentAbility { get; private set; }





    public Entity()
    {
        acquiredTypes = new List<(int, EntityTypeEnum)>();
    }

    public void MoveToCell(Cell targetCell)
    {
        currentCell = targetCell;
    }

    public void TakeDamage(Damage damage, Entity attacker)
    {

    }

    public void TakeHeal(Heal heal, Entity healer)
    {

    }
}
