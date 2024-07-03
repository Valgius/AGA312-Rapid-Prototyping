using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    //Chaecks if player is touching the ground
    public bool isGrounded;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f; //Real force of gravity in units
    public LayerMask groundMask;
    public Transform groundCheck;

    public float jumpHeight;

    public int myHealth;

    private CharacterController controller;

    [Header("Prototype 2")]
    public bool hasWater;
    public bool hasFertiliser;
    public TMP_Text itemText;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        itemText.text = "Item: None";
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Moves the chracter
    /// </summary>
    private void Move()
    {
        //Checks if we are touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //creates sphere at foot of player to see if they are touching the ground.
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        //Get input for player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, z);
        moveDirection = transform.TransformDirection(moveDirection);

        if(isGrounded)
        {
            //Checks to see if player is walking or running
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
                Jump();
        }

        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (other.CompareTag("Water"))
            {
                hasWater = true;
                hasFertiliser = false;
                itemText.text = "Item: Water";

}

            if (other.CompareTag("Fertiliser"))
            {
                hasWater = false;
                hasFertiliser = true;
                itemText.text = "Item: Fertiliser";
            }
        }
    }

    public void noitems()
    {
        hasWater = true;
        hasFertiliser = true;
    }
}
