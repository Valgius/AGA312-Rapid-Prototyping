using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;

public class SpellbookManager : MonoBehaviour
{
    public GameObject spellbook;
    public GameObject barrier;
    public GameObject spellCircle;

    public int runesActivated;
    public int maxRunes;
    public TMP_Text runesText;

    public bool hasSpellbook;

    public GameObject endGamePanel;
    public GameObject endGameTextPanel;

    // Start is called before the first frame update
    void Start()
    {
        //spellbook.SetActive(false);
        spellCircle.SetActive(false);
        UpdateRunesText();
        endGameTextPanel.SetActive(false);
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

    public void SpellBookAcquired()
    {
        hasSpellbook = true;
        spellbook.SetActive(true);
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
