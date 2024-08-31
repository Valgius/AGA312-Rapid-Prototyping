using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum clues { Wizard, first, second, third}

public class ClueManager : MonoBehaviour
{
    public GameObject cluesPanel;
    private bool cluesOpen;
    public TMP_Text instructionsText;

    public GameObject wizardsGrave;
    public GameObject firstRune;
    public GameObject secondRune;
    public GameObject thirdRune;

    // Start is called before the first frame update
    void Start()
    {
        cluesPanel.SetActive(false);
        firstRune.SetActive(false);
        secondRune.SetActive(false);
        thirdRune.SetActive(false);
        cluesOpen = false;
        instructionsText.text = "Press R to Open Clue page.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            TriggerClues();
    }

    public void TriggerClues()
    {
        cluesOpen = !cluesOpen;
        cluesPanel.SetActive(cluesOpen);
    }

    public void ChangeInstructions()
    {
        instructionsText.text = "Press R to Open Clue page.\nPress E to use Spell Book ";
        firstRune.SetActive(true);
        secondRune.SetActive(true);
        thirdRune.SetActive(true);
    }

    
}
