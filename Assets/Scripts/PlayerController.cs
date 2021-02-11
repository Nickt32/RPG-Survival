using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;

    public Transform gameCamera;

    public float moveSpeed = 4.0f;

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

        if(Input.GetButtonDown("ToggleMenu"))
        {
            print("Pressed");
        }




        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

        transform.Translate(direction);


        gameCamera.transform.Rotate(new Vector3(rotationalInputY, 0, 0));


        transform.Rotate(new Vector3(0, rotationalInputX, 0));
    }

}
