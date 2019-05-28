using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsManager : MonoBehaviour {

    public GameObject feet;
    [HideInInspector] public GameObject wornBoots;
    
    CombatantStats combatantStats;
    IBoots equippedBoots;
    public ItemClass currentEquippedBoots;

    // Use this for initialization
    void Start () {
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipBoots(ItemClass item)
    {
        // If a shield is held
        if (wornBoots != null)
        {   // Add current offhand to inventory
            InventoryManager.instance.AddItemToInventory(currentEquippedBoots.itemSlug);
            // Remove offhand stats from player stats
            combatantStats.RemoveStatBoost(wornBoots.GetComponent<IBoots>().Stats);
            // Destroy offhand being held
            Destroy(feet.transform.GetChild(0).gameObject); // Destroys first child of mainHand, which would be offhand held
        }
        // Equip new offhand
        wornBoots = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Boots/" + item.itemSlug), feet.transform.position, feet.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand

        // Get offhand interface from the held offhand
        equippedBoots = wornBoots.GetComponent<IBoots>();

        // Set new offhand stats
        equippedBoots.Stats = item.stats;
        // Set offhand position to mainhand
        wornBoots.transform.SetParent(feet.transform);
        // Set stats for equipped offhand
        equippedBoots.Stats = item.stats;
        // Set current offhand to new offhand
        currentEquippedBoots = item;
        // Add offhand stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.FeetWorn(item);
        UIManager.StatsChanged();
        
    }

    public void RemoveBoots ()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentEquippedBoots.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedBoots.Stats);
        // Destroy weapon gameobject
        Destroy(wornBoots.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }
}
