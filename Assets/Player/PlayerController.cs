using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float runAcceleration = 1;
    public float maxRunSpeed = 1;
    public float jumpPower = 1;
    public float distToGround = 2;
    public UnityEvent onJump;

    float horizontal = 0;
    bool jump = false;

    Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("space")) jump = true;
    }

    void FixedUpdate() {
        float newX = Mathf.Clamp(_rb.velocity.x + runAcceleration * Time.deltaTime * horizontal, - maxRunSpeed, maxRunSpeed);
        float newY = _rb.velocity.y;
        if (jump) {
            jump = false;
            if (isOnGround())
            {newY = jumpPower;
            onJump.Invoke();};
        }
        _rb.velocity = new Vector2(newX, newY);
    }

    public bool isOnGround() {
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
