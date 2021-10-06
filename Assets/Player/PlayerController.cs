using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float runAcceleration = 1;
    public float maxRunSpeed = 1;
    public float distToGround = 0.1f;
    public float jumpPower = 10;
    public LayerMask groundLayer;
    [Header("Animation")]
    public Animator playerAnimator;
    public Image[] hearts;

    int health = 0;
    float horizontal = 0;
    bool jump = false;

    Rigidbody2D rb;

    void Start()
    {
        health = 3;
        UpdateHearts();
        rb = GetComponent<Rigidbody2D>();
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
    }

    void UpdateRB()
    {
        float newX = Mathf.Clamp(rb.velocity.x + runAcceleration * Time.fixedDeltaTime * horizontal, -maxRunSpeed, maxRunSpeed);
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
        bool isRunning = Mathf.Abs(horizontal) > 0;
        playerAnimator.SetBool("isRunning", isRunning);

        if (isRunning)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void Hurt() {
        health -= 1;
        UpdateHearts();
        if (health < 0) {
            Debug.Log("GameOver");
        }
    }

    void UpdateHearts() {
        for (int i = 0; i < 3; i ++) {
            hearts[i].gameObject.SetActive(i < health);
        }
    }

    public bool isOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround, groundLayer).collider != null;
    }
}
