using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    private Vector3 SpawnPoint;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        SpawnPoint = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y >= 1)
        {
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = 3;
        }
    }

    public void RespawnBox()
    {

        GetComponent<Transform>().position = SpawnPoint;
    }
}
