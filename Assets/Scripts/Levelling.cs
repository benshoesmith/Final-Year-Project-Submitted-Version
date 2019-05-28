using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelling : MonoBehaviour {

    public int level;
    public int currentExperience;
    public int experienceMultiplier;
    public int experienceToLevel { get { return level * (experienceMultiplier + level); } } // Required Experience returns levelling formula

	// Use this for initialization
	void Start ()
    {
        CombatManager.OnEnemyDeath += EnemyExperience; // Listens for enemy death and calls EnemyExperience
        level = 1;
        if(experienceMultiplier <= 0)
        {
            experienceMultiplier = 80;
        }
	}

    // Method to get enemies experience amount
    public void EnemyExperience(IEnemy enemy)
    {
        // Pass GiveExperience the enemy's experience amount
        GiveExperience(enemy.Experience);
    }

    public void GiveExperience(int experience)
    {
        // Add experience to current experience
        currentExperience += experience;
        // When a level is gained (current exp surpasses exp to level)
        while(currentExperience >= experienceToLevel)
        {
            // Take experience to level from current experience (reset current experience)
            currentExperience -= experienceToLevel;

            // Increment level
            level++;
        }
        // Update player level up UI
        UIManager.PlayerLevelUp();

    }
	

}
