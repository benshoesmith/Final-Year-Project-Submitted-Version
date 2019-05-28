using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConsumable : MonoBehaviour, IConsumables
{
    public void Consume()
    {
        Debug.Log("Consumed Test Consumable");
    }

    public void Consume(CombatantStats stats)
    {
        Debug.Log("Used Test Consumable");
    }
}
