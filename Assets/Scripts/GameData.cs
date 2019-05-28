using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData  {

    public int playerHealth;
    public int playerLevel;
    public float[] playerPosition;
    public int expToLevel;
    public string[] itemSlugInInventory;


    public GameData(Player player)
    {
        Debug.Log("SAVING/LOADING");
        playerLevel = player.GetComponent<Levelling>().level;
        expToLevel = player.GetComponent<Levelling>().experienceToLevel;
        playerHealth = player.currentHealth;
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        //itemSlugInInventory = new string[inventory.inventoryItems.Count];
        //for(int i = 0; i <= inventory.inventoryItems.Count; i++)
        //{
        //    Debug.Log(inventory.inventoryItems[i].ToString() + " ADDED");
        //    itemSlugInInventory[i] = inventory.inventoryItems[i].itemSlug;
        //    i++;
        //}

    }

}
