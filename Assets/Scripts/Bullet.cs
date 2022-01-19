using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float speed =20f;
    [SerializeField] private Rigidbody2D rb;
    public void OnObjectSpawn() {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
