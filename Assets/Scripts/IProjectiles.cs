using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectiles {

    Transform ProjectileSpawnPosition { get; set; }
    void FireProjectile();

}
