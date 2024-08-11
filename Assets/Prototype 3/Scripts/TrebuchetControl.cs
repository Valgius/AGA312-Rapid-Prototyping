using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrebuchetControl : MonoBehaviour
{
    public Rigidbody weightRB;
    public GameObject weight;
    public GameObject ammo;
    public GameObject arm;

    public bool isLoaded;
    public int weightMass;
    public TMP_Text weightmassText;

    public float rotationSpeed = 45f; // Speed of rotation in degrees per second
    public float maxRotationAngle = 45f; // Maximum rotation angle in degrees
    private float currentRotation = 0f; // Current accumulated rotation

    public float resetDelay = 3f;

    [System.Serializable]
    public class ObjectState
    {
        public GameObject gameObject;
        public Vector3 initialPosition;
        public Quaternion initialRotation;
    }

    public ObjectState[] objectsToReset;

    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
        UpdateWeightMass();
        // Set the initial states for each GameObject in the array
        SetInitialStates();
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

    public void SetInitialStates()
    {
        foreach (ObjectState objState in objectsToReset)
        {
            if (objState.gameObject != null)
            {
                objState.gameObject.transform.position = objState.initialPosition;
                objState.gameObject.transform.rotation = objState.initialRotation;
            }
        }
    }

    IEnumerator ResetTrebuchet()
    {
        // Reset the object's position
        SetInitialStates();
        currentRotation = 0;

        weightRB.isKinematic = true;

        isLoaded = false;

        // Wait for a specified delay before instantiating a new object
        yield return new WaitForSeconds(resetDelay);

        if (isLoaded == false)
            //Instantiate more ammo
            Instantiate(ammo, new Vector3(0, 1.83f, -6.95f), Quaternion.Euler(0, 0, 0));
    }
}
