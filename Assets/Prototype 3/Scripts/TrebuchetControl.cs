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

    public float rotationSpeed = 45f; // Speed of rotation in degrees per second
    public float maxRotationAngle = 45f; // Maximum rotation angle in degrees
    private float currentRotation = 0f; // Current accumulated rotation

    public float resetDelay = 3f;
    private Vector3 initialPosition; // Initial position of the object

    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
        UpdateWeightMass();
        initialPosition = transform.position; // Record the initial position of the object
    }

    // Update is called once per frame
    void Update()
    {
        //Increase ammo eeight
        if (Input.GetKey(KeyCode.W))
        {
            weightMass = weightMass + 1;
            UpdateWeightMass();
        }

        //Decrease ammo weight
        if (Input.GetKey(KeyCode.S))
        {
            weightMass = weightMass - 1;
            UpdateWeightMass();
        }

        // Rotate left (negative rotation)
        if (Input.GetKey(KeyCode.A))
        {
            RotateObject(-1);
        }

        // Rotate right (positive rotation)
        if (Input.GetKey(KeyCode.D))
        {
            RotateObject(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Release the weight
            weightRB.isKinematic = false;

            //Sets ammo to false
            isLoaded = false;
        }

        //Resets the Trebuchet
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(ResetTrebuchet());
    }

    private void UpdateWeightMass()
    {
        weightRB.mass = weightMass;
        weightmassText.text = ("Weight: " + weightMass);
    }

    void RotateObject(int direction)
    {
        float targetRotation = currentRotation + direction * rotationSpeed * Time.deltaTime;
        targetRotation = Mathf.Clamp(targetRotation, -maxRotationAngle, maxRotationAngle);

        transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);
        currentRotation = targetRotation;
    }

    IEnumerator ResetTrebuchet()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        weight.transform.position = new Vector3(0, 3.35f, 1.29f);
        weight.transform.rotation = Quaternion.Euler(0, 0, 0);

        weightRB.isKinematic = true;

        isLoaded = false;

        // Reset the object's position
        transform.position = initialPosition;

        // Wait for a specified delay before instantiating a new object
        yield return new WaitForSeconds(resetDelay);

        if (isLoaded == false)
            //Instantiate more ammo
            Instantiate(ammo, new Vector3(0, 1.83f, -6.95f), Quaternion.Euler(0, 0, 0));
    }
}
