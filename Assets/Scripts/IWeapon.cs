using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon  {

    List<DefaultStats> Stats { get; set; }
    CombatantStats CombatantStats { get; set; }
    void WeaponAttack(int damage);
    int InitialDamage { get; set; }
}
