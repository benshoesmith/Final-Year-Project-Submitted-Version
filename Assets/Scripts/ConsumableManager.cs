using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour {

    CombatantStats stats;

	// Use this for initialization
	void Start ()
    {
        // Create reference to player stats
        stats = GetComponent<Player>().combatantStats;
	}

    public void ConsumeItem(ItemClass item)
    {
        // Spawn item prefab from resources folder
        GameObject itemUsed = Instantiate(Resources.Load<GameObject>("Items/Consumables/" + item.itemSlug));
        // If item modifies stats
        if(item.modifier)
        {
            // Call Consume method that takes stats
            itemUsed.GetComponent<IConsumables>().Consume(stats);
        }
        else
        {
            // Otherwise call standard Consume method
            itemUsed.GetComponent<IConsumables>().Consume();
        }
    }

}
