using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacteristicsPanel : MonoBehaviour
{
    [SerializeField]
    GameObject charPrefab;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private Transform mainCharacteristics;

    [SerializeField]
    private Transform otherCharacteristics;

    // активное существо типа (потом будет в GameController)
    private Unit activeEntity;

    private int currentLvl = 34;
    private Dictionary<MainCharacteristicTypeEnum, double> mainChars;
    private Dictionary<MainCharacteristicTypeEnum, double> otherChars;


    // Заглушка
    private void Start()
    {
        mainChars = new Dictionary<MainCharacteristicTypeEnum, double>
        {
            {MainCharacteristicTypeEnum.Strength, 78},
            {MainCharacteristicTypeEnum.Agility, 7},
            {MainCharacteristicTypeEnum.Intelligence, 10000}
        };

        otherChars = new Dictionary<MainCharacteristicTypeEnum, double>
        {
            {MainCharacteristicTypeEnum.Strength, 70008},
            {MainCharacteristicTypeEnum.Agility, 700},
            {MainCharacteristicTypeEnum.Intelligence, 1009009}
        };

        UpdateCharacteristicValues();
    }

    public void UpdateCharacteristicValues()
    {
        levelText.text = "Уровень " + currentLvl;

        ConfigureCharacteristicCount();

        int i = 0;
        foreach (var characteristic in mainChars.Keys)
        {
            Transform c = mainCharacteristics.GetChild(i);
            c.Find("CharacteristicText").GetComponent<TextMeshProUGUI>().text = characteristic.ToString();
            c.Find("ValueText").GetComponent<TextMeshProUGUI>().text = mainChars[characteristic].ToString();
            i++;
        }

        i = 0;
        foreach (var characteristic in otherChars.Keys)
        {
            Transform c = otherCharacteristics.GetChild(i);
            c.Find("CharacteristicText").GetComponent<TextMeshProUGUI>().text = characteristic.ToString();
            c.Find("ValueText").GetComponent<TextMeshProUGUI>().text = otherChars[characteristic].ToString();
            i++;
        }
    }

    private void ConfigureCharacteristicCount()
    {
        int mainCharacteristicsCount = mainCharacteristics.childCount;

        if (mainCharacteristicsCount != mainChars.Count)
        {
            while (mainCharacteristicsCount > mainChars.Count)
            {
                Destroy(mainCharacteristics.GetChild(mainCharacteristicsCount - 1).gameObject);
                mainCharacteristicsCount--;
            }
            while (mainCharacteristicsCount < mainChars.Count)
            {
                GameObject s = Instantiate(charPrefab, mainCharacteristics);
                mainCharacteristicsCount++;
                Debug.Log("ok");
            }
        }

        int otherCharacteristicsCount = otherCharacteristics.childCount;
        if (otherCharacteristicsCount != otherChars.Count)
        {
            while (otherCharacteristicsCount > otherChars.Count)
            {
                Destroy(otherCharacteristics.GetChild(otherCharacteristicsCount - 1).gameObject);
                otherCharacteristicsCount--;
            }
            while (otherCharacteristicsCount < otherChars.Count)
            {
                GameObject s = Instantiate(charPrefab, otherCharacteristics);
                otherCharacteristicsCount++;
            }
        }
    }


    // С активным существом
    /*public void UpdateCharacteristicValues()
    {
        levelText.text = "Уровень " + activeEntity.currentLvl;

        ConfigureCharacteristicCount();

        int i = 0;
        foreach (var characteristic in activeEntity.mainChars.Keys)
        {
            Transform c = mainCharacteristics.GetChild(i);
            c.Find("CharacteristicText").GetComponent<TextMeshProUGUI>().text = characteristic.ToString();
            c.Find("ValueText").GetComponent<TextMeshProUGUI>().text = activeEntity.mainChars[characteristic].ToString();
            i++;
        }

        *//*i = 0;
        foreach (var characteristic in activeEntity.otherChars.Keys)
        {
            Transform c = otherCharacteristics.GetChild(i);
            c.Find("CharacteristicText").GetComponent<TextMeshProUGUI>().text = characteristic.ToString();
            c.Find("ValueText").GetComponent<TextMeshProUGUI>().text = activeEntity.otherChars[characteristic].ToString();
            i++;
        }*//*
    }

    private void ConfigureCharacteristicCount()
    {
        if (mainCharacteristics.childCount != activeEntity.mainChars.Count)
        {
            while (mainCharacteristics.childCount > activeEntity.mainChars.Count)
            {
                Destroy(mainCharacteristics.GetChild(0).gameObject);
            }
            while (mainCharacteristics.childCount < activeEntity.mainChars.Count)
            {
                GameObject.Instantiate(charPrefab, mainCharacteristics);
            }
        }

        *//*if (otherCharacteristics.childCount != activeEntity.otherChars.Count)
        {
            while (otherCharacteristics.childCount > activeEntity.otherChars.Count)
            {
                Destroy(otherCharacteristics.GetChild(0).gameObject);
            }
            while (otherCharacteristics.childCount < activeEntity.otherChars.Count)
            {
                GameObject.Instantiate(charPrefab, otherCharacteristics);
            }
        }*//*
    }*/
}
