using System.Collections;
using System.Collections.Generic;

public class Heal 
{
    public double heal { get; private set; }
    public HealTypeEnum healType { get; private set; }

    public Heal(double heal, HealTypeEnum healType)
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
    }
}
