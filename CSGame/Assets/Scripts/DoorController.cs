using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // The angle at which the door is fully open
    public float closeSpeed = 2f; // Speed at which the door closes
    public float openSpeed = 2f; // Speed at which the door opens
    public bool isOpen = false; // Whether the door is currently open

    private float targetAngle;
    private float currentAngle;
    private Vector3 initialRotation;

    void Start()
    {
        // Store the initial rotation of the door
        initialRotation = transform.eulerAngles;
        // Set the target angle to the initial rotation
        targetAngle = initialRotation.y;
        // Set the current angle to the initial rotation
        currentAngle = initialRotation.y;
    }

    void Update()
    {
        // If the door is supposed to be open
        if (isOpen)
        {
            // Calculate the target angle
            targetAngle = initialRotation.y + openAngle;
        }
        else
        {
            // Calculate the target angle
            targetAngle = initialRotation.y;
        }

        // Smoothly rotate the door towards the target angle
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * (isOpen ? openSpeed : closeSpeed));
        // Apply the rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
    }

    // Call this method to toggle the door's open state
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}