using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleQuest : Quest { // Derives from quest class

	// Use this for initialization
	void Start ()
    {
        // Initialise quest
        questName = "Example Quest";
        questDescription = "Kill enemies to complete this quest.";
        itemReward = ItemDatabase.instance.GiveItem(itemRewardSlug);
        experienceReward = 100;
        isFinalQuest = true;

        // For each kill objective
        for(int i = 0; i < differentEnemiesToKill__EnterSlugNameInElement.Length; i++)
        {
            //Debug.Log("Kill " + numberToKill__CorrespondingOrder[i] + " " + differentEnemiesToKill__EnterSlugNameInElement[i]);

            // Add new kill objective with the information given
            GoalList.Add(new KillQuestObjective(this, 1, "Kill " + numberToKill__CorrespondingOrder[i] + " " + differentEnemiesToKill__EnterSlugNameInElement[i], false, 0, numberToKill__CorrespondingOrder[i]));
        }

        // For each collection objective
        for(int j = 0; j < differentItemsToCollect__EnterSlugNameInElement.Length; j++)
        {
            // Add new collection objective with the information given
            GoalList.Add(new CollectionQuestObjective(this, differentItemsToCollect__EnterSlugNameInElement[j], "Find " + numberToCollect__CorrespondingOrder[j] + " " + differentItemsToCollect__EnterSlugNameInElement[j], false, 0, numberToCollect__CorrespondingOrder[j]));
        }

        // Initialise each objective in goal list
        GoalList.ForEach(x => x.Initialise());
	}

}
