using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable
{
    public List<LootDrop> lootDrops;

    // How Drop Table Works:
    // Item weights add together to get unique value ranges for the roll to land between
    // For example, an item with 10 weight will be assigned the range 0-9, a second item with 15 weight will be assigned the range 10-24, and so on.
    // So if a 20 is rolled, it lands in the range of 10-24, and so lands on that item
    public ItemClass GetLootDrop()
    {
        int itemRoll = Random.Range(0, 101); // Rolls between those numbers, so essentially 1-100
        int weightSum = 0;
        foreach(LootDrop drop in lootDrops)
        {
            // For each drop passed, add that drops weight to the weight sum
            weightSum += drop.weight;
            // If the item roll is less than the weightsum (lands in a range)
            if(itemRoll < weightSum)
            {
                // Return that item
                return ItemDatabase.instance.GiveItem(drop.itemSlug);
            }
        }
        // If nothing gets dropped (final bit of range isn't assigned to an item), return null
        return null;
    }
	
}

public class LootDrop
{
    public string itemSlug;
    public int weight; // Chance of item dropping (percentage 1-100)

    public LootDrop(string itemSlug, int weight)
    {
        // Assign passed values to this objects variables
        this.itemSlug = itemSlug;
        this.weight = weight;
    }
}
