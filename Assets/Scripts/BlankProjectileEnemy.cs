using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlankProjectileEnemy : MonoBehaviour, IEnemy {

    public int attackLevel, defenceLevel, attackSpeed, experienceForKilling;
    public string[] listOfDrops;
    public int[] chancesOfDrops;

    public GameObject playerGO;
    public Transform playerXform;
    public float projectileSpeed;
    public GameObject projectile;
    public float shootDelay;
    
    [HideInInspector]
    public int Experience { get; set; }
    public float currentHealth, maxHealth, detectionRadius;
    public LayerMask whoEnemyAttacks__setToPlayer; // Set in inspector - will only be aggressive to objects in the "Player" layer
    public LootTable LootTable { get; set; }
    public ItemPickUp itemPrefab__findInPrefabFolder;
    public EnemySpawner EnemySpawner { get; set; }
    public int ID { get; set; }
    public int enemyID;

    public Transform ProjectileSpawnPosition;

    MagicAttack magicAttack;
    private CombatantStats combatantStats;
    private NavMeshAgent navMeshAgent;
    private Collider[] inAggressionColliders;
    private Player player;

    void Start()
    {
        magicAttack = Resources.Load<MagicAttack>("Items/Weapons/Projectiles/MagicAttack");
        //playerXform = playerGO.transform;
        //transform.LookAt(playerXform);
        // Create new loot table
        LootTable = new LootTable();
        // Create new list of loot
        LootTable.lootDrops = new List<LootDrop>
        {
            // Populate loot list
            new LootDrop("sword", 1),
        };
        for(int i = 0; i < listOfDrops.Length; i++)
        {
            LootTable.lootDrops.Add(new LootDrop(listOfDrops[i], chancesOfDrops[i]));
        }
        ID = enemyID;
        Experience = experienceForKilling;
        // Assign nav mesh agent
        navMeshAgent = GetComponent<NavMeshAgent>();
        combatantStats = new CombatantStats(attackLevel, defenceLevel, attackSpeed);
        // Set health to full
        currentHealth = maxHealth;
    }

    void Update()
    {
        inAggressionColliders = Physics.OverlapSphere(transform.position, detectionRadius, whoEnemyAttacks__setToPlayer);
        // If player is in radius - if there is a collider in aggression colliders
        if(inAggressionColliders.Length > 0)
        {
            // Pursue player - get player component of collider
            PursuePlayer(inAggressionColliders[0].GetComponent<Player>());
            Debug.Log("Player found.");
        }
    }

    public void Attack()
    {
        // Instantiated magic attack spawned as magicAttack prefab on the proj spawn position using that rotation
        MagicAttack magicAttackInstantiated = (MagicAttack)Instantiate(magicAttack, ProjectileSpawnPosition.position, ProjectileSpawnPosition.rotation);
        // Set direction to forward
        magicAttackInstantiated.direction = ProjectileSpawnPosition.forward;
    }

    public void TakeDamage(int damageAmount)
    {
        // TODO: Implementdamage dealt based on (damage amount * (1 - (defence / 100))) E.g. (5 * (1 - (10/100))) = 5 * (1 - 0.1) = 4.95
        currentHealth -= damageAmount;
        // If health is depleted
        if(currentHealth <= 0)
        {
            // Call die method
            Die();
        }
    }

    public void Die()
    {
        // Call drop items
        DropItems();
        // Call EnemyDead and pass this gameobject
        CombatManager.EnemyDead(this);
        // Call Enemy Spawner Respawn method
        if(EnemySpawner != null)
        {
            this.EnemySpawner.Respawn();
        }
        // Destroy gameobject
        Destroy(gameObject);
    }

    void PursuePlayer(Player player)
    {

        this.transform.LookAt(player.transform);
        // Set destination path
        navMeshAgent.SetDestination(player.transform.position);
        this.player = player;
        // If enemy is within stopping distance of player
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // If attack hasn't been invoked yet (Stops it spamming)
            if(!IsInvoking("Attack"))
            {
                // Attack player at rate of attack speed
                InvokeRepeating("Attack", shootDelay, attackSpeed);
            }
        }
        else
        {
            // If player not in distnce, cancel attack
            CancelInvoke("Attack");

        }
    }

    void DropItems()
    {
        // New item = Loot drop
        ItemClass item = LootTable.GetLootDrop();
        // If item isn't null (Item has been dropped)
        if(item != null)
        {
            // Instantiate item drop in enemy transform position
            ItemPickUp instance = Instantiate(itemPrefab__findInPrefabFolder, transform.position, Quaternion.identity);
            instance.itemDrop = item;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Draw wire frame around object
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
