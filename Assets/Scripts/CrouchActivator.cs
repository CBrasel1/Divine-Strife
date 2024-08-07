using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchActivator : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            var crouching = other.GetComponent<PlayerCrouching>();
            if(crouching != null) {
                crouching.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
