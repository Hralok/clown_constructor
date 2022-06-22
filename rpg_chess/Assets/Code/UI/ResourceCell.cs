using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResourceCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");

        InfoBox.ShowInfoBox_Static(transform.position, "proba", "Полноценное описание какого-то ресурса, с пропусками, пробелами \n и абзацами.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exit the selectable UI element.");

        InfoBox.HideInfoBox_Static();
    }
}
