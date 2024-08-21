using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCircleTrigger : MonoBehaviour
{
    public SpellbookManager spellbookManager;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(spellbookManager.EndGame());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(spellbookManager.EndGame());
        }
    }
}
