using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; // Used for json serialization

public class ItemDatabase : MonoBehaviour {

    public static ItemDatabase instance;

    private List<ItemClass> items;
    
	void Awake ()
    { 
        // If an instance already exists
		if(instance != null && instance != this)
        {
            // Destroy this instance
            Destroy(gameObject);
        }
        else
        {
            // Otherwise, set this as the instance
            instance = this;
        }
        CreateItemDatabase();
	}
	
    private void CreateItemDatabase()
    {
        // Items list is populated by the json file
        items = JsonConvert.DeserializeObject<List<ItemClass>>(Resources.Load<TextAsset>("JSON/itemDatabase").ToString());
        Debug.Log(items[0].stats[1].statName + " level is " + items[0].stats[1].UpdateStatValue());
        Debug.Log(items[0].itemName);
    }

    public ItemClass GiveItem(string _itemSlug)
    {
        // Go through list of items
        foreach(ItemClass item in items)
        {
            // If an item has the same slug as the item passed to the method
            if(item.itemSlug == _itemSlug)
            {
                // Return that item
                return item;
            }
        }
        // Otherwise return null
        Debug.Log("Couldn't find item " + _itemSlug);
        return null;
    }
}
