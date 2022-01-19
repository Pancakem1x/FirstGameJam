using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public int GetHealth() {
        return health;
    }

    public void Decease() {
        this.gameObject.SetActive(false);
    }
}
