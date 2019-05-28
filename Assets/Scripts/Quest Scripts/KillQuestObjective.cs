using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuestObjective : Goal { // Inherits from goal class

    public int enemyID;

    public override void Initialise()
    {
        base.Initialise();
        CombatManager.OnEnemyDeath += EnemyDeath;
    }

    public KillQuestObjective(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.enemyID = enemyID;
        this.description = description;
        this.completed = completed;
        this.currentAmount = currentAmount;
        this.requiredAmount = requiredAmount;
    }

    void EnemyDeath(IEnemy enemy)
    {
        // If enemy ids match
        if(enemy.ID == this.enemyID)
        {
            // Increase current amount by 1
            this.currentAmount++;
            // Check if quest objective is completed
            CheckCompleted();
        }
    }

}
