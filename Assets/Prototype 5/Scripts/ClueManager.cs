using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject cluesPanel;
    private bool cluesOpen;

    // Start is called before the first frame update
    void Start()
    {
        cluesPanel.SetActive(false);
        cluesOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            TriggerSpellBook();
    }

    public void TriggerSpellBook()
    {
        cluesOpen = !cluesOpen;
        cluesPanel.SetActive(cluesOpen);
    }
}
