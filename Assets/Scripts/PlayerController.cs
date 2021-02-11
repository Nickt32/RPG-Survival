using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;

    public Transform gameCamera;

    public float speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        Move();

        turnCamera();
    }

    public void turnCamera() { 
    
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        float rotationalInput = Input.GetAxis("MouseX");

        float rightTrigger = Input.GetAxis("RT");

        float leftTrigger = Input.GetAxis("LT");

        bool leftBumper = Input.GetButtonDown("LB");

        bool rightBumper = Input.GetButtonDown("RB");

        bool jump = Input.GetButtonDown("Jump");

        bool fire1 = Input.GetButtonDown("Fire1");

        bool fire2 = Input.GetButtonDown("Fire2");

        bool fire3 = Input.GetButtonDown("Fire3");

        if(Input.GetButtonDown("ToggleMenu"))
        {
            print("Pressed");
        }


        Vector3 direction = transform.forward * verticalInput + transform.right * horizontalInput;

    }

}
