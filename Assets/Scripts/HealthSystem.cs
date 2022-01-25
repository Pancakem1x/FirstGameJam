using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;
    [SerializeField] HealthSlider healthSlider;
    [SerializeField] public UnityEvent<int> PhaseChange;
    private int phase;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.SetHealth(maxHealth);
    }

    private void Awake() {
        
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
            if (health <= 10 && phase != 2) {
                phase = 2;
                PhaseChange.Invoke(phase);
                Debug.Log("phase should be changed");
            }

        }
        healthSlider.SetHealth(health); 
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
