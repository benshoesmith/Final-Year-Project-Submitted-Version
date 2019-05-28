using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatantStats {

    // This script is attached to each combatant in the game, the stats are then declared in here. Will be updated to be changed in inspector later, good base for item stat updates

    public List<DefaultStats> stats = new List<DefaultStats>();

    public CombatantStats(int attack, int defence, int speed)
    {
        stats = new List<DefaultStats>() {
            // Set up combatant stats using enum and pass it corresponding passed value and the name - eg. enum Attack, pass attack value and "Attack" as name
            new DefaultStats(DefaultStats.DefaultStatType.Attack, attack, "Attack"),
            new DefaultStats(DefaultStats.DefaultStatType.Defence, defence, "Defence"),
            new DefaultStats(DefaultStats.DefaultStatType.Speed, speed, "Speed")
        };
    }

    public DefaultStats GetStat(DefaultStats.DefaultStatType stat)
    {
        // Find stat type that matches passed stat type and return it
        return stats.Find(x => x.StatType == stat);
    }

    // Called when item is equipped
    public void AddStatBoost(List<DefaultStats> statBoosts)
    {
        // For each stat boost in the stat boost list, see if the stat names match and add a new stat boost to that stat
        foreach(DefaultStats statBoost in statBoosts)
        {
            // Take stattype of bonus looped on, go to GetStat() and return matching stat so the bonus can be added to it
           GetStat(statBoost.StatType).AddStatBoosts(new StatBoost(statBoost.defaultStatValue));
        }
    }

    // Called when item is removed
    public void RemoveStatBoost(List<DefaultStats> statBoosts)
    {
        // For each stat boost in the stat boost list, see if the stat names match and remove the stat boost to that stat
        foreach (DefaultStats statBoost in statBoosts)
        {
            stats.Find(x => x.statName == statBoost.statName).RemoveStatBoosts(new StatBoost(statBoost.defaultStatValue));
        }
    }
}
