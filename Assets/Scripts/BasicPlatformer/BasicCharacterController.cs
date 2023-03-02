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
            grounded = false;
            jumped = true;
            anim.SetBool("grounded", false);
            anim.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        
        if (grounded)
        {
            jumped = false;
            anim.ResetTrigger("Jump");
            anim.SetBool("grounded", true);
        }

        //Walking Anim State
        if(horizInput > 0 || horizInput < 0) {anim.SetBool("Move", true);}
        else {anim.SetBool("Move", false);}

        anim.SetFloat("VSpeed", rb.velocity.y);

        if (health <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }

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
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0f, 500));
        }
    }

    public void PlayerDamage(int damageinbound)
    {
        health -= damageinbound;
    }
}
