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
    public WorldTree worldtree;

    public GameObject fertiliser;
    public GameObject water;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
                water.SetActive(true);

            }

            if (other.CompareTag("Fertiliser"))
            {
                ItemsBothFalse();
                ToggleFertiliser();
                itemText.text = "Item: Fertiliser";
                fertiliser.SetActive(true);
            }

            if (other.CompareTag("Tree"))
            {
                if (hasWater == true)
                {
                    GameObject.Find("WorldTree").GetComponent<WorldTree>().FillWater();
                    ItemsBothFalse();
                }
                if (hasFertiliser == true)
                {
                    GameObject.Find("WorldTree").GetComponent<WorldTree>().FillFertiliser();
                    ItemsBothFalse();
                    itemText.text = "Item: None";
                }
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
        fertiliser.SetActive(false);
        water.SetActive(false);
    }
}
