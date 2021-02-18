using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;

    public Transform gameCamera;

    public Animator animator;

    private float moveSpeed;

    public float defaultMoveSpeed = 5.0f;

    public float runSpeed = 9.0f;

    public float turnSpeed = 2.0f;

    public bool running = false;

    public float jumpPower = 6.0f;

    private float jumpControl = 0.98f;

    private bool grounded = true;

    

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        float rotationalInputX = Input.GetAxis("MouseX");

        float rotationalInputY = Input.GetAxis("MouseY");

        float rightTrigger = Input.GetAxis("RT");

        float leftTrigger = Input.GetAxis("LT");

        bool leftBumper = Input.GetButtonDown("LB");

        bool rightBumper = Input.GetButtonDown("RB");

        bool jump = Input.GetButtonDown("Jump");

        bool fire1 = Input.GetButtonDown("Fire1");

        bool fire2 = Input.GetButtonDown("Fire2");

        bool fire3 = Input.GetButtonDown("Fire3");

        bool leftToggle = Input.GetButtonDown("LeftToggle");

        bool rightToggle = Input.GetButtonDown("RightToggle");

        
        if (jump && grounded)
        {
            playerRb.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);

            grounded = false;

        }

        if (leftToggle)
        {
            if (running)
            {
                running = false;
            }
            else
            {
                running = true;
            }
        }

        if (!grounded)
        {
            moveSpeed *= jumpControl;

        }

        else
        {
            if(!running)
            {
                moveSpeed = defaultMoveSpeed;
            }
            else
            {
                moveSpeed = runSpeed;
            }

        }

        if (verticalInput != 0 || horizontalInput != 0) // if joystick is pressed
        {
            if (running) 
            {
                animator.Play("Run");
            }
            else
            {
                animator.Play("Walk");
            }

            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

            transform.Translate(direction);
        }

        else
        {
            animator.Play("Idle");
        }

        gameCamera.transform.Rotate(new Vector3(rotationalInputY, 0, 0));


        transform.Rotate(new Vector3(0, rotationalInputX * turnSpeed, 0));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;

        }
    }

}
