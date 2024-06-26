using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBarrier : MonoBehaviour
{
    //DoorLockVariables
    private bool AllButtonsActive;
    private int ChildrenCount;
    public bool LeverActivated;
    public bool ButtonActivated;

    //Component Variables
    private SpriteRenderer sr;
    private Collider2D DoorCollider;

    //InterpolationVariables
    private float TargetY = 0;
    private float TargetStart = 0;
    private float t =0;

    // Start is called before the first frame update
    void Start()
    {
        ChildrenCount = this.transform.childCount;
        sr = this.transform.GetChild(ChildrenCount - 1).GetComponent<SpriteRenderer>();
        TargetStart = sr.transform.position.y;
        DoorCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(sr.transform.localPosition.y != TargetY)
        {
        sr.transform.localPosition = Vector2.Lerp(new Vector2(0,TargetStart),new Vector2(0,TargetY),t) ;
        t += Time.deltaTime / 1.5f;
        }
        else
        {
            TargetStart = sr.transform.localPosition.y;
            t = 0;
        }

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

    public void DoorOpen() 
    {
        TargetY = -3;
        DoorCollider.enabled = false;
    }

    public void DoorClose() 
    {
        TargetY = 0;
        DoorCollider.enabled=true;
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
