using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;
    public int points;

    private void Start()
    {
        scoreText.text = ("Score: " + score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UpdateScore();
            Destroy(this.gameObject);
        }
    }

    private void UpdateScore()
    {
        score = score + points;
        scoreText.text = ("Score: " + score);
    }
}
