using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingTrapdoor : MonoBehaviour
{
    private Transform TrapdoorLeft;
    private Transform TrapdoorRight;
    private bool Open = true;
    private BoxCollider2D Box;

    public float ToggleTime = 5;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Box = GetComponent<BoxCollider2D>();
        TrapdoorLeft = transform.GetChild(0);
        TrapdoorRight = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > ToggleTime)
        {
            if (Open)
            {
                CloseTrapdoor();
            }
            else { OpenTrapdoor(); }
            time = 0;
        }
    }

    private void OpenTrapdoor()
    {
        Box.enabled = false;
        Open = true;
        TrapdoorRight.transform.eulerAngles = new Vector3(0, 0, 90);
        TrapdoorLeft.transform.eulerAngles = new Vector3(0, 0, -90);

    }
    private void CloseTrapdoor()
    {
        Box.enabled = true;
        Open = false;
        TrapdoorRight.transform.eulerAngles = Vector3.zero;
        TrapdoorLeft.transform.eulerAngles = Vector3.zero;
    }
}
