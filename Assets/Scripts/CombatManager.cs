using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public delegate void EnemyManager(IEnemy enemy); // Handles enemies - for combat system
    public static event EnemyManager OnEnemyDeath; // Handles when enemies die

    public static void EnemyDead(IEnemy enemy)
    {
        // Check if enemy exists
        if(enemy != null)
        {
            // Call onEnemyDeath
            OnEnemyDeath(enemy);
        }
    }

}
