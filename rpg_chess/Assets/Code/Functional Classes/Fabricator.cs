using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabricator 
{
    private static HashSet<Ability> abilities;
    private static bool initialized = false;

    public static void Init()
    {
        initialized = true;
        abilities = new HashSet<Ability>();
    }

    public static Item CreateItem(int newItemId)
    {
        if (!initialized)
        {
            throw new System.Exception("Fabricator не инициализирован перед использованием!");
        }
        throw new System.NotImplementedException();
    }

}
