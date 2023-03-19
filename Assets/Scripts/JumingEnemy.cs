using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumingEnemy : MonoBehaviour
{
    public float JumpHeight;
    public float TimeBetweenJumps;
    private Animator anim;
    private Rigidbody2D rb;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > TimeBetweenJumps)
        {
            Jump();
            time = 0;
        }

        if (rb.velocity.y < 0)
        {
            anim.SetTrigger("Falling");
            anim.ResetTrigger("Idle");
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetTrigger("Jumping");
        }
        else if (rb.velocity.y == 0)
        {
            anim.SetTrigger("Idle");
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0,JumpHeight));
        anim.ResetTrigger("Falling");
        anim.SetTrigger("Jumping");
        anim.ResetTrigger("Idle");
    }
}
