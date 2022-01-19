using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IBoss
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private float firstAttackCooldown = 3f;
    private float cooldownTimer;

    void Awake()
    {
        cooldownTimer = firstAttackCooldown;
    }

    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0) {
            Fire();
            cooldownTimer = attackCooldown;
        }
    }

    public void OnHit() {
        health--;
    }

    void Fire() {
    }

    public int GetHealth() {
        return health;
    }

    public void SetHealth(int health) {
        this.health = health;
    }
}
