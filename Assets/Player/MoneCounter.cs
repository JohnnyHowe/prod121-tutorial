using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneCounter : MonoBehaviour
{
    private int mone = 0;
    private bool destroyedThisFrame = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mone" && !destroyedThisFrame) {
            destroyedThisFrame = true;
            mone ++;
            Debug.Log("Mone: " + mone);
            Destroy(other.gameObject);
        } 
    }

    void FixedUpdate() {
        destroyedThisFrame = false;
    }
}
