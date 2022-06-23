using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIComponentsExtension
{
    public static ResourceCell CreateResourceCell(GameObject cellPrefab, int nameId, int descriptionId, int iconId)
    {
        GameObject cellObject = Object.Instantiate(cellPrefab, GameObject.Find("ResourcePanel").transform.Find("Content").transform);
        ResourceCell cell = cellObject.GetComponent<ResourceCell>();
        cell.Initialization(nameId, descriptionId, iconId);
        // cell.SetValue(...) ?

        return cell;
    }

    public static CreatureIcon CreateCreatureIcon(GameObject creatureIconPrefab, Entity entity)
    {
        GameObject creatureIconObject = Object.Instantiate(creatureIconPrefab, GameObject.Find("BottomPanel").transform.Find("ScrollArea").transform.Find("Content").transform);
        CreatureIcon creatureIcon = creatureIconObject.GetComponent<CreatureIcon>();
        creatureIcon.Initialization(entity);

        return creatureIcon;
    }
}
