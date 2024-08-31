using UnityEngine;

public class RuneTriggerZone : MonoBehaviour
{
    public SpellbookManager spellbookManager;

    public GameObject deactiveRune;
    public GameObject activeRune;

    public bool isRuneActive;
    public bool isWizard;

    // Start is called before the first frame update
    void Start()
    {
        activeRune.SetActive(false);
        deactiveRune.SetActive(false);
        isRuneActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isRuneActive)
        {
            deactiveRune.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && isWizard)
            StartCoroutine(spellbookManager.SpellBookAcquired());
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
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !isRuneActive && !isWizard)
        {
            print("activated Rune");
            activeRune.SetActive(true);
            deactiveRune.SetActive(false);
            isRuneActive = true;
            spellbookManager.RuneTriggered();
        }
    }
}
