using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWeapon, IProjectiles
{
    public List<DefaultStats> Stats { get; set; }
    public int InitialDamage { get; set; }
    public CombatantStats CombatantStats { get; set; }

    public Transform ProjectileSpawnPosition { get; set; }
    MagicAttack magicAttack;

    private Animator animator;

    void Start()
    {
        // Find magic attack prefab
        magicAttack = Resources.Load<MagicAttack>("Items/Weapons/Projectiles/MagicAttack");
        // Set animator var to be the swords animator
        animator = GetComponent<Animator>();
    }

    public void WeaponAttack(int damage)
    {

        // Trigger atatck animation
        animator.SetTrigger("Attack");
    }

    void OnTriggerEnter(Collider collider)
    {
        // If collider is an enemy
        if(collider.tag == "Enemy")
        {
            // Call the take damage method from Ienemy and pass it the updated attack stat
            collider.GetComponent<IEnemy>().TakeDamage(Stats[0].UpdateStatValue());
        }
    }

    public void FireProjectile()
    {
        // Instantiated magic attack spawned as magicAttack prefab on the proj spawn position using that rotation
        MagicAttack magicAttackInstantiated = (MagicAttack)Instantiate(magicAttack, ProjectileSpawnPosition.position, ProjectileSpawnPosition.rotation);
        // Set direction to forward
        magicAttackInstantiated.direction = ProjectileSpawnPosition.forward;
    }
}
