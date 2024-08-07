using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTimerP4 : MonoBehaviour
{
    [Header("Timer")]
    public Timer timer;
    public TMP_Text timerText;
    public GameObject endGame;

    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer(60, TimerDirection.CountDown);
        endGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.GetTime().ToString("Time: 0");

       /* if (timer.currentTime < 0)
        {
            endGame.SetActive(true);
            timer.currentTime = 0; 
            timer.StopTimer();
        }*/
    }

}
