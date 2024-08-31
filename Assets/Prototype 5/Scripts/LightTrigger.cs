using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject lanturn;
    private bool lanturnActive;

    // Start is called before the first frame update
    void Start()
    {
        lanturn.SetActive(true);
        lanturnActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TriggerLanturn();
    }

    public void TriggerLanturn()
    {
        lanturnActive = !lanturnActive;
        lanturn.SetActive(lanturnActive);
    }
}
