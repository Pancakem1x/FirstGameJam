using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        if (health - damage <= 0) {
            health = 0;
            Decease();
        } else {
            health -= damage;
        }
    }

    public float GetHealth() {
        return health;
    }

    public float GetHealthPercent() {
        return health / maxHealth;
    }

    public void Decease() {
        this.gameObject.SetActive(false);
    }
}
