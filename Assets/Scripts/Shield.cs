using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IShield {
    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }

}
