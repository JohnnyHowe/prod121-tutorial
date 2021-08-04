using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimatorController : MonoBehaviour
{
    public float runVelocityThreshold = 0.1f;

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer renderer;
    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        rb2d = GetComponent<Rigidbody2D>(); 
        renderer = GetComponent<SpriteRenderer>(); 
        controller = GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = Mathf.Abs(rb2d.velocity.x) > runVelocityThreshold;
        animator.SetBool("running", isRunning);
        if (isRunning)
        {
            renderer.flipX = rb2d.velocity.x < 0;
        }
    }

    void FixedUpdate() {
        animator.SetBool("onGround", controller.isOnGround());
    }

    public void SetJumpTrigger() {
        animator.SetTrigger("jump");
    }
}
