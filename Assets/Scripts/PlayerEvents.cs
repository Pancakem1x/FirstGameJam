using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] UnityEvent xMoveEvent;
    private float xMove;
    private bool jumpAttempt;


    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        jumpAttempt = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate() {
        
    }


}
