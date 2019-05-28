using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class DefaultStats {

    public int defaultStatValue;
    public int updatedValue;
    public string statName;
    public string statDescription;
    public List<StatBoost> statBoosts;
    public enum DefaultStatType { Attack, Defence, Speed}
    [JsonConverter(typeof(StringEnumConverter))] // Takes string representation and sets as statType
    public DefaultStatType StatType;

    //public DefaultStats(int defaultStatValue, string statName)
    //{
    //    // Create new List
    //    this.statBoosts = new List<StatBoost>();
    //    this.defaultStatValue = defaultStatValue;
    //    this.statName = statName;
    //}

    [Newtonsoft.Json.JsonConstructor]
    public DefaultStats(DefaultStatType statType, int defaultStatValue, string statName)
    {
        // Create new List
        this.statBoosts = new List<StatBoost>();
        this.StatType = statType;
        this.defaultStatValue = defaultStatValue;
        this.statName = statName;
    }

    public void AddStatBoosts(StatBoost statBoost)
    {
        // Add Stat boost to list of stat boosts
        this.statBoosts.Add(statBoost);
    }

    public void RemoveStatBoosts(StatBoost statBoost)
    {
        // Remove Stat boost from list of stat boosts, find boost value that matches in passed value and remove it
        this.statBoosts.Remove(statBoosts.Find(x => x.boostValue == statBoost.boostValue));
    }

    public int UpdateStatValue()
    {
        // Reset updated value to 0
        this.updatedValue = 0;
        // Add boost value to each stat updated value int
        this.statBoosts.ForEach(x => this.updatedValue += x.boostValue);
        // Add this to the default stat value
        updatedValue += defaultStatValue;
        // Return updated value
        return updatedValue;
    }

}
