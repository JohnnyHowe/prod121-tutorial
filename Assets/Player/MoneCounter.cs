using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneCounter : MonoBehaviour
{
    private int mone = 0;
    private bool destroyedThisFrame = false;
    public TextMeshProUGUI moneyText;

    private void Start() {
        moneyText.text = mone.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mone" && !destroyedThisFrame) {
            destroyedThisFrame = true;
            mone ++;
            Destroy(other.gameObject);
            moneyText.text = mone.ToString();
        } 
    }

    void FixedUpdate() {
        destroyedThisFrame = false;
    }
}
