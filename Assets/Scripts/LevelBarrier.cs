using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBarrier : MonoBehaviour
{
    private bool AllButtonsActive;
    private int ChildrenCount;
    public bool LeverActivated;
    public bool ButtonActivated;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        ChildrenCount = this.transform.childCount;
        sr = this.transform.GetChild(ChildrenCount - 1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonActivated)
        {
            AllButtonsActive = CheckForButtons();

            if (AllButtonsActive)
            {
                DoorOpen();
            }
            else if (!AllButtonsActive)
            {
                DoorClose();
            }
        }

        else if (LeverActivated) 
        {
            bool LeversActive = CheckForLevers();
            if (LeversActive)
            {
                DoorOpen();
            }
            else if (!LeversActive)
            {
                DoorClose();
            }
        }

    }

    public void DoorOpen() { Debug.Log("Open"); }

    public void DoorClose() 
    { 
       sr =  this.transform.GetChild(ChildrenCount - 1).GetComponent<SpriteRenderer>();  
    }

    private bool CheckForButtons()
    {
        for (int i = 0; i < ChildrenCount - 1; i++)
        {
            B_Button BScript;
            BScript = this.transform.GetChild(i).GetComponent<B_Button>();
            if (BScript != null)
            {
                if (!BScript.Active)
                {
                    return false;
                }
            }
            else { return false; }
        }
        return true;
    }

    private bool CheckForLevers()
    {
        for (int i = 0; i < ChildrenCount - 1; i++)
        {
            Lever LScript;
            LScript = this.transform.GetChild(i).GetComponent<Lever>();
            if (LScript != null)
            {
                if (!LScript.Active)
                {
                    return false;
                }
            }
            else { return false; }
        }
        return true;
    }
}
