using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float runAcceleration = 1;
    public float maxRunSpeed = 1;

    float horizontal = 0;
    bool jump = false;

    Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey("space");
    }

    void FixedUpdate() {
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x + runAcceleration * Time.deltaTime * horizontal, - maxRunSpeed, maxRunSpeed), _rb.velocity.y);
    }
}
