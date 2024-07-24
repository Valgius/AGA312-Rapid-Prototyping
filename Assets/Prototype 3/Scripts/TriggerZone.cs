using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public float destructionDelay = 10f; // Delay in seconds before destroying the object

    private void OnTriggerExit(Collider other)
    {
        // Check if the entering object is the one you want to destroy
        if (other.CompareTag("Enemy"))
        {
            // Start the countdown to destroy the object
            Destroy(other.gameObject, destructionDelay);
        }
    }
}
