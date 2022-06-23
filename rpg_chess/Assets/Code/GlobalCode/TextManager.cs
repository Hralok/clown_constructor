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
                {0,  "������� ����"},
                {1,  "���������"}
            }
        },


        { LanguageEnum.English, new Dictionary<int, string>()
            {
                {0,  "Main menu"},
                {1,  "Settings"}
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
            throw new System.Exception("��������� ������� ���������� � �������������� ������. Id ������: " + id.ToString() + " ����: " + currentLanguage.ToString());
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
