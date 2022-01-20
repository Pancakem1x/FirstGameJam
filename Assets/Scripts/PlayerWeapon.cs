using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    [SerializeField] private Transform firePoint;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(GameObject sender) {
        ObjectPooler.Instance.SpawnFromPool("PlayerBullet", firePoint.position, transform.rotation, sender);
        animator.SetBool("IsShooting", true);
    }

}
