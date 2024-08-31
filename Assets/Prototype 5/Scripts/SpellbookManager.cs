using System.Collections;
using UnityEngine;
using TMPro;

public class SpellbookManager : MonoBehaviour
{
    public ClueManager clueManager;

    public GameObject spellbook;
    public GameObject barrier;
    public GameObject spellCircle;
    public GameObject wizardsLocation;

    public GameObject runes;
    public int runesActivated;
    public int maxRunes;
    public TMP_Text runesText;

    public bool hasSpellbook;

    public GameObject endGamePanel;
    public GameObject endGameTextPanel;

    public GameObject textBoxPanel;
    public TMP_Text textBoxText;


    // Start is called before the first frame update
    void Start()
    {
        spellCircle.SetActive(false);
        UpdateRunesText();
        runesText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (runesActivated == maxRunes)
        {
            spellCircle.SetActive(true);
        }
    }

    public void RuneTriggered()
    {
        runesActivated++;
        UpdateRunesText();
    }

    public IEnumerator SpellBookAcquired()
    {

        yield return new WaitForSeconds(0.5f);
        textBoxPanel.SetActive(true);
        textBoxText.text = "You have found the wizard's grave, his spell book is yours";
        yield return new WaitForSeconds(2f);
        textBoxText.text = "It speaks of a ritual that must be performed";
        yield return new WaitForSeconds(2f);
        textBoxText.text = "Use the book to activate the three runes then cast the final spell in the circle";
        yield return new WaitForSeconds(2f);
        textBoxText.text = "He has left hints to find these runes in your clue page";
        yield return new WaitForSeconds(2f);
        textBoxPanel.SetActive(false);
        hasSpellbook = true;
        spellbook.SetActive(true);
        wizardsLocation.SetActive(false);
        clueManager.ChangeInstructions();
        runes.SetActive(true);
    }

    public void UpdateRunesText()
    {
        runesText.text = "Runes Activated: " + runesActivated + " / " + maxRunes;
    }

    public IEnumerator EndGame()
    {
        barrier.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        endGameTextPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        endGameTextPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        endGamePanel.SetActive(true);
    }
}
