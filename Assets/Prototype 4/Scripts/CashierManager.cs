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
    public TMP_Text feedbackText;
    public float correctTotalPrice;

    public Difficulty difficulty;
    public GameObject difficultyPanel;

    public int customerCount = 0;
    public TMP_Text customerCountText;

    public void Start()
    {
        Time.timeScale = 0;
        difficultyPanel.SetActive(true);
    }

    public void SubmitAmount()
    {
        if (float.TryParse(amountInput.text, out float enteredAmount))
        {
            if (enteredAmount == correctTotalPrice)
            {
                customerCount++;
                customerCountText.text = "Customers Served " + customerCount;
                GenerateNewCustomer();  // Call to generate a new customer
            }
            else
            {
                feedbackText.text = "Incorrect. Try again.";
            }
        }
        else
        {
            feedbackText.text = "Please enter a valid number.";
        }
    }

    public void SetTotalPrice(float price)
    {
        correctTotalPrice = price;
    }

    private void GenerateNewCustomer()
    {
        // Assuming CustomerGenerator is attached to the same object
        GetComponent<CustomerGenerator>().GenerateCustomer();
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
