using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Playground : GameBehaviour
{
    public enum Direction { North, East, South, West }
    public GameObject player;
    public float moveDistance = 2f;
    public float moveTweenTime = 1f;
    public Ease moveEase;
    public float shakeStrength = 0.4f;

    [Header("UI")]
    public TMP_Text scoreText;
    public Ease scoreEase;
    private int score = 0;
    public int scoreBonus = 100;

    [Header("Timer")]
    public Timer timer;
    public TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer(60, TimerDirection.CountUp);

        ExecuteAfterSeconds(2, () =>
        {
            player.transform.localScale = Vector3.one * 2;
        });

        print("Game Started");

        ExecuteAfterFrames(1, () =>
        {
            print("One Frame Later");
        });

    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.GetTime().ToString("F2");
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (timer.timerDirection == TimerDirection.CountUp)
                timer.ChangeTimerDirection(TimerDirection.CountDown);
            else
                timer.ChangeTimerDirection(TimerDirection.CountUp);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            player.GetComponent<Renderer>().material.color = ColorX.GetRandomColour();

        if (Input.GetKeyDown(KeyCode.P))
            timer.ToggleTimerPause();

        if (timer.TimeExpired())
            Debug.Log("Time Expired");

        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.North);
        if (Input.GetKeyDown(KeyCode.D))
            MovePlayer(Direction.East);
        if (Input.GetKeyDown(KeyCode.S))
            MovePlayer(Direction.South);
        if (Input.GetKeyDown(KeyCode.A))
            MovePlayer(Direction.West);
    }

    void MovePlayer(Direction _direction)
    {
        switch (_direction)
        {
            case Direction.North:
                player.transform.DOMoveZ(player.transform.position.z + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
            case Direction.East:
                player.transform.DOMoveX(player.transform.position.x + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
            case Direction.South:
                player.transform.DOMoveZ(player.transform.position.z - moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
            case Direction.West:
                player.transform.DOMoveX(player.transform.position.x - moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
        }
        ChangeColour();
    }

    void ShakeCamera()
    {
        Camera.main.DOShakePosition(moveTweenTime / 2, shakeStrength);
    }

    void ChangeColour()
    {
        player.GetComponent<Renderer>().material.DOColor(ColorX.GetRandomColour(), moveTweenTime);
    }

    void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase);
        score = score + scoreBonus;
    }

    public int health = 1000000;
    public void Poison()
    {
        Debug.Log("Poisoned" + health);
        health -= 1;
    }

    public void AddHealth(int _health) => health += _health;
    public void LoseHealth(int _health) => health -= _health;

}
