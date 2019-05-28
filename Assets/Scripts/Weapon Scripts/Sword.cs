using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<DefaultStats> Stats { get; set; }
    public CombatantStats CombatantStats { get; set; }
    public int InitialDamage { get; set; }

    private Animator animator;

    void Start()
    {
        // Set animator var to be the swords animator
        animator = GetComponent<Animator>();
    }

    public void WeaponAttack(int damage)
    {
        InitialDamage = damage;
        // Trigger atatck animation
        animator.SetTrigger("Attack");
    }

    void OnTriggerEnter(Collider collider)
    {
        // If collider is an enemy
        if(collider.gameObject.tag == "Enemy")
        {
            // Call the take damage method from Ienemy and pass it the updated attack stat
            //collider.GetComponent<IEnemy>().TakeDamage(CombatantStats.stats[0].UpdateStatValue());
            collider.GetComponent<IEnemy>().TakeDamage(Stats[0].UpdateStatValue());
        }
    }
}
