using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatelegsManager : MonoBehaviour {

    public GameObject legs;
    [HideInInspector] public GameObject wornPlatelegs;
    
    CombatantStats combatantStats;
    IPlatelegs equippedPlatelegs;
    public ItemClass currentEquippedLegs;

    // Use this for initialization
    void Start () {
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipPlatelegs(ItemClass item)
    {
        // If a shield is held
        if (wornPlatelegs != null)
        {   // Add current offhand to inventory
            InventoryManager.instance.AddItemToInventory(currentEquippedLegs.itemSlug);
            // Remove offhand stats from player stats
            combatantStats.RemoveStatBoost(wornPlatelegs.GetComponent<IPlatelegs>().Stats);
            // Destroy offhand being held
            Destroy(legs.transform.GetChild(0).gameObject); // Destroys first child of mainHand, which would be offhand held
        }
        // Equip new offhand
        wornPlatelegs = (GameObject)Instantiate(Resources.Load<GameObject>("Items/LegArmour/" + item.itemSlug), legs.transform.position, legs.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand

        // Get offhand interface from the held offhand
        equippedPlatelegs = wornPlatelegs.GetComponent<IPlatelegs>();

        // Set new offhand stats
        equippedPlatelegs.Stats = item.stats;
        // Set offhand position to mainhand
        wornPlatelegs.transform.SetParent(legs.transform);
        // Set stats for equipped offhand
        equippedPlatelegs.Stats = item.stats;
        // Set current offhand to new offhand
        currentEquippedLegs = item;
        // Add offhand stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.LegsWorn(item);
        UIManager.StatsChanged();
        
    }

    public void RemovePlatelegs ()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentEquippedLegs.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedPlatelegs.Stats);
        // Destroy weapon gameobject
        Destroy(wornPlatelegs.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }
}
