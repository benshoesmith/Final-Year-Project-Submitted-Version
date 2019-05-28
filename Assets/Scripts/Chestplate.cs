using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestplate : MonoBehaviour, IChestplate {

    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }
}
