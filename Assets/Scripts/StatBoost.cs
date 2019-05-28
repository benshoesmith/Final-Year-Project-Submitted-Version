using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBoost {

    public int boostValue; // Amount to add to default stat value

    public StatBoost(int boostValue)
    {
        this.boostValue = boostValue;
        Debug.Log("new stat bonus initiated");
    }

}
