using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable { // Derives from interactable script - inherits all classes and methods from interactable class

    public ItemClass itemDrop;

    public override void Interact()
    {
        base.Interact();

        PickUpItem();
    }

    void PickUpItem()
    {
        Debug.Log("Picking up item");
        // Add to inv
        InventoryManager.instance.AddItemToInventory(itemDrop);
        // Destroy gameobject
        Destroy(gameObject);
    }

}
