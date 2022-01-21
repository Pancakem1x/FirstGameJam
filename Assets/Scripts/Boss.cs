using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IBoss
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float firstAttackCooldown = 3f;
    [SerializeField] private Transform firePoint;
    private float cooldownTimer;

    void Awake()
    {
        cooldownTimer = firstAttackCooldown;
    }

    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0) {
            Fire(this.gameObject);
            cooldownTimer = attackCooldown;
        }
    }

    public void OnHit() {
    }

    void Fire(GameObject sender) {
      //  int toFireLeft = -1;
        ObjectPooler.Instance.SpawnFromPool("EnemyBullet", firePoint.position, transform.rotation, sender);
    }
}


