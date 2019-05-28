using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffhandManager : MonoBehaviour {

    public GameObject offhand;
    [HideInInspector] public GameObject heldOffhand;
    
    CombatantStats combatantStats;
    IShield equippedOffhand;
    public ItemClass currentHeldItem;

    // Use this for initialization
    void Start () {
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipOffhand(ItemClass item)
    {
        // If a shield is held
        if (heldOffhand != null)
        {   // Add current offhand to inventory
            InventoryManager.instance.AddItemToInventory(currentHeldItem.itemSlug);
            // Remove offhand stats from player stats
            combatantStats.RemoveStatBoost(heldOffhand.GetComponent<IShield>().Stats);
            // Destroy offhand being held
            Destroy(offhand.transform.GetChild(0).gameObject); // Destroys first child of mainHand, which would be offhand held
        }
        // Equip new offhand
        heldOffhand = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Offhands/" + item.itemSlug), offhand.transform.position, offhand.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand

        // Get offhand interface from the held offhand
        equippedOffhand = heldOffhand.GetComponent<IShield>();

        // Set new offhand stats
        equippedOffhand.Stats = item.stats;
        // Set offhand position to mainhand
        heldOffhand.transform.SetParent(offhand.transform);
        // Set stats for equipped offhand
        equippedOffhand.Stats = item.stats;
        // Set current offhand to new offhand
        currentHeldItem = item;
        // Add offhand stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.ShieldEquipped(item);
        UIManager.StatsChanged();

        Debug.Log(equippedOffhand.Stats[0]);
    }

    public void RemoveShield()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentHeldItem.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedOffhand.Stats);
        // Destroy weapon gameobject
        Destroy(heldOffhand.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }
}
