using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimatorController : MonoBehaviour
{
    public float runVelocityThreshold = 0.1f;

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        rb2d = GetComponent<Rigidbody2D>(); 
        renderer = GetComponent<SpriteRenderer>(); 
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
}
