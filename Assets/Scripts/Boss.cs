using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour, IBoss
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float resetCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float firstAttackCooldown = .5f;
    [SerializeField] private Transform[] firePoints;
    //[SerializeField] private float attackLength = 3f;
    [SerializeField] UnityEvent fireRoseAttack;
    [SerializeField] private int maxNumberAttacks = 3;
    private int timesFired = 0;
    private HealthSystem healthSystem;
    private float cooldownTimer;
    private int phase = 1;
    private int tempPhase;

    void Start() {
        healthSystem = GetComponent<HealthSystem>();
    }
    void Awake()
    {
        cooldownTimer = firstAttackCooldown;
        
    }


    void Update() {
        
        if (cooldownTimer <= 0) {
            chooseAttack(phase);
            cooldownTimer = attackCooldown;
            tempPhase = phase;
        }

        if (timesFired == maxNumberAttacks) {
            phase = 3;
        }
        cooldownTimer -= Time.deltaTime;
    }

    void chooseAttack(int phase) {
        switch (phase) {
            //case for before fight begins
            case 0:
                break;

            //case for first projectile attack
            case 1:
                FireAttack1(this.gameObject);
                break;
            //case for firing off rose attack
            case 2:
                FireAttack2();
                break;

            //case for in between phase cooldowns
            case 3:
                ResetCooldown(); 
                break;

            default:
                break;
        }
    }

    void FireAttack1(GameObject sender) {
        timesFired++;
        Transform finalFirePoint = ChooseFirePoint(firePoints);
        ObjectPooler.Instance.SpawnFromPool("EnemyBullet", finalFirePoint.position, transform.rotation, sender);
    }

    void FireAttack2() {
        fireRoseAttack.Invoke();
    }

    Transform ChooseFirePoint(Transform[] firePoints) {
        int choice = Random.Range(0, firePoints.Length);
        return firePoints[choice];
    }

    public void SetPhase (int phase) {
        this.phase = phase;
    }

    void ResetCooldown() {
        phase = tempPhase;
        timesFired = 0;
        cooldownTimer = resetCooldown;
        
    }
    public void OnHit() {
    }

    public float GetBossHealth() {
        return healthSystem.GetHealth();
    }


}


