using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {

    public RectTransform inventoryPanel;
    public RectTransform wornInventoryPanel;
    public RectTransform scrollViewItems;
    public PlayerController playerController;
    public GameObject player;
    UIInventoryItem itemPanel;
    bool inventoryIsActive;
    ItemClass selectedItem;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        // Assign prefab to itemPanel
        itemPanel = Resources.Load<UIInventoryItem>("UI/itemContainer");
        // Inventory panel inactive on start
        inventoryPanel.gameObject.SetActive(false);
        wornInventoryPanel.gameObject.SetActive(false);
        UIManager.OnItemAddedToInventory += ItemAdded;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            // When I is pressed swap state of inventoryIsActive
            inventoryIsActive = !inventoryIsActive;
            inventoryPanel.gameObject.SetActive(inventoryIsActive);
            wornInventoryPanel.gameObject.SetActive(inventoryIsActive);
            playerController.FreezeMovement(inventoryIsActive);
        }

    }

    public void ItemAdded(ItemClass item)
    {
        // Instantiate blank item panel
        UIInventoryItem blankItem = Instantiate(itemPanel);
        // Show passed item's info on panel
        blankItem.ShowItem(item);
        blankItem.transform.SetParent(scrollViewItems);
    }

}
