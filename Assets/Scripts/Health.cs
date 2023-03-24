using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int HeartsCount;
    private int P_Health = 5;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    // Start is called before the first frame update
    void Start()
    {
        HeartsCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < HeartsCount ; i++)
        {
            Image Pic = transform.GetChild(i).GetComponent<Image>();
            if (i < P_Health)
            {
                Pic.sprite = HeartFull;
            }
            else
            {
                Pic.sprite = HeartEmpty;
            }
      
        }
    }
    public void UpdateHealth(int INhealth)
    {
        P_Health = INhealth;
    }

}
