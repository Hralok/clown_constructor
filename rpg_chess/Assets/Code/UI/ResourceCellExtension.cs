using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceCellExtension
{
    public static ResourceCell CreateResourceCell(GameObject cellPrefab, int nameId, int descriptionId, int iconId)
    {
        GameObject cellObject = Object.Instantiate(cellPrefab, GameObject.Find("ResourcePanel").transform.Find("Content").transform);
        ResourceCell cell = cellObject.GetComponent<ResourceCell>();
        cell.Initialization(nameId, descriptionId, iconId);
        // cell.SetValue(...) ?

        return cell;
    }
}
