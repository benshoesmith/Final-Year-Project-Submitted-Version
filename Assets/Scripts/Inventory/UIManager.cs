using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    
    public delegate void ItemManager(ItemClass item); // Create itemmanager as type
    public static event ItemManager OnItemAddedToInventory; // Using that type
    public static event ItemManager OnWeaponEquipped;
    public static event ItemManager OnShieldEquipped;
    public static event ItemManager OnHelmetWorn;
    public static event ItemManager OnBodyWorn;
    public static event ItemManager OnLegsWorn;
    public static event ItemManager OnFeetWorn;

    public delegate void PlayerHealthManager(int currentHealth, int maxHealth);
    public static event PlayerHealthManager OnPlayerHealthEffected;

    public delegate void PlayerStatsManager();
    public static event PlayerStatsManager OnStatsChanged;

    public delegate void PlayerLevelManager();
    public static event PlayerLevelManager OnPlayerLevelUp;

    public static void ItemAddedToInventory(ItemClass item)
    {
        OnItemAddedToInventory(item);
    }

    public static void WeaponEquipped(ItemClass item)
    {
        OnWeaponEquipped(item);
    }

    public static void ShieldEquipped(ItemClass item)
    {
        OnShieldEquipped(item);
    }

    public static void HelmetWorn(ItemClass item)
    {
        OnHelmetWorn(item);
    }

    public static void BodyWorn(ItemClass item)
    {
        OnBodyWorn(item);
    }

    public static void LegsWorn(ItemClass item)
    {
        OnLegsWorn(item);
    }

    public static void FeetWorn(ItemClass item)
    {
        OnFeetWorn(item);
    }

    public static void HealthEffected(int currentHealth, int maxHealth)
    {
        OnPlayerHealthEffected(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLevelUp()
    {
        OnPlayerLevelUp();
    }
}
