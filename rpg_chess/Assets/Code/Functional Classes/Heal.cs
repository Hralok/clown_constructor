using System.Collections;
using System.Collections.Generic;

public class Heal 
{
    public double heal { get; private set; }
    public HealTypeEnum healType { get; private set; }
    public MainCharacteristicTypeEnum amplificationChar { get; private set; }
    public double healBonusPerCharPoint { get; private set; }
    public double healMultiplerPerCharPoint { get; private set; }

    public Heal(
        double heal, 
        HealTypeEnum healType, 
        double healBonusPerCharPoint,
        double healMultiplerPerCharPoint)
    {
        if (heal < 0)
        {
            this.heal = 0;
        }
        else
        {
            this.heal = heal;
        }

        this.healType = healType;
        this.healBonusPerCharPoint = healBonusPerCharPoint;
        this.healMultiplerPerCharPoint = healMultiplerPerCharPoint;
    }
}
