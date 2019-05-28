using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal {

    public int currentAmount;
    public int requiredAmount;
    public string description;
    public bool completed;
    public Quest Quest;

    public virtual void Initialise()
    {

    }

    public void CheckCompleted()
    {
        if (currentAmount >= requiredAmount)
        {
            CompleteQuest();
        }
    }

    public void CompleteQuest()
    {
        // Check all objectives in quest
        Quest.CheckObjectives();
        // Set completed to true
        completed = true;
    }

}
