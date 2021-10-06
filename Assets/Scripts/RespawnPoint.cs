using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform respawnPoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") {
            other.gameObject.transform.position = respawnPoint.position;
            other.gameObject.GetComponent<PlayerController>().Hurt();
        }
    }
}
