using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class CustomerGenerator : MonoBehaviour
{
    public GameObject customerPanel;
    public TMP_Text customerText;
    private int numItems;
    public int priceInt;

    public CashierManager cashier;

    public Image uiImage;                  // Reference to the UI Image component
    public Sprite[] sprites;               // Array to hold all the sprites

    // Dictionary to hold items and their prices
    private Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        { "Burger", 5 },
        { "Fries", 3 },
        { "Drink", 2 },
        { "Salad", 4 },
        { "Nuggets", 6 }
    };

    public void Start()
    {
        GenerateCustomer();
    }

    public void GenerateCustomer()
    {
        ChangeSprite();

        switch (cashier.difficulty)
        {
            case Difficulty.Easy:
                numItems = Random.Range(2, 3); // Number of items per customer
                break;
            case Difficulty.Medium:
                numItems = Random.Range(3, 4); // Number of items per customer
                break;
            case Difficulty.Hard:
                numItems = Random.Range(4, 5); // Number of items per customer
                break;
        }

        int totalPrice = 0;
        string customerInfo = "Customer Items:\n";

        // List to keep track of the items added
        List<string> itemsList = new List<string>(itemPrices.Keys);

        for (int i = 0; i < numItems; i++)
        {
            string item = itemsList[Random.Range(0, itemsList.Count)];
            int price = itemPrices[item]; // Get the price from the dictionary
            totalPrice += price;
            customerInfo += $"{item}: ${price}\n";
        }

        GetComponent<CashierManager>().SetTotalPrice(totalPrice);
        GetComponent<CashierManager>().GenerateCustomerChange();
        //customerInfo += $"Total: ${totalPrice:F2}";
        customerText.text = customerInfo;

        // Store the total price in a variable or send it to another script
        // e.g., GameManager.Instance.SetTotalPrice(totalPrice);
    }


    void ChangeSprite()
    {
        if (sprites.Length == 0)
            return;

        int randomIndex = Random.Range(0, sprites.Length);
       uiImage.sprite = sprites[randomIndex];
    }
}
