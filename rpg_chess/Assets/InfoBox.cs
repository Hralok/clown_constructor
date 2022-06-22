using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    private RectTransform canvasRectTransform;
    private RectTransform thisRectTransform;

    private static InfoBox instance;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI descriptionText;

    private void Awake()
    {
        //instance = transform.GetComponent<InfoBox>();
        instance = this;

        canvasRectTransform = canvas.GetComponent<RectTransform>();
        thisRectTransform = gameObject.GetComponent<RectTransform>();

        nameText = transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        descriptionText = transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();

        instance.HideInfoBox();
    }

    private void ShowInfoBox(Vector3 pos, string name, string descript)
    {
        gameObject.SetActive(true);
        nameText.SetText(name);
        descriptionText.SetText(descript);

        Vector3 position = pos / canvasRectTransform.localScale.x;

        if (position.x + thisRectTransform.rect.width / 2 > canvasRectTransform.rect.width)
        {
            position.x = canvasRectTransform.rect.width - thisRectTransform.rect.width / 2;
        }
        
        if (position.y + thisRectTransform.rect.height / 2 > canvasRectTransform.rect.height)
        {
            position.y = canvasRectTransform.rect.height - thisRectTransform.rect.height / 2;
        }

        transform.position = position;
    }

    private void HideInfoBox()
    {
        gameObject.SetActive(false);
    }

    public static void ShowInfoBox_Static(Vector3 pos, string name, string descript)
    {
        instance.ShowInfoBox(pos, name, descript);
    }

    public static void HideInfoBox_Static()
    {
        instance.HideInfoBox();
    }

}
