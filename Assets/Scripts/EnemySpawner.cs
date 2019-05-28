using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public bool enemyRespawns; // Checks to see if enemy should respawn
    [HideInInspector] public bool spawn;
    public float timeToRespawnInSeconds;
    private float currentTime;
    //[HideInInspector]
    public float radius;

	void Start ()
    {
        radius = 10.0f;
        // Call Spawn
        Spawn();
        // 
        currentTime = timeToRespawnInSeconds;
	}
	

	void Update ()
    {
		if(spawn)
        {
            // Decrease current time by delta time
            currentTime -= Time.deltaTime;
            // If currentTime depletes
            if(currentTime <= 0)
            {
                // Call Spawn
                Spawn();
            }
        }
	}

    public void Spawn()
    {
        // Instantiate enemy
        IEnemy instance = Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        // Set this object as spawner
        instance.EnemySpawner = this;
        // Reset spawn
        spawn = false;
    }

    public void Respawn()
    {
        // Set spawn to true
        spawn = true;
        // Reset spawn timer
        currentTime = timeToRespawnInSeconds;
    }

    private void OnDrawGizmosSelected()
    {
        //Draw wire frame around object
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
