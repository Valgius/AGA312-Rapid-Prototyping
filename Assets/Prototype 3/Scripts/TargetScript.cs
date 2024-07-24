using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetScript : MonoBehaviour
{
    //public TMP_Text scoreText;
    //public int score;
    //public int points;

    public float knockOverThreshold = 45f; // Threshold angle in degrees to consider the object "knocked over"

    private bool isKnockedOver = false;

    private void Start()
    {
        //scoreText.text = ("Score: " + score);
    }

    private void Update()
    {
        // Check if the object's rotation exceeds the knockOverThreshold
        if (!isKnockedOver && Mathf.Abs(transform.rotation.eulerAngles.x) > knockOverThreshold)
        {
            Debug.Log(gameObject.name + " has been knocked over!");
            isKnockedOver = true;

            // Perform action when knocked over (e.g., delete the object)
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
        }
    }

    /*private void UpdateScore()
    {
        score += points;
        scoreText.text = ("Score: " + score);
    }*/
}
