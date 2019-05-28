using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStart : NPCScript { // Derives from NPCScript so interact can be overridden

    [HideInInspector] public bool questGiven;
    [HideInInspector] public bool hasHelped; // Checks to see if the player has helped the NPC - seperate from quest completed
    public GameObject questObject;

    [SerializeField]
    private GameObject questListObject;
    [SerializeField]
    private string questToGive;
    private Quest quest;

    public override void Interact()
    {
        // If player hasn't got a quest from this NPC and hasn't completed one
        if(!questGiven && !hasHelped)
        {
            // Call base interact method
            base.Interact();
            // Give quest
            GiveQuest();
        }
        // If quest has been assigned but not handed in - could have been completed but not handed in
        else if(questGiven && !hasHelped)
        {
            // Check all objectives
            CheckQuestObjectives();

        }
        else
        {
            DialogManager.dialogManagerInstance.AddDialog(new string[] { "Thanks again for the help!" }, npcName);
        }
    }

    void GiveQuest()
    {
        //// Set questGiven to true
        //questGiven = true;
        //// Set quest as string find of quest to give
        //quest = (Quest)questListObject.AddComponent(System.Type.GetType(questToGive));
        questGiven = true;
        questObject.SetActive(true);
        quest = questObject.GetComponent<Quest>();

    }

    void CheckQuestObjectives()
    {
        // If quest is completed
        if(quest.questCompleted)
        {
            questObject.SetActive(false);
            // Call Reward method from quest
            quest.Reward();
            // Set hasHelped to true
            hasHelped = true;
            // Set questGiven to false
            questGiven = false;

            // Add new dialog for completing the quest
            DialogManager.dialogManagerInstance.AddDialog(new string[] {"Thanks for the help, here is your reward."}, npcName);
        }
        else
        {
            DialogManager.dialogManagerInstance.AddDialog(new string[] { "Have you completed that task yet? No? Oh, okay.." }, npcName);
        }
    }
}
