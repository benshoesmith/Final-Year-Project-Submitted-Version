using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject mainHand;
    [HideInInspector] public GameObject heldWeapon;

    Transform projectileSpawnPosition;
    CombatantStats combatantStats;
    IWeapon equippedWeapon;
    public ItemClass currentHeldItem;

    // Can be used for shield and armour too - reuse

    void Start()
    {
        // Set projectile spawn position
        projectileSpawnPosition = transform.Find("ProjectilePosition");
        // Get combat stats from player
        combatantStats = GetComponent<Player>().combatantStats;
    }

    void Update()
    {
        //If L is pressed
        if(Input.GetKeyDown(KeyCode.L))
        {
            // Call Attack method
            Attack();
        }
    }

    public void Attack()
    {
        // If weapon is equipped
        if(equippedWeapon != null)
        {
            // Call weapon interface attack method - unique to each weapon and changed in each weapon script - override function - e.g. check sword script
            equippedWeapon.WeaponAttack(CalcDamage());
        }
        else
        {
            // Output to UI - "No weapon equipped"
            Debug.Log("No weapon equipped");
        }

    }

    public void EquipWeapon(ItemClass item)
    {
        // If a weapon is held
        if(heldWeapon != null)
        {
            RemoveWeapon();
        }
        // Equip new weapon
        heldWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Weapons/" + item.itemSlug), mainHand.transform.position, mainHand.transform.rotation); // Finds prefab in resources folder with the same item slug and instantiates it on the main hand
        

        // Get weapon interface from the held weapon
        equippedWeapon = heldWeapon.GetComponent<IWeapon>();
        

        // If the weapon has a projectile interface component
        if(heldWeapon.GetComponent<IProjectiles>() != null)
        {
            // Get Iprojectile component from held weapon and set the spawn position to the player spawn position
            heldWeapon.GetComponent<IProjectiles>().ProjectileSpawnPosition = projectileSpawnPosition;
        }

        // Set new weapon stats
        equippedWeapon.Stats = item.stats;
        // Set weapon position to mainhand
        heldWeapon.transform.SetParent(mainHand.transform);
        // Set stats for equipped weapon
        equippedWeapon.Stats = item.stats;
        // Set current weapon to new weapon
        currentHeldItem = item;
        // Add weapon stats to player
        combatantStats.AddStatBoost(item.stats);
        // Pass item being equipped to UIManager
        UIManager.WeaponEquipped(item);
        UIManager.StatsChanged();

        Debug.Log(equippedWeapon.Stats[0]);
    }

    public void RemoveWeapon()
    {
        // Add current weapon to inventory
        InventoryManager.instance.AddItemToInventory(currentHeldItem.itemSlug);
        // Remove weapon stat boosts
        combatantStats.RemoveStatBoost(equippedWeapon.Stats);
        // Destroy weapon gameobject
        Destroy(heldWeapon.transform.gameObject);
        // Update stats in UI
        UIManager.StatsChanged();
    }

    private int CalcDamage()
    {
        // Damage = player attack level + small random value * 2
        int updatedDamage = (combatantStats.GetStat(DefaultStats.DefaultStatType.Attack).UpdateStatValue() + Random.Range(2, 5) * 2);
        Debug.Log("Damage dealt = " + updatedDamage);
        return updatedDamage;
    }

}
