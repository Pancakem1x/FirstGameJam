using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private Transform firePoint;

    private void Awake() {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        ObjectPooler.Instance.SpawnFromPool("PlayerBullet", firePoint.position, transform.rotation); 
    }

}
