using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestplateManager : MonoBehaviour {

    public GameObject body;
    [HideInInspector] public GameObject wornChestplate;
    
    CombatantStats combatantStats;
    IChestplate equippedChestplate;
    public ItemClass currentEquippedBody;

    // Use this for initialization
    void Start () {
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipChestplate(ItemClass item)
    {
        // If a shield is held
        if (wornChestplate != null)
        {   // Add current offhand to inventory
            InventoryManager.instance.AddItemToInventory(currentEquippedBody.itemSlug);
            // Remove offhand stats from player stats
            combatantStats.RemoveStatBoost(wornChestplate.GetComponent<IChestplate>().Stats);
            // Destroy offhand being held
            Destroy(body.transform.GetChild(0).gameObject); // Destroys first child of mainHand, which would be offhand held
        }
        // Equip new offhand
        wornChestplate = (GameObject)Instantiate(Resources.Load<GameObject>("Items/ChestArmour/" + item.itemSlug), body.transform.position, body.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand

        // Get offhand interface from the held offhand
        equippedChestplate = wornChestplate.GetComponent<IChestplate>();

        // Set new offhand stats
        equippedChestplate.Stats = item.stats;
        // Set offhand position to mainhand
        wornChestplate.transform.SetParent(body.transform);
        // Set stats for equipped offhand
        equippedChestplate.Stats = item.stats;
        // Set current offhand to new offhand
        currentEquippedBody = item;
        // Add offhand stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.BodyWorn(item);
        UIManager.StatsChanged();
        
    }

    public void RemoveChestplate()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentEquippedBody.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedChestplate.Stats);
        // Destroy weapon gameobject
        Destroy(wornChestplate.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }
}
