using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isLocked = true;
    private SpriteRenderer doorlock;
    // Start is called before the first frame update
    void Start()
    {
        doorlock = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor(bool State)
    {
        isLocked = State;
        if (isLocked)
        {
            doorlock.enabled = !isLocked;
        }
        else
        {
            doorlock.enabled = isLocked;
        }
    }
}
