using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrebuchetControl : MonoBehaviour
{
    public Rigidbody weightRB;
    public GameObject weight;
    public GameObject ammo;
    public bool isLoaded;
    public int weightMass;
    public TMP_Text weightmassText;

    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
        UpdateWeightMass();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            weightMass = weightMass + 50;
            UpdateWeightMass();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            weightMass = weightMass - 50;
            UpdateWeightMass();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Release the weight
            weightRB.isKinematic = false;

            //Sets amoo to false
            isLoaded = false;
        }

        //Resets the Trebuchet
        if (Input.GetKeyDown(KeyCode.R))
        {
            weight.transform.position = new Vector3 (0,3.35f,1.29f);
            weight.transform.rotation = Quaternion.Euler(0, 0, 0);

            weightRB.isKinematic = true;

            isLoaded = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && isLoaded == false)
            //Instantiate more ammo
            Instantiate(ammo, new Vector3(0, 1.83f, -6.95f), Quaternion.Euler(0, 0, 0));
        else
            return;
    }

    private void UpdateWeightMass()
    {
        weightRB.mass = weightMass;
        weightmassText.text = ("Weight: " + weightMass);
    }
}
