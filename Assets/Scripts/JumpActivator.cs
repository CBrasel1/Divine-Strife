using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpActivator : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            var jumping = other.GetComponent<PlayerJumping>();
            if(jumping != null) {
                jumping.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
