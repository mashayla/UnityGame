using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform Enemy; // Reference to the enemy
    public float openDistance = 5f; // Distance at which the door opens

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
        // Distance to the enemy
        float distance = Vector3.Distance(Enemy.position, transform.position);

        // If the enemy is within the open distance
        if (distance <= openDistance)
        {
            // Open the door
            isOpen = true;
        }
        else
        {
            // Close the door
            isOpen = false;
        }

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

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}