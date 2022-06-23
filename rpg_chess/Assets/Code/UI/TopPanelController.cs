using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanelController : MonoBehaviour
{
    public GameObject resourcePanel;
    public void ShowHideResourcePanel()
    {
        RectMask2D mask = resourcePanel.transform.GetComponent<RectMask2D>();
        mask.enabled = !mask.IsActive();
    }
}
