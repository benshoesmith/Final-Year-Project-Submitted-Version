using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour {

    public List<Goal> GoalList = new List<Goal>();
    public string questName;
    public string questDescription;
    public string itemRewardSlug;
    public int experienceReward;
    public ItemClass itemReward;
    public bool questCompleted;
    public bool isFinalQuest;
    public string[] differentEnemiesToKill__EnterSlugNameInElement;
    public int[] numberToKill__CorrespondingOrder;
    public string[] differentItemsToCollect__EnterSlugNameInElement;
    public int[] numberToCollect__CorrespondingOrder;

    public GameObject questObjectToGive;

    public void CheckObjectives()
    {
        // Checks through all goals in list and check to see if they've been completed. If they've been completed...
        questCompleted = GoalList.All(x => x.completed);
        // If quest is completed
        if(questCompleted)
        {
            // Call Reward method
            Reward();
            if(isFinalQuest)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void Reward()
    {
        // If there is an item to reward
        if(itemReward != null)
        {
            // Add itemReward to inventory
            InventoryManager.instance.AddItemToInventory(itemReward);
        }
    }

}
