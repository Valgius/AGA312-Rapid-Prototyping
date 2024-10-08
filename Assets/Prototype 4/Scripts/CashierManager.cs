using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public enum Difficulty { Easy, Medium, Hard }

public class CashierManager : MonoBehaviour
{
    public TMP_InputField amountInput;
    public float correctTotalPrice;
    public bool change;

    public GameObject correctAnswer;
    public GameObject inCorrectAnswer;

    public float ammountGiven; // The amount of money given by the player
    public float correctChange; // The amount of change the player needs to give

    public Difficulty difficulty;
    public GameObject difficultyPanel;

    public TMP_Text customerText;

    public int customerCount = 0;
    public TMP_Text customerCountText;

    public void Start()
    {
        Time.timeScale = 0;
        difficultyPanel.SetActive(true);
        correctAnswer.SetActive(false);
        inCorrectAnswer.SetActive(false);
        change = false;
    }

    public void SubmitAmount()
    {
        if (float.TryParse(amountInput.text, out float enteredAmount))
        {
            // Check if the entered amount matches the correct total price
            if (enteredAmount == correctTotalPrice)
            {
                if (change == false)
                {
                    inCorrectAnswer.SetActive(false);
                    customerText = GetComponent<CustomerGenerator>().customerText;
                    customerText.text = "Price was " + correctTotalPrice + ". Here is " + ammountGiven + ". What is my Change?";
                    change = true;
                    amountInput.text = null;
                    StartCoroutine(CorrectAnswer());
                    return;
                }
            }

             // Check if the entered amount matches the correct change
             else if (enteredAmount == correctChange)
            {
                if (change == true)
                {
                    inCorrectAnswer.SetActive(false);
                    correctAnswer.SetActive(true);
                    customerCount++;
                    customerCountText.text = "Customers Served " + customerCount;
                    StartCoroutine(WaitAndGenerateNewCustomer());
                    change = false;
                    amountInput.text = null;
                    return;
                }
            }

            StartCoroutine(IncorrectAnswer());
        }
    }

    public void SetTotalPrice(float price)
    {
        correctTotalPrice = price;
    }

    public void GenerateChange()
    {

    }

    private IEnumerator WaitAndGenerateNewCustomer()
    {
        StartCoroutine(CorrectAnswer());
        yield return new WaitForSeconds(0.2f); // Wait for the specified duration
        GenerateNewCustomer();
    }

    private IEnumerator IncorrectAnswer()
    {
        inCorrectAnswer.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the specified duration
        inCorrectAnswer.SetActive(false);
    }

    private IEnumerator CorrectAnswer()
    {
        correctAnswer.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the specified duration
        correctAnswer.SetActive(false);
    }

    private void GenerateNewCustomer()
    {
        // Assuming CustomerGenerator is attached to the same object
        GetComponent<CustomerGenerator>().GenerateCustomer();
    }

    public void GenerateCustomerChange()
    {
        switch (GetComponent<CustomerGenerator>().cashier.difficulty)
        {
            case Difficulty.Easy:
                ammountGiven = Random.Range((int)correctTotalPrice + 1, (int)correctTotalPrice + 5);
                correctChange = ammountGiven - correctTotalPrice;
                break;
            case Difficulty.Medium:
                ammountGiven = Random.Range((int)correctTotalPrice + 1, (int)correctTotalPrice + 10);
                correctChange = ammountGiven - correctTotalPrice;
                break;
            case Difficulty.Hard:
                ammountGiven = Random.Range((int)correctTotalPrice + 1, (int)correctTotalPrice + 15);
                correctChange = ammountGiven - correctTotalPrice;
                break;
        }
    }

    public void SetEasy()
    {
        difficulty = Difficulty.Easy;
        difficultyPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetMedium()
    {
        difficulty = Difficulty.Medium;
        difficultyPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetHard()
    {
        difficulty = Difficulty.Hard;
        difficultyPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
