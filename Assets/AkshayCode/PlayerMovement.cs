
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float minSpeed;
    public float moveSpeed;
    
    

    public float maxSpeed;
    



    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;

    [Header("Ground Check")]
    bool isGrounded;
    public float playerHeight;
    public LayerMask whatIsGround;
    public float groundDrag;

    [Header("Jump Mechanics")]

    bool readyToJump;
    public int numOfJumps;
    public int maxNumOfJumps;
    public float airMultiplier;
    public float jumpForce;
    public float jumpCooldown;


    Rigidbody rb;

    public CheckForPause pauseChecker;


    // Start is called before the first frame update
    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();

        //Freeze the rotation of the object, since movement is happening based on the orientation object.
        rb.freezeRotation = true;

        // Give the player jumps.
        numOfJumps = maxNumOfJumps - 1;
        

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");



        // when to jump
        if (Input.GetKey(KeyCode.Space) && readyToJump && numOfJumps > 0)
        {
            readyToJump = false;
            
            Jump();

            Invoke(nameof(ReadyToJump), jumpCooldown);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Check to see if player is grounded and give jumps back if so
        if (isGrounded) numOfJumps = maxNumOfJumps - 1;

        if (pauseChecker.paused)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = maxSpeed;

        }
        else
        {

            moveSpeed = minSpeed;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        MyInput();


        //Change the drag when the player is grounded. Make the player faster when they are in the air.

        if (isGrounded)
        {
            if(Math.Abs(Math.Abs(verticalInput) + Math.Abs(horizontalInput)) <= 0.01){
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            }  
        }
        else
        {
            rb.drag = 0;
        }
        //Update the horizontal and vertical input variables.






    }


    private void FixedUpdate()
    {


        
        MovePlayer();
        SpeedControl();





    }
    private void MovePlayer()
    {
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded)
            rb.AddForce(movementDirection.normalized *  moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!isGrounded)
            rb.AddForce(movementDirection.normalized * airMultiplier * moveSpeed * 10f, ForceMode.Force);



    }

    private void SpeedControl()
    {
        if(rb.velocity.magnitude > moveSpeed)
        {
            Vector3 maxVel = new Vector3(rb.velocity.x, 0, rb.velocity.z).normalized * moveSpeed;

            rb.velocity = new Vector3(maxVel.x, rb.velocity.y, maxVel.z);
        }
    }

 

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        numOfJumps--;
    }

    private void ReadyToJump()
    {
        readyToJump = true;
    }
}
