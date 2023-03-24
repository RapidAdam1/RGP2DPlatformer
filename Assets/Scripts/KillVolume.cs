using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool IsBox = collision.GetComponent<PushableBox>();
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = respawnPoint.position;
        }
        else if (IsBox)
        {
            collision.GetComponent<PushableBox>().RespawnBox();
        }
    }
}
