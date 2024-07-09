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

    private void Start()
    {
        controller = GetComponent<CharacterController>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            if (Input.GetKey(KeyCode.E))
                Destroy(collision.gameObject);
            else
                return;
    }
}
