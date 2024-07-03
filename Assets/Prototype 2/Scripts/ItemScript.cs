using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ItemScript : MonoBehaviour
{
    public bool hasWater;
    public bool hasFertiliser;
    public TMP_Text itemText;

    public PlayerMovement playerMovement;
    public WorldTree worldTree;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        worldTree = GetComponent<WorldTree>();
        ItemsBothFalse();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (other.CompareTag("Water"))
            {
                ItemsBothFalse();
                ToggleWater();
                itemText.text = "Item: Water";

            }

            if (other.CompareTag("Fertiliser"))
            {
                ItemsBothFalse();
                ToggleFertiliser();
                itemText.text = "Item: Fertiliser";
            }
        }
    }

    public void ToggleWater()
    {
        hasWater = !hasWater;
    }

    public void ToggleFertiliser()
    {
        hasFertiliser = !hasFertiliser;
    }

    public void ItemsBothFalse()
    {
        hasWater = false;
        hasFertiliser = false;
        itemText.text = "Item: None";
    }
}
