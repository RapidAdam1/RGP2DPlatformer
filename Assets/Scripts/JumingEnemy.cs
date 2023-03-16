using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumingEnemy : MonoBehaviour
{
    public float JumpHeight;
    public float TimeBetweenJumps;
    private Rigidbody2D rb;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0,JumpHeight));
    }
}
