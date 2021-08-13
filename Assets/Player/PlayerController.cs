using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float runAcceleration = 1;
    public float maxRunSpeed = 1;
    public float distToGround = 0.1f;
    public float jumpPower = 10;
    [Header("Animation")]
    public Animator playerAnimator;
    // public float minAnimationRunVelocity = 1;

    float horizontal = 0;
    bool jump = false;

    Rigidbody2D rb;
    // SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("space") || Input.GetMouseButtonDown(0)) jump = true;
    }

    void FixedUpdate()
    {
        UpdateRB();
        UpdateAnimator();
        // Debug.Log(isOnGround());
    }

    void UpdateRB()
    {
        float newX = Mathf.Clamp(rb.velocity.x + runAcceleration * Time.deltaTime * horizontal, -maxRunSpeed, maxRunSpeed);
        float newY = rb.velocity.y;
        if (jump)
        {
            jump = false;
            if (isOnGround()) newY = jumpPower;
        }
        rb.velocity = new Vector2(newX, newY);
    }

    void UpdateAnimator()
    {
        // bool isRunning = Mathf.Abs(rb.velocity.x) > minAnimationRunVelocity;
        bool isRunning = Mathf.Abs(horizontal) > 0;
        playerAnimator.SetBool("isRunning", isRunning);

        if (isRunning) {
            // spriteRenderer.flipX = rb.velocity.x < 0;
            transform.localScale = new Vector3(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public bool isOnGround()
    {
        // return Physics2D.Raycast(transform.position, -Vector3.up, distToGround);
        return true;    // TODO
    }
}
