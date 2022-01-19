using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed =20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage = 1;
    private GameObject sender;
    public void OnObjectSpawn(GameObject sender) {
        rb.velocity = transform.right * speed;
        this.sender = sender;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(sender.tag)) return;

        if (collision.GetComponent<HealthSystem>() != null) {
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
            Debug.Log("Hit " + collision.name + " with current health: " + collision.GetComponent<HealthSystem>().GetHealth());
        }
    }
    
}
