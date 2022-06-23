using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopPanelController : MonoBehaviour
{
    public GameObject resourcePanel;

    [SerializeField]
    private TextMeshProUGUI menuText;

    private void Start()
    {
        menuText.text = TextManager.GetTextById(13);
    }

    public void ShowHideResourcePanel()
    {
        RectMask2D mask = resourcePanel.transform.GetComponent<RectMask2D>();
        mask.enabled = !mask.IsActive();
    }
}
