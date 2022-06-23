using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextManager
{
    static private LanguageEnum currentLanguage = LanguageEnum.Russian;

    static private Dictionary<LanguageEnum, Dictionary<int, string>> allProjectText = new Dictionary<LanguageEnum, Dictionary<int, string>>()
    {
        { LanguageEnum.Russian, new Dictionary<int, string>()
            {
                {0,  "Главное меню"},
                {1,  "Настройки"},
                {2,  "Продолжить"},
                {3,  "Загрузить"},
                {4,  "Новая игра"},
                {5,  "Картостроитель"},
                {6,  "Выход"},
                {7,  "Информация"},
                {8,  "Громкость"},
                {9,  "Качество"},
                {10, "Разрешение"},
                {11, "Язык"},
                {12, "Загрузка"},
                {13, "Меню"},
                {14, "Конец хода"},

            }
        },


        { LanguageEnum.English, new Dictionary<int, string>()
            {
                {0,  "Main menu"},
                {1,  "Settings"},
                {2,  "Continue"},
                {3,  "Load"},
                {4,  "New Game"},
                {5,  "Mapconstructor"},
                {6,  "Quit"},
                {7,  "Information"},
                {8,  "Volume"},
                {9,  "Quality"},
                {10, "Resolution"},
                {11, "Language"},
                {12, "Loading"},
                {13, "Menu"},
                {14, "End turn"},

            }
        }
    };

    static public string GetTextById(int id)
    {
        if (allProjectText[currentLanguage].ContainsKey(id))
        {
            return allProjectText[currentLanguage][id];
        }
        else
        {
            throw new System.Exception("Произошла попытка обратиться к несуществуещей строке. Id строки: " + id.ToString() + " Язык: " + currentLanguage.ToString());
        }
    }

    static public void SetCurrentLanguage(LanguageEnum newLanguage)
    {
        if (newLanguage == LanguageEnum.Russian || newLanguage == LanguageEnum.English)
        {
            currentLanguage = newLanguage;
        }
    }

    static public LanguageEnum GetCurrentLanguage()
    {
        return currentLanguage;
    }

    static public bool CheckIdExistence(int id)
    {
        return allProjectText[currentLanguage].ContainsKey(id);
    }
}
