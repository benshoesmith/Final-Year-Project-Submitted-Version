using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumables {

    void Consume(); // Non-modifying consumable
    void Consume(CombatantStats stats); // Modifying consumable

}
