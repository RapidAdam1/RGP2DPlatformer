using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour
{
    public bool Active = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            Active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            Active = false;
        }
    }
}
