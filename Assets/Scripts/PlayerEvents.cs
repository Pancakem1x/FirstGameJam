using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> fireEvent; 
    [SerializeField] UnityEvent onHitEvent;


    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            fireEvent.Invoke(this.gameObject);
            Debug.Log("fired from gameObject:" + this.gameObject.tag);
        }
    }





}
