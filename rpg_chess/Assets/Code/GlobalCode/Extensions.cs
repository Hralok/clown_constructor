using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static TValue GetValueOrDefault<TKey, TValue>(this System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        if (dictionary.ContainsKey(key))
        {
            return dictionary[key];
        }
        else
        {
            return defaultValue;
        }
    }



}
