using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool Active;
    private bool PlayerTouching = false;
    public bool Flip =false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLever();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerTouching = false;
        }
    }

    void ToggleLever()
    {
        Active = !Active;
        sr.flipX =!sr.flipX;
        WaitTime();
    }
    public  IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
