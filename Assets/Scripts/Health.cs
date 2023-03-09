using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int Hearts = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 9 ; i++)
        {
            if (i < Hearts)
            {
                transform.GetChild(i).gameObject.active = false;
            }
            else
            {
                transform.GetChild(i).gameObject.active = true;
            }
        }
    }
    public void UpdateHealth(int health)
    {
        Hearts = health;
    }

}
