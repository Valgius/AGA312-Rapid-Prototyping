using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SpellbookManager : MonoBehaviour
{
    public GameObject spellbook;
    public GameObject barrier;
    public GameObject spellCircle;

    public GameObject spellbookPanel;
    private bool spellbokOpen;
    public GameObject endGamePanel;

    public int RunesActivated;

    // Start is called before the first frame update
    void Start()
    {
        spellbokOpen = false;
        spellbook.SetActive(false);
        spellbookPanel.SetActive(false);
        spellCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            TriggerSpellBook();
    }

    public void TriggerSpellBook()
    {
        spellbokOpen = !spellbokOpen;
        spellbookPanel.SetActive(spellbokOpen);
    }

}
