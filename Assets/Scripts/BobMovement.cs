using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    public bool facingRight;
    protected bool jump;

    public float maxSpeed = 5.0f;
    public float maxForce = 200.0f;
    public float horizInput = 1.0f;

    protected SpriteRenderer spriteRenderer;
    protected Animator animationController;
    protected Rigidbody2D rb;

    protected BoxCollider2D floorTrigger;
    protected CapsuleCollider2D characterCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        floorTrigger = GetComponent<BoxCollider2D>();

        characterCollider = GetComponent<CapsuleCollider2D>();

        if (facingRight == false) { Flip(); }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Level")) 
        {
            if(horizInput == 1)
            {
                horizInput = -1;
                rb.velocity = Vector2.zero;
            }
            else
            {
                horizInput = 1;
                rb.velocity = Vector2.zero;
            }
            Flip(); 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.rigidbody.velocity.y < -0.1f)
            {
                horizInput = 0;
                Destroy(gameObject, 0.1f);
                collision.rigidbody.AddForce(new Vector2(0, 500));
            }
            else
            {
                collision.rigidbody.AddForce(new Vector2 (650, 500));
                collision.transform.GetComponent<BasicCharacterController>().PlayerDamage(1);
            }
        }
    }

    void FixedUpdate()
    {

        if (Mathf.Abs(horizInput * (rb.velocity.x)) < maxSpeed)
        {
            rb.AddForce(horizInput * Vector2.right * maxForce);
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}