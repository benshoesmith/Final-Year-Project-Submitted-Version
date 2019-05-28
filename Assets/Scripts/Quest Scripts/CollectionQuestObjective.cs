using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionQuestObjective : Goal { // Inherits from goal class

    public string itemID;

    public override void Initialise()
    {
        base.Initialise();
        UIManager.OnItemAddedToInventory += ItemCollected;
    }

    public CollectionQuestObjective(Quest quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.itemID = itemID;
        this.description = description;
        this.completed = completed;
        this.currentAmount = currentAmount;
        this.requiredAmount = requiredAmount;
    }

    void ItemCollected(ItemClass item)
    {
        // If enemy ids match
        if(item.itemSlug == this.itemID)
        {
            // Increase current amount by 1
            this.currentAmount++;
            // Check if quest objective is completed
            CheckCompleted();
        }
    }

}
