using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    [Header("Timer")]
    public Timer timer;
    public TMP_Text timerText;
    public GameObject endGame;

    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer(0, TimerDirection.CountUp);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.GetTime().ToString("F2");
    }

}
