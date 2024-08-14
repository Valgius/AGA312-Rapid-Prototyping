using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTriggerZone : MonoBehaviour
{
    public GameObject deactiveRune;
    public GameObject activeRune;

    public bool isRuneActive;

    // Start is called before the first frame update
    void Start()
    {
        activeRune.SetActive(false);
        deactiveRune.SetActive(false);
        isRuneActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isRuneActive)
        {
            deactiveRune.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isRuneActive)
        {
            deactiveRune.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            print("activated Rune");
            activeRune.SetActive(true);
            deactiveRune.SetActive(false);
            isRuneActive = true;
        }
    }
}
