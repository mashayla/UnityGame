using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    public bool isLocked = true; // Whether the door is currently locked
    public bool hasKey = false; // Whether the player has the key
    public float openAngle = 90f; // The angle at which the door is fully open
    public float openSpeed = 2f; // Speed at which the door opens
    public float unlockDistance = 2f; // The distance within which the player must be to unlock the door

    private float targetAngle;
    private float currentAngle;
    private Vector3 initialRotation;
    public Transform player; // Reference to the player's transform

    void Start()
    {
        initialRotation = transform.eulerAngles;
        targetAngle = initialRotation.y;
        currentAngle = initialRotation.y;
    }

    void Update()
    {
        // Check if the player has the key and is within the unlock distance
        if (hasKey && Vector3.Distance(transform.position, player.position) <= unlockDistance)
        {
            targetAngle = initialRotation.y + openAngle;
        }
        else
        {
            targetAngle = initialRotation.y;
        }

        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * openSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
    }

    // Method to set the hasKey variable directly
    public void SetHasKey(bool value)
    {
        hasKey = value;
        if (hasKey)
        {
            Debug.Log("Key picked up. Door can now be unlocked.");
        }
    }
}
