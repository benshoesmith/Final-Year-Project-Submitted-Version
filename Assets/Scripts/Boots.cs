using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour, IBoots {

    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }
}
