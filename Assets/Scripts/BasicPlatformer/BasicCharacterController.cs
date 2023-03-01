using UnityEngine;
using System.Collections;

//--------------------------------------------
/*Basic Character Controller Includes:  
    - Basic Jumping
    - Basic grounding with line traces
    - Basic horizontal movement
 */
//--------------------------------------------

public class BasicCharacterController : MonoBehaviour
{
    protected bool facingRight = true;
    protected bool jumped;
    protected bool IsCrouching = false;
    public float speed = 5.0f;
    public float jumpForce = 1000;

    private float horizInput;
    private Animator anim;
    private float health = 100;


    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;
    public int coinCount;
    

    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            jumped = true;
            grounded = false;
            anim.SetBool("grounded", false);
            anim.SetBool("jump", true);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        Debug.Log(health);


        if (grounded)
        {
            jumped = false;
            anim.SetBool("grounded", true);
            anim.SetBool("jump", false);
        }

        if(horizInput > 0 || horizInput < 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {anim.SetBool("Move", false);}

        if(rb.velocity.y < 0 && !grounded)
        {
            anim.SetBool("Falling", true);
        }
        else { anim.SetBool("Falling", false); }
    }
    void FixedUpdate()
    {
        //Get Player input 
        horizInput = Input.GetAxis("Horizontal");
        //Move Character
        rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);

        // Detect if character sprite needs flipping
        if (horizInput > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCount++;
        }        
        else if (collision.tag == "Spike")
        {
            PlayerDamage(10);
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0f, 500));
            anim.SetBool("jump", true);
            anim.SetBool("grounded", false);
        }
    }

    public void PlayerDamage(int damageinbound)
    {
        health -= damageinbound;
    }
}
