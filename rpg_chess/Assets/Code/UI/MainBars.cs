using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBars : MonoBehaviour
{
    private Slider healthSlider;
    private Slider manaSlider;
    private Slider energySlider;

    private static MainBars instance;

    private void Awake()
    {
        instance = this;

        healthSlider = transform.Find("HealthBar").GetComponent<Slider>();
        manaSlider = transform.Find("ManaBar").GetComponent<Slider>();
        energySlider = transform.Find("EnergyBar").GetComponent<Slider>();
    }

    private void UpdateBarsValues(Entity entity)
    {
        healthSlider.maxValue = (float)entity.healthPoints;
        healthSlider.value = (float)entity.maximalHealthPoints;

        manaSlider.maxValue = (float)entity.mana;
        manaSlider.value = (float)entity.maximalMana;

        energySlider.maxValue = (float)entity.energy;
        energySlider.value = (float)entity.maximalEnergy;
    }

    public void UpdateBarsValues_Static(Entity entity)
    {
        instance.UpdateBarsValues(entity);
    }
}
