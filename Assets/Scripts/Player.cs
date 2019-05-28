using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerPanel playerPanelP;
    public InventoryManager invManager;
    public GameObject invManagerGO;
    public GameObject playerPanelGO;
    public CombatantStats combatantStats;
    public List<DefaultStats> Stats { get; set; }
    public int currentHealth, maxHealth;
    [HideInInspector] public Levelling levelling;

    void Awake()
    {

        combatantStats = new CombatantStats(10, 10, 5);
    }

    void Start()
    {
        playerPanelP = playerPanelGO.GetComponent<PlayerPanel>();
        invManager = invManagerGO.GetComponent<InventoryManager>();
        levelling = GetComponent<Levelling>();
        // Set health to full
        currentHealth = maxHealth;
        UIManager.HealthEffected(currentHealth, maxHealth);
    }

    public void DamageToPlayer(int damage)
    {
        // Take defence stat from damage
        damage -= combatantStats.stats[1].UpdateStatValue();
        Debug.Log(combatantStats.stats[1].UpdateStatValue().ToString());
        // If damage is less than 2
        if(damage <= 1)
        {
            // Damage = 1
            damage = 1;
        }
        // When damage is dealt to player, take damage from current health
        currentHealth -= (damage);

        Debug.Log("Player takes " + damage + " damage.");
        // If health depletes, call die method
        if (currentHealth <= 0)
        {
            Die();
        }
        // Update Health UI
        UIManager.HealthEffected(currentHealth, maxHealth);
    }

    public void Die()
    {
        // Death scene
        Debug.Log("Oh dear, you are dead.");
        currentHealth = maxHealth;
        // Update Health UI
        UIManager.HealthEffected(currentHealth, maxHealth);
    }

    public void SaveData(Player player)
    {
        //SaveGame.SaveData(this, invManager, playerPanelP);
        SaveGame.SaveData(this);
    }

    public void LoadData()
    {
        GameData data = SaveGame.LoadData();

        levelling.level = data.playerLevel;
        currentHealth = data.playerHealth;
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        transform.position = position;
        //for(int i = 0; i < data.itemSlugInInventory.Length; i++)
        //{
        //    invManager.AddItemToInventory(data.itemSlugInInventory[i]);
        //}
    }

}
