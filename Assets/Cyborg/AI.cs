using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator anim;
    public Vector3 groundCheckOffset;
    public SpriteRenderer rend;

    bool doneCurrent;

    private enum State
    {
        Idle,
        Right,
        Left
    }

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        doneCurrent = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doneCurrent)
        {
            StartCoroutine(ExecuteState());
        }
    }

    IEnumerator ExecuteState()
    {
        Debug.Log(currentState);
        currentState = (State)Random.Range(0, 3);
        switch (currentState)
        {
            case State.Idle:
                StartCoroutine(Idle());
                break;
            case State.Right:
                StartCoroutine(Run(1));
                break;
            case State.Left:
                StartCoroutine(Run(-1));
                break;
        }
        yield return null;
    }

    IEnumerator Run(float direction)
    {
        doneCurrent = false;

        anim.SetBool("isRunning", true);
        float partolTime = 0;

        rend.flipX = direction < 0;

        while (partolTime <= 3)
        {
            partolTime += Time.deltaTime;
            Vector3 r = transform.position + groundCheckOffset;
            Vector3 dir = Vector2.down + Vector2.right * 0.5f  * direction;
            RaycastHit2D ray = Physics2D.Raycast(r, dir, 1f, LayerMask.GetMask("Jumpable"));
            if (!ray.collider)
            {
                break;
            }
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            yield return null;
        }
        doneCurrent = true;
    }

    IEnumerator Idle()
    {
        doneCurrent = false;
        anim.SetBool("isRunning", false);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        doneCurrent = true;
    }
}
