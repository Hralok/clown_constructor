using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResourceCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private int nameId;
    private int descriptionId;
    private int iconId;

    private TextMeshProUGUI text;
    private Image icon;

    private void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        icon = transform.Find("Icon").GetComponent<Image>();
    }

    public void Initialization(int nameId, int descriptionId, int iconId)
    {
        this.nameId = nameId;
        this.descriptionId = descriptionId;
        this.iconId = iconId;

        // icon = GraphicSupporter
    }

    public void SetValue(int currentValue, int maxValue)
    {
        text.text = currentValue.ToString() + "/" + maxValue.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //InfoBox.ShowInfoBox_Static(transform.position, nameId, descriptionId);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //InfoBox.HideInfoBox_Static();
    }
}
