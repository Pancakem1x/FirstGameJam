using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutAttack : MonoBehaviour, IProjectile
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 50f;
    [SerializeField] float timer = .50f;
    [SerializeField] float downTimer = .75f;
    [SerializeField] float downSpeed = 5f;
    float tempTimer;
    int numReversals = 0;
    public void OnObjectSpawn(GameObject sender) {
        numReversals = 0;
        tempTimer = timer;
        rb.velocity = Vector2.up * speed;
    }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (tempTimer <= 0 && numReversals < 1) {
            numReversals++;
            rb.velocity = Vector2.down * downSpeed;
            tempTimer = downTimer;
        } else if (tempTimer <= 0 && numReversals >= 1) {
            rb.velocity = Vector2.zero;
        } else { 
            tempTimer -= Time.deltaTime;
        }

        
    }
}
