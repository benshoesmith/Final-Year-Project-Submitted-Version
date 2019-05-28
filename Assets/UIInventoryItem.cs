using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour {

    public ItemClass item;
    
    public void ShowItem(ItemClass item)
    {
        // Assign the passed item to this objects item
        this.item = item;
        ShowItemDetails();
    }

    void ShowItemDetails()
    {
        // Set UI text itemName to the items name
        this.transform.Find("itemName").GetComponent<Text>().text = item.itemName;
        // Set UI image to the corresponding image in resources
        this.transform.Find("itemImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
    }

    public void OnClickItem()
    {
        // Pass item and gameobjects button component to inv manager show item info method
        InventoryManager.instance.ShowItemInfo(item, GetComponent<Button>());
    }

}
