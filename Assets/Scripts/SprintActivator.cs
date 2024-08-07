using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            var sprinting = other.GetComponent<PlayerSprinting>();
            if(sprinting != null) {
                sprinting.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
