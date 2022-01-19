using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed =20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage = 1;
    public void OnObjectSpawn() {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<HealthSystem>() != null) {
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
            Debug.Log("Hit " + collision.name + " with current health: " + collision.GetComponent<HealthSystem>().GetHealth());
        }
    }
    
}
