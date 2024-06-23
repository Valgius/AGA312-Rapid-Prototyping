using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public enum Direction { North, East, South, West}
    public GameObject player;
    public float moveDistance = 2f;
    public float moveTweenTime = 1f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Ease moveEase;

    public float shakeStrength = 0.4f;

    public bool isGrounded;
    Rigidbody rb;

    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    float immunityTime;
    public TMP_Text immunityText;

    public GameObject gameOverPanel;
    public int health = 3;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        SetHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.North);
        if (Input.GetKeyDown(KeyCode.D))
            MovePlayer(Direction.East);
        if (Input.GetKeyDown(KeyCode.S))
            MovePlayer(Direction.South);
        if (Input.GetKeyDown(KeyCode.A))
            MovePlayer(Direction.West);


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hasPowerup == true)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);


                Debug.Log("Collided with " + collision.gameObject.name + " with power set to " + hasPowerup);
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                Camera.main.DOShakePosition(moveTweenTime / 2, shakeStrength);

            }
            else
            {
                if (health == 0)
                {
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0;
                }

                else
                {
                    health--;
                    SetHealthText();
                }
            }
        }

        if (collision.gameObject.CompareTag("Death Zone"))
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    IEnumerator PowerupCountdownRoutine(float countDownValue = 4)
    {
        immunityTime = countDownValue;
        while (immunityTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            immunityTime--;
            immunityText.text = "Immunity: " + immunityTime;
        }
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        GetComponent<Renderer>().material.color = Color.white;
    }

    void MovePlayer(Direction _direction)
    {
        switch (_direction)
        {
            case Direction.North:
                player.transform.DOMoveZ(player.transform.position.z + moveDistance, moveTweenTime).SetEase(moveEase);
                break;
            case Direction.East:
                player.transform.DOMoveX(player.transform.position.x + moveDistance, moveTweenTime).SetEase(moveEase);
                break;
            case Direction.South:
                player.transform.DOMoveZ(player.transform.position.z - moveDistance, moveTweenTime).SetEase(moveEase);
                break;
            case Direction.West:
                player.transform.DOMoveX(player.transform.position.x - moveDistance, moveTweenTime).SetEase(moveEase);
                break;
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
