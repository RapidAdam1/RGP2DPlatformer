using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DoorScript : MonoBehaviour
{
    private bool AllButtonsActive;
    private SpriteRenderer doorlock;
    protected GameObject self;
    private int ChildrenCount;
    // Start is called before the first frame update
    void Start()
    {
        self = GameObject.Find("Door");
        ChildrenCount = self.transform.childCount;
        doorlock = self.transform.GetChild(ChildrenCount-1).GetComponent<SpriteRenderer>();
        Debug.Log(ChildrenCount);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AllButtonsActive);
        AllButtonsActive = CheckForButtons();
        Debug.Log(AllButtonsActive);

        if (AllButtonsActive)
        {
            DoorOpen();
        }
    }

    public void DoorOpen() { doorlock.enabled = false; }
        
    public void DoorClose() { doorlock.enabled = true; }   
    
    private bool CheckForButtons()
    {
        for (int i = 0; i < ChildrenCount-1; i++) 
        { 
            B_Button BScript;
            BScript = self.transform.GetChild(i).GetComponent<B_Button>();
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
    }