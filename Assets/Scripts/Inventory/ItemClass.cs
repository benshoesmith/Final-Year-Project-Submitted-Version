using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemClass {

    public List<DefaultStats> stats; // List of stats
    public string itemSlug; // Name of item & prefab - like a proper file name, such as beginner_sword
    public string itemName; // NOT THE SLUG - Name used for UI in game
    public string description; // Brief description of item
    public string interactName; // Name of interaction, such as eat, equip, wear etc.
    public bool modifier; // Determines whether the item modifies the player stats, such as armour and weapons and certain potions
    public enum ItemType { Weapon, Shield, Helmet, Chestplate, Platelegs, Boots, Consumable, Quest} // Enum allows us to choose what type of item each item is
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))] // Newtonsoft method that allows the json file to contain a string for the enum and matches them
    public ItemType itemType;

    public ItemClass(List<DefaultStats> _stats, string _itemSlug) // Use underscore before names to differentiate between _stats and stats, since they're the same thing
    {
        stats = _stats;
        itemSlug = _itemSlug;
    }

    // Sets class variable values to the items variable values that are passed
    [Newtonsoft.Json.JsonConstructor] // Constructor for what newtonsoft json is working with
    public ItemClass(List<DefaultStats> _stats, string _itemSlug, string _itemName, string _description, string _interactName, bool _modifier, ItemType _itemType)
    {
        this.stats = _stats;
        this.itemSlug = _itemSlug;
        this.itemName = _itemName;
        this.description = _description;
        this.interactName = _interactName;
        this.modifier = _modifier;
        this.itemType = _itemType;
    }

}
