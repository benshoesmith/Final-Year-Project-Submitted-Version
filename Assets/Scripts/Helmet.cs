using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour, IHelmet {

    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }
}
