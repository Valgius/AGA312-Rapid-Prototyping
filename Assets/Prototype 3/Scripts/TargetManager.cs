using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    public GameObject target; // Type of object to check for
    public GameObject endGame;
    public Timer timer;
    public TMP_Text finalTimeText;


    private void Start()
    {
        endGame.SetActive(false);
    }

    void Update()
    {
        // Check how many instances of objectTypeToCheck are in the scene
        GameObject[] objectsOfType = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject obj in objectsOfType)
        {
            if (obj.CompareTag("Tree"))
            {
                count++;
            }
        }

        // If no targets are left, end game
        if (count == 0)
        {
            Debug.Log("No instances of " + target.name + " found in the scene.");
            endGame.SetActive(true);
            timer.StopTimer();
            finalTimeText.text = "Your final time was: " + timer.GetTime().ToString("F2");


}
    }
}
