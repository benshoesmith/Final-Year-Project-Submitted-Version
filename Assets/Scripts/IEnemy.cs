using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {

    void TakeDamage(int damageAmount);
    void Attack();
    void Die();
    int Experience { get; set; }
    int ID { get; set; }
    EnemySpawner EnemySpawner { get; set; }

}
