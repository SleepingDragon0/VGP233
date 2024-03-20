using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Controller : MonoBehaviour
{
    //movement
    [SerializeField] float moveSpeed;
    [SerializeField] Transform orientation;
    [SerializeField] float groundDrag;

    //ground check
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask groundsy;

    //jump
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;
    bool readyToJump;

    
    //keybinds
    [SerializeField] KeyCode jumpKey;

    bool grounded;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }
    private void Update()
    {
        //ground check done using raycasting
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f+0.2f, groundsy);



        if (grounded )
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        MyInput();
        SpeedControl();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

  
    private void MovePlayer()
    {
        //calculating movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //allows to always walk int he direction you are moving

       

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            //adds velocity to object according to dt/mass
        }
        else if(!grounded) 
        {
        rb.AddForce(moveDirection.normalized*moveSpeed *10f*airMultiplier, ForceMode.Force);
        }

    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity due to addforce adding too much
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //velocity reset each time
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //impulse since only applying force once on jump
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
