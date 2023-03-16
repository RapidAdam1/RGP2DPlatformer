using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumingEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float JumpHeight;
    public float JumpTime;
    private bool CanJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (CanJump)
        {
            CanJump = false;
            rb.AddForce(new Vector2(0, JumpHeight));
            WaitForJump();
            CanJump = true;
        }
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(JumpTime);

    }
}
