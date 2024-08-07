using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashierManager : MonoBehaviour
{
    public TMP_InputField amountInput;
    public TMP_Text feedbackText;
    public float correctTotalPrice;

    public int customerCount = 0;
    public TMP_Text customerCountText;

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
}
