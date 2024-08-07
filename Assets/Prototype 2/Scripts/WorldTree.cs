using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class WorldTree : MonoBehaviour
{
    public int waterLevel;
    public int fertiliser;
    public int treeHealth;

    public int maxWaterLevel;
    public int maxFertiliser;
    public int maxTreeHealth;

    public TMP_Text waterLevelText;
    public TMP_Text fertiliserText;
    public TMP_Text treeHealthText;

    public float CountdownTime;
    public float maxCountdownTime;
    public float reduceInterval;
    private float timer;
    public int size;

    public GameObject objectToScale;
    public float scaleFactor = 1.5f; // Factor by which to scale the object

    public GameObject gameOverPanel;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        FillFertiliser();
        FillWater();
        FillHealth();

        CountdownTime = maxCountdownTime;

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (treeHealth < 0)
        {
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }


        if (CountdownTime > 0)
        {
            CountdownTime -= Time.deltaTime;
        }
        else
        {
            CountdownTime = maxCountdownTime;
            if (fertiliser > 0 && size > 0 )
            {
                ScaleObject();
                size--;
            }
            if (size == 0)
            {
                Time.timeScale = 0;
                winPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        // Increase the timer by the time since the last frame
        timer += Time.deltaTime;

        if (timer >= reduceInterval)
        {
            // Reduce currentValue by 1
            waterLevel--;
            fertiliser--;

            // Reset the timer
            timer = 0f;

            // check if currentValue has reached targetValue
            if (waterLevel <= 0)
            {
                treeHealth--;
                if (treeHealth <= 0)
                {
                    Time.timeScale = 0;
                    gameOverPanel.SetActive(true);
                }
            }

            treeHealthText.text = ("Health: " + treeHealth);
            fertiliserText.text = ("Fertiliser: " + fertiliser);
            waterLevelText.text = ("Water: " + waterLevel);
        }

        void ScaleObject()
        {
            // Check if objectToScale is not null to avoid errors
            if (objectToScale != null)
            {
                // Increase object's scale
                objectToScale.transform.localScale *= scaleFactor;

                // Moves the tree up by scale ammount
                //Vector3 newPosition = new Vector3(0, transform.localScale.y, 0);
                //transform.position = newPosition;
            }
            else
            {
                Debug.LogWarning("objectToScale is not assigned.");
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Damage());
        }
    }

    public void FillFertiliser()
    {
        fertiliser = maxFertiliser;
        fertiliserText.text = ("Fertiliser: " + fertiliser);
    }

    public void FillWater()
    {
        waterLevel = maxWaterLevel;
        waterLevelText.text = ("Water: " + waterLevel);
    }

    public void FillHealth()
    {
        treeHealth = maxTreeHealth;
        treeHealthText.text = ("Health: " + treeHealth);
    }

    public IEnumerator Damage()
    {
        treeHealth--;
        yield return new WaitForSeconds(5);
    }
}