using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDetails : MonoBehaviour {

    public Text statText;

    ItemClass item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractText;

    void Start()
    {
        // Assign UI components to fields
        itemNameText = transform.Find("itemName").GetComponent<Text>();
        itemDescriptionText = transform.Find("itemDescription").GetComponent<Text>();
        itemInteractButton = transform.Find("Button").GetComponent<Button>();
        itemInteractText = transform.Find("Button").transform.Find("Text").GetComponent<Text>();
        itemInteractButton.gameObject.SetActive(false);
    }



    public void ShowItem(ItemClass item, Button selectedButton)
    {
        // Set interact button to true
        itemInteractButton.gameObject.SetActive(true);
        // Clear statText - not adding data on the end of the previous string
        statText.text = "";
        // If the item has stats
        if(item.stats != null)
        {
            // Check how many stats then item has
            foreach(DefaultStats stat in item.stats)
            {
                // Add stat name and value to the text field
                statText.text += stat.statName + ": " + stat.defaultStatValue + "\n";
            }
        }
        // Remove all listeners each time the button is pressed - stops listeners queueing
        itemInteractButton.onClick.RemoveAllListeners();
        // Set up UI fields with passed item details
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemInteractText.text = item.interactName;
        // On click, interact with item
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        // If item is consumable
        if(item.itemType == ItemClass.ItemType.Consumable)
        {
            // Call consume method from inv manager
            InventoryManager.instance.ConsumeItem(item);
            // Remove from inventory
            Destroy(selectedItemButton.gameObject);
        }
        // IF item is a weapon
        else if(item.itemType == ItemClass.ItemType.Weapon)
        {
            // Call Equip Item method
            InventoryManager.instance.EquipWeapon(item);
            // Remove from inventory
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.itemType == ItemClass.ItemType.Shield)
        {
            InventoryManager.instance.EquipShield(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.itemType == ItemClass.ItemType.Helmet)
        {
            InventoryManager.instance.EquipHelmet(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.itemType == ItemClass.ItemType.Chestplate)
        {
            InventoryManager.instance.EquipBody(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.itemType == ItemClass.ItemType.Platelegs)
        {
            InventoryManager.instance.EquipLegs(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.itemType == ItemClass.ItemType.Boots)
        {
            InventoryManager.instance.EquipFeet(item);
            Destroy(selectedItemButton.gameObject);
        }
        item = null;
        RemoveItem();
    }

    public void RemoveItem()
    {
        // Blank out all item details
        itemNameText.text = "";
        itemDescriptionText.text = "";
        itemInteractText.text = "";
        itemInteractButton.gameObject.SetActive(false);
    }

}
