using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] UnityEvent fireEvent; 
    [SerializeField] UnityEvent onHitEvent;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            fireEvent.Invoke();
        }
    }





}
