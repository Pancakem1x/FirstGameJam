using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] firePoints; 

    [SerializeField] private float timer = 5f;
    private float tempTimer;
    void Start()
    {
        tempTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempTimer <= 0) {
            Fire();
            tempTimer = timer;
        } else {
            tempTimer -= Time.deltaTime;
        }

    }

    public void Fire() {
        Debug.Log("spawned sprout attack");
        int numPoints = firePoints.Length;
        for (int i = 0; i < numPoints; i++) {
            Transform tempPoint = firePoints[i];
            ObjectPooler.Instance.SpawnFromPool("SproutAttack", tempPoint.position, Quaternion.Euler(0, 0, 0), this.gameObject);
        }
    
    }
}
