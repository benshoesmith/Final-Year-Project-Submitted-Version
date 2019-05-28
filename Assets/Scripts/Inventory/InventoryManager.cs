using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    [HideInInspector]public WeaponManager weaponManager;
    [HideInInspector] public OffhandManager offhandManager;
    [HideInInspector] public HelmetManager helmetManager;
    [HideInInspector] public ChestplateManager chestplateManager;
    [HideInInspector] public PlatelegsManager platelegsManager;
    [HideInInspector] public BootsManager bootsManager;
    [HideInInspector] public ConsumableManager consumableManager;
    [HideInInspector] public static InventoryManager instance; // Instance of InventoryManager
    [HideInInspector] public List<ItemClass> inventoryItems = new List<ItemClass>(); // New list of items - populated when added to inventory
    public UIInventoryDetails inventoryInfoPanel;
    public RectTransform Content;

    void Start()
    {
        // If instance already exists
        if(instance != null && instance != this)
        {
            // Destroy it
            Destroy(gameObject);
        }
        else
        {
            // Set this to instance
            instance = this;
        }

        // Set wepaon manager to the player's weapon manager (script atatched to player) & consumables manager
        weaponManager = GetComponent<WeaponManager>();
        consumableManager = GetComponent<ConsumableManager>();
        offhandManager = GetComponent<OffhandManager>();
        helmetManager = GetComponent<HelmetManager>();
        chestplateManager = GetComponent<ChestplateManager>();
        platelegsManager = GetComponent<PlatelegsManager>();
        bootsManager = GetComponent<BootsManager>();
        AddItemToInventory("sword");

        //AddItemToInventory("testConsumable");
    }

    public void AddItemToInventory(string itemSlug)
    {
        // Create item to add to inventory
        ItemClass item = ItemDatabase.instance.GiveItem(itemSlug);
        // Give item to item database & add to inventory items list
        inventoryItems.Add(item);
        Debug.Log(inventoryItems.Count + " items in inventory. Added: " + itemSlug);
        // Call item add to inv method in UIManager
        UIManager.ItemAddedToInventory(item);
    }

    public void AddItemToInventory(ItemClass item)
    {
        // Add item to inventory items
        inventoryItems.Add(item);
        // Call item add to inv method in UIManager
        UIManager.ItemAddedToInventory(item);
    }

    public void EquipWeapon(ItemClass item)
    {
        // Equip item passed
        weaponManager.EquipWeapon(item);
    }

    public void EquipShield(ItemClass item)
    {
        offhandManager.EquipOffhand(item);
    }

    public void EquipHelmet(ItemClass item)
    {
        helmetManager.EquipHelmet(item);
    }

    public void EquipBody(ItemClass item)
    {
        chestplateManager.EquipChestplate(item);
    }

    public void EquipLegs(ItemClass item)
    {
        platelegsManager.EquipPlatelegs(item);
    }

    public void EquipFeet(ItemClass item)
    {
        bootsManager.EquipBoots(item);
    }

    public void ConsumeItem(ItemClass item)
    {
        // Consume item passed
        consumableManager.ConsumeItem(item);
    }

    public void ShowItemInfo(ItemClass item, Button selectedButton)
    {
        // Show passd item on the inventory panel
        inventoryInfoPanel.ShowItem(item, selectedButton);
    }

    public void SaveData(InventoryManager inventory)
    {
        //SaveGame.SaveData(this, invManager, playerPanelP);
        SaveInventory.SaveData(this);
    }

    public void LoadData(InventoryManager inventory)
    {
        for(int i = 0; i < inventory.inventoryItems.Count; i++)
        {
            //Destroy(Content.transform.GetChild(i));
        }
        AddAllItems();
    }

    public void AddAllItems()
    {
        InventoryData data = SaveInventory.LoadData();

        for (int i = 0; i < data.itemSlugInInventory.Length; i++)
        {
            AddItemToInventory(data.itemSlugInInventory[i]);
        }
    }

}
