using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpPlacedInWorld : Interactable { // Derives from interactable script - inherits all classes and methods from interactable class

    public string itemToGive__enterItemSlug;

    public override void Interact()
    {
        base.Interact();

        PickUpItem();
    }

    void PickUpItem()
    {
        Debug.Log("Picking up item");
        // Add to inv
        InventoryManager.instance.AddItemToInventory(itemToGive__enterItemSlug);
        // Destroy gameobject
        Destroy(gameObject);
    }

}
