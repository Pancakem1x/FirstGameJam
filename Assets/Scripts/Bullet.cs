using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed =20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage = 1;
    private bool isEnemy;
    private GameObject sender;
    public void OnObjectSpawn(GameObject sender) {
        
        rb.velocity = transform.right * speed;
        this.sender = sender;
        //Debug.Log("Bullet spawned + moving");
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision with: " + collision.tag);


        if (collision.CompareTag(sender.tag)) return;

        if (collision.GetComponent<HealthSystem>() != null) {
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
            Debug.Log("Hit " + collision.name + " with current health: " + collision.GetComponent<HealthSystem>().GetHealth());
        }
    }
}
