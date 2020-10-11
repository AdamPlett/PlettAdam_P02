using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Controller
    public CharacterController controller;
    //ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    //jump height
    public float jumpHeight = 3f;
    //Speed of player
    public float speed = 12f;
    //gravitational velocity
    Vector3 gVelocity;
    //gravity
    public float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && gVelocity.y < 0)
        {
            gVelocity.y = -2f;
        }
        //gets movement from the keyboard
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //applies movement to vector 3
        Vector3 move = transform.right * x + transform.forward * z;
        //moves the player character according to the vector 3
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded )
        {
            gVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        gVelocity.y += gravity * Time.deltaTime;

        controller.Move(gVelocity * Time.deltaTime);
    }
}
