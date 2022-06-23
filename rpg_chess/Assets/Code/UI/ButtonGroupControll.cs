using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupControll : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;

    [SerializeField]
    GameObject charPanel;

    [SerializeField] 
    GameObject skillsPanel;

    public void CharButtonOnClick()
    {
        inventoryPanel.SetActive(false); 
        skillsPanel.SetActive(false);

        charPanel.SetActive(!charPanel.activeSelf); 
    }
    
    public void InventoryButtonOnClick()
    {
        charPanel.SetActive(false); 
        skillsPanel.SetActive(false);

        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        //inventoryPanel.GetComponent<CharacteristicsPanel>().UpdateCharacteristicValues();
    }
}
