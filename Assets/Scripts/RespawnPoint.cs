using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform respawnPoint;
    public Vector3 offset = Vector3.up;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") {
            other.gameObject.transform.position = respawnPoint.position + offset;
            other.gameObject.GetComponent<PlayerController>().Hurt();
        }
    }
}
