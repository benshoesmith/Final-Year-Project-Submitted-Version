using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platelegs : MonoBehaviour, IPlatelegs {

    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }
}
