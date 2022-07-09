using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class TextManager
{
    static private LanguageEnum currentLanguage = LanguageEnum.Russian;
    static public int lastSystemIndex { get; private set; } = 14;
    static public int lastTextIndex { get; private set; }
    static public bool initialized { get; private set; } = true;

    static private Dictionary<LanguageEnum, Dictionary<int, string>> systemText = new Dictionary<LanguageEnum, Dictionary<int, string>>()
    {
        { LanguageEnum.Russian, new Dictionary<int, string>()
            {
                {0,  "������� ����"},
                {1,  "���������"},
                {2,  "����������"},
                {3,  "���������"},
                {4,  "����� ����"},
                {5,  "��������������"},
                {6,  "�����"},
                {7,  "����������"},
                {8,  "���������"},
                {9,  "��������"},
                {10, "����������"},
                {11, "����"},
                {12, "��������"},
                {13, "����"},
                {14, "����� ����"},

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

    static private Dictionary<LanguageEnum, Dictionary<int, string>> allProjectText;

    static public void StartInitialization()
    {
        allProjectText = new Dictionary<LanguageEnum, Dictionary<int, string>>(systemText);
        lastTextIndex = lastSystemIndex;
        initialized = false;
    }

    static public int AddText(Dictionary<LanguageEnum, string> text)
    {
        if (initialized)
        {
            throw new System.Exception("���������� �������� ����� �����, TextManager ��� ���������������!");
        }

        lastTextIndex++;

        foreach(var i in allProjectText.Keys)
        {
            if (!text.ContainsKey(i))
            {
                throw new System.Exception("����������� ����� ����������� �� �� ���� ��������� ������!");
            }
            allProjectText[i].Add(lastTextIndex, text[i]);
        }

        return lastTextIndex;
    }



    static public void EndInitialization()
    {
        initialized = true;
    }





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
