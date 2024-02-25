using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello from Start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //move object
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);

        //rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        // Calculate movement direction based on input
        //  Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // Apply movement velocity
        // rb.velocity = moveDirection * movementSpeed;

        // Get input for movement along each axis

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, movementSpeed, rb.velocity.z);
        }
        //BELOW IS HARDCODED METHOD FOR PLAYER MOVEMENT
        //if (Input.GetKeyDown("space"))
        //{
          //  to jump, change the y axis position to have the player go up
        //    rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        //}
     //   Movement around floor
        //if (Input.GetKey("w"))
        //{
        //    rb.velocity = new Vector3(0, 0, 5);
        //}
        //if (Input.GetKey("d"))
        //{
        //    rb.velocity = new Vector3(5, 0, 0);
        //}
        //if (Input.GetKey("s"))
        //{
        //    rb.velocity = new Vector3(0, 0, -5);
        //}
        //if (Input.GetKey("a"))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        //}
    }
}
