using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetManager : MonoBehaviour {

    public GameObject head;
    [HideInInspector] public GameObject wornHelmet;
    
    CombatantStats combatantStats;
    IHelmet equippedHelmet;
    public ItemClass currentEquippedHelm;

    // Use this for initialization
    void Start () {
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipHelmet(ItemClass item)
    {
        // If a shield is held
        if (wornHelmet != null)
        {   // Add current offhand to inventory
            InventoryManager.instance.AddItemToInventory(currentEquippedHelm.itemSlug);
            // Remove offhand stats from player stats
            combatantStats.RemoveStatBoost(wornHelmet.GetComponent<IHelmet>().Stats);
            // Destroy offhand being held
            Destroy(head.transform.GetChild(0).gameObject); // Destroys first child of mainHand, which would be offhand held
        }
        // Equip new offhand
        wornHelmet = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Helmets/" + item.itemSlug), head.transform.position, head.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand

        // Get offhand interface from the held offhand
        equippedHelmet = wornHelmet.GetComponent<IHelmet>();

        // Set new offhand stats
        equippedHelmet.Stats = item.stats;
        // Set offhand position to mainhand
        wornHelmet.transform.SetParent(head.transform);
        // Set stats for equipped offhand
        equippedHelmet.Stats = item.stats;
        // Set current offhand to new offhand
        currentEquippedHelm = item;
        // Add offhand stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.HelmetWorn(item);
        UIManager.StatsChanged();
        
    }

    public void RemoveHelmet()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentEquippedHelm.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedHelmet.Stats);
        // Destroy weapon gameobject
        Destroy(wornHelmet.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }
}
