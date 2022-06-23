using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreatureIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Image icon;
    private TextMeshProUGUI levelsText;
    private TextMeshProUGUI evolutionsText;

    private Slider healthSlider;
    private Slider manaSlider;
    private Slider energySlider;

    // Unit?
    private Entity entity;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        levelsText = transform.Find("LevelNumber").transform.Find("Text").GetComponent<TextMeshProUGUI>();
        evolutionsText = transform.Find("EvolutionNumber").transform.Find("Text").GetComponent<TextMeshProUGUI>();

        healthSlider = transform.Find("Bars").transform.Find("HealthBar").GetComponent<Slider>();
        manaSlider = transform.Find("Bars").transform.Find("ManaBar").GetComponent<Slider>();
        energySlider = transform.Find("Bars").transform.Find("EnergyBar").GetComponent<Slider>();
    }

    public void Initialization(Entity entity)
    {
        this.entity = entity;
        // icon = 
        UpdateBarsValues();
    }

    public void UpdateBarsValues()
    {
        healthSlider.maxValue = (float)entity.healthPoints;
        healthSlider.value = (float)entity.maximalHealthPoints;

        manaSlider.maxValue = (float)entity.mana;
        manaSlider.value = (float)entity.maximalMana;

        energySlider.maxValue = (float)entity.energy;
        energySlider.value = (float)entity.maximalEnergy;

        /*if (entity == выбранное существо)
        {
            MainBars.UpdateBarsValues_Static(entity);
        }*/
    }

    public void SetLevelsValue(int value)
    {
        levelsText.text = value.ToString();
    }

    public void SetEvolutionsValue(int value)
    {
        evolutionsText.text = value.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        //InfoBox.ShowInfoBox_Static(transform.position, TextManager.GetTextById(entity.nameId), TextManager.GetTextById(entity.descriptionId));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");

        //InfoBox.HideInfoBox_Static();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        // сменить выделенное существо
        // MainBars.UpdateBarsValues_Static(entity);
    }

}
