using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour, IProjectile {

    private float m_lifetime = 0;
    public float m_frequency = 2;
    public float m_amplitude = 2;
    private Rigidbody2D rb;
    private Vector2 m_direction;
    public float speed = 5f;
    private GameObject sender; 


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        m_direction = Vector2.left;
    }

    void Update() {
    }

    private Vector2 GetProjectileVelocity(Vector2 _forward, float _speed, float _time, float _frequency, float _amplitude) {
        Vector2 up = new Vector2(-_forward.y, _forward.x);
        float up_speed = Mathf.Cos(_time * _frequency) * _amplitude * _frequency;
        return up * up_speed + _forward * _speed;
    }

    private void FixedUpdate() {
        m_lifetime += Time.fixedDeltaTime;
        rb.velocity = GetProjectileVelocity(m_direction, speed, m_lifetime, m_frequency, m_amplitude);
    }

    public void OnObjectSpawn(GameObject sender) {
        this.sender = sender;
    }
}
