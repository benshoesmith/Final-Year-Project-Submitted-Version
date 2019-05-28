using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShield  {

    List<DefaultStats> Stats { get; set; }
    CombatantStats CombatantStats { get; set; }
}
