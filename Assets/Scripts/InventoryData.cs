using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData  {

    public string[] itemSlugInInventory;


    public InventoryData(InventoryManager inventory)
    {
        Debug.Log("SAVING/LOADING");

        itemSlugInInventory = new string[inventory.inventoryItems.Count];
        Debug.Log(inventory.inventoryItems.Count);
        for(int i = 0; i <= inventory.inventoryItems.Count; i++)
        {
            Debug.Log(inventory.inventoryItems[i].itemSlug.ToString() + " ADDED");
            itemSlugInInventory[i] = inventory.inventoryItems[i].itemSlug;
            i++;
        }

    }

}
