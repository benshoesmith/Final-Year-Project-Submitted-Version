using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour {

    public Vector3 direction;
    public float range;
    public int damage;

    Vector3 spawnPosition;

    void Start()
    {
        // Init range and damage
        range = 20f;
        damage = 5;
        // Get projectile position on spawn
        spawnPosition = transform.position;
        // Add force to the rigidbody when spawned (direction * speed)
        GetComponent<Rigidbody>().AddForce(direction * 50);
    }

    void Update()
    {
        // If the distance between the spawn position and current position is creater than the range
        if(Vector3.Distance(spawnPosition, transform.position) >= range)
        {
            // Call die method
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If projectile collides with enemy
        if(collision.transform.tag == "Enemy")
        {
            // Get Ienemy component and call take damage method and pass in damage
            collision.transform.GetComponent<IEnemy>().TakeDamage(damage);
        }
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().DamageToPlayer(damage);
        }
        // Call die method
        Die();
    }

    void Die()
    {
        // Destroy projectile
        Destroy(gameObject);
    }

}
